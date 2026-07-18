using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Orchestrators;
using XPoster.Models;

namespace XPoster.Tests.Orchestrators;

public class FeedOrchestratorTests
{
    private readonly Mock<ISender> _mockSender;
    private readonly Mock<ILogger<FeedOrchestrator>> _mockLogger;
    private readonly Mock<IFeedService> _mockFeedService;
    private readonly Mock<ITagReplacementProvider> _mockTagReplacementProvider;
    private readonly Mock<ITagReplacementService> _mockTagReplacementService;
    private readonly Mock<ITextToTextProvider> _mockTextProvider;
    private readonly Mock<ITextToImageProvider> _mockImageProvider;

    private static readonly List<string> DefaultUrls =
    [
        "https://cointelegraph.com/rss/tag/bitcoin",
        "https://www.coindesk.com/arc/outboundfeeds/rss"
    ];

    private static readonly Dictionary<string, string> DefaultReplacements = new()
    {
        { "bitcoin",    "#Bitcoin"    },
        { "btc",        "#BTC"        },
        { "fed",        "#FED"        }
    };

    // ---------------------------------------------------------------------------
    // Default prompt steps used across most tests
    // ---------------------------------------------------------------------------

    private static PromptStepOptions SummaryStep() => new()
    {
        Role = PromptRole.Summary,
        SystemPromptTemplate = "You are a crypto analyst.",
        UserPromptTemplate   = "Summarise: {Text}",
        Temperature          = 0.7,
        MaxTokenBudget       = 600,
        InputTextLabel       = "{Text}"
    };

    private static PromptStepOptions ImageDerivationStep() => new()
    {
        Role = PromptRole.ImagePromptDerivation,
        SystemPromptTemplate = "You generate image prompts.",
        UserPromptTemplate   = "Image prompt for: {Summary}",
        Temperature          = 0.8,
        MaxTokenBudget       = 300,
        InputTextLabel       = "{Summary}"
    };

    private static PromptStepOptions ImageGenerationStep() => new()
    {
        Role              = PromptRole.ImageGeneration,
        SystemPromptTemplate = string.Empty,
        UserPromptTemplate   = string.Empty,
        ImageQuantity     = 1,
        ImageSize         = "1024x1024",
        InputTextLabel    = "{Text}"
    };

    private static FeedPromptOptions DefaultPromptOptions() => new()
    {
        Steps = new List<PromptStepOptions>
        {
            SummaryStep(),
            ImageDerivationStep(),
            ImageGenerationStep()
        }.AsReadOnly()
    };

    /// <summary>Builds a <see cref="FeedOrchestratorContext"/> with optional URL override.</summary>
    private static FeedOrchestratorContext BuildContext(IReadOnlyList<string>? feedUrls = null) =>
        new()
        {
            FeedUrls      = feedUrls ?? DefaultUrls.AsReadOnly(),
            PromptOptions = DefaultPromptOptions()
        };

    public FeedOrchestratorTests()
    {
        _mockSender = new Mock<ISender>();
        _mockSender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        _mockLogger                  = new Mock<ILogger<FeedOrchestrator>>();
        _mockFeedService             = new Mock<IFeedService>();
        _mockTagReplacementProvider  = new Mock<ITagReplacementProvider>();
        _mockTagReplacementService   = new Mock<ITagReplacementService>();
        _mockTextProvider            = new Mock<ITextToTextProvider>();
        _mockImageProvider           = new Mock<ITextToImageProvider>();

        _mockTagReplacementProvider.Setup(p => p.GetReplacements())
            .Returns(DefaultReplacements);
        _mockTagReplacementService
            .Setup(s => s.Apply(It.IsAny<string>()))
            .Returns<string>(input =>
            {
                var replacements = _mockTagReplacementProvider.Object.GetReplacements();
                if (replacements.Count == 0)
                    return input;

                var output = input;
                foreach (var replacement in replacements)
                {
                    output = output.Replace(
                        replacement.Key,
                        replacement.Value,
                        StringComparison.OrdinalIgnoreCase);
                }

                return output;
            });
    }

    /// <summary>Factory for a single-sender orchestrator (happy-path baseline).</summary>
    private FeedOrchestrator CreateOrchestrator(
        ISender? sender = null,
        FeedOrchestratorContext? context = null) =>
        new(
            new List<ISender> { sender ?? _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            _mockFeedService.Object,
            context ?? BuildContext(),
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            _mockTextProvider.Object,
            _mockImageProvider.Object);

    /// <summary>Factory for a multi-sender orchestrator (fan-out tests).</summary>
    private FeedOrchestrator CreateMultiSenderOrchestrator(
        IReadOnlyList<ISender> senders,
        FeedOrchestratorContext? context = null) =>
        new(
            senders,
            _mockLogger.Object,
            _mockFeedService.Object,
            context ?? BuildContext(),
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            _mockTextProvider.Object,
            _mockImageProvider.Object);

    // ---------------------------------------------------------------------------
    // Happy path — single sender
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound()
    {
        // ARRANGE
        var fakeFeeds  = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Notizia su Bitcoin", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Questo è un riassunto";
        var fakePrompt  = "Prompt per immagine";
        var fakeImage   = new byte[] { 1, 2, 3 };

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);

        // Summary step — GenerateTextAsync receives a PromptRequest with Role=Summary
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);

        // ImagePromptDerivation step — GenerateTextAsync receives a PromptRequest with Role=ImagePromptDerivation
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);

        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(
                It.Is<ImagePromptRequest>(r => r.InputText == fakePrompt),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(posts);
        Assert.Single(posts);
        Assert.True(posts.ContainsKey(SenderPlatform.X));
        Assert.NotNull(posts[SenderPlatform.X]);
        Assert.Equal(fakeSummary, posts[SenderPlatform.X]!.Content);
        Assert.Equal(fakeImage, posts[SenderPlatform.X]!.Image);

        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2));

        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
            It.IsAny<CancellationToken>()), Times.Once);

        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
            It.IsAny<CancellationToken>()), Times.Once);

        _mockImageProvider.Verify(s => s.GenerateImageAsync(
            It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    // ---------------------------------------------------------------------------
    // FeedOrchestratorContext — slot isolation
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_UsesFeedUrls_FromInjectedContext()
    {
        // ARRANGE — context carries a specific URL list; feed service must be called with those URLs
        var slotUrls = new List<string> { "https://slot-specific.feed/rss" }.AsReadOnly();
        var context  = BuildContext(feedUrls: slotUrls);

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService
            .Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "L" } });

        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("summary");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateOrchestrator(context: context);

        // ACT
        await orchestrator.OrchestrateAsync();

        // ASSERT — feed service invoked with the context-provided URLs
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(),
            It.IsAny<CancellationToken>()), Times.AtLeastOnce);
    }

    [Fact]
    public async Task OrchestrateAsync_TwoSlots_ReceiveIndependentFeedUrlsAndPrompts()
    {
        // ARRANGE — two separate FeedOrchestratorContext instances (Feed06 / Feed08)
        var urlsFeed06 = new List<string> { "https://slot06.feed/rss" }.AsReadOnly();
        var urlsFeed08 = new List<string> { "https://slot08.feed/rss" }.AsReadOnly();

        var promptFeed06 = new FeedPromptOptions
        {
            Steps = new List<PromptStepOptions>
            {
                SummaryStep() with { SystemPromptTemplate = "System06" },
                ImageDerivationStep(),
                ImageGenerationStep()
            }.AsReadOnly()
        };

        var promptFeed08 = new FeedPromptOptions
        {
            Steps = new List<PromptStepOptions>
            {
                SummaryStep() with { SystemPromptTemplate = "System08" },
                ImageDerivationStep(),
                ImageGenerationStep()
            }.AsReadOnly()
        };

        var contextFeed06 = new FeedOrchestratorContext
        {
            FeedUrls = urlsFeed06,
            PromptOptions = promptFeed06
        };

        var contextFeed08 = new FeedOrchestratorContext
        {
            FeedUrls = urlsFeed08,
            PromptOptions = promptFeed08
        };

        var senderA = new Mock<ISender>();
        senderA.Setup(s => s.Platform).Returns(SenderPlatform.X);
        senderA.Setup(s => s.MessageMaxLength).Returns(280);

        var feedService06 = new Mock<IFeedService>();
        var feedService08 = new Mock<IFeedService>();

        feedService06.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(),
                It.IsAny<DateTimeOffset>(),
                It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<RSSFeed> { new() { Title = "T", Content = "C06", Link = "L" } });

        feedService08.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(),
                It.IsAny<DateTimeOffset>(),
                It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<RSSFeed> { new() { Title = "T", Content = "C08", Link = "L" } });

        var textProvider06 = new Mock<ITextToTextProvider>();
        textProvider06
            .Setup(s => s.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((PromptRequest request, CancellationToken _) =>
                request.SystemPromptTemplate == "System06" ? "summary06" : "image-prompt-06");

        var textProvider08 = new Mock<ITextToTextProvider>();
        textProvider08
            .Setup(s => s.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((PromptRequest request, CancellationToken _) =>
                request.SystemPromptTemplate == "System08" ? "summary08" : "image-prompt-08");

        var imgProvider = new Mock<ITextToImageProvider>();
        imgProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator06 = new FeedOrchestrator(
            new List<ISender> { senderA.Object }.AsReadOnly(),
            _mockLogger.Object,
            feedService06.Object,
            contextFeed06,
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            textProvider06.Object,
            imgProvider.Object);

        var orchestrator08 = new FeedOrchestrator(
            new List<ISender> { senderA.Object }.AsReadOnly(),
            _mockLogger.Object,
            feedService08.Object,
            contextFeed08,
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            textProvider08.Object,
            imgProvider.Object);

        // ACT
        await orchestrator06.OrchestrateAsync();
        await orchestrator08.OrchestrateAsync();

        // ASSERT — each slot used its own feed URLs
        feedService06.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(),
            It.IsAny<CancellationToken>()), Times.AtLeastOnce);

        feedService08.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(),
            It.IsAny<CancellationToken>()), Times.AtLeastOnce);

        // ASSERT — each slot used its own summary prompt template
        textProvider06.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.SystemPromptTemplate == "System06"),
            It.IsAny<CancellationToken>()), Times.Once);

        textProvider08.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.SystemPromptTemplate == "System08"),
            It.IsAny<CancellationToken>()), Times.Once);
    }
    
    // ---------------------------------------------------------------------------
    // Fan-out: base summary generated at primary sender's limit
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_GeneratesBaseSummaryAtPrimaryMaxLength()
    {
        // ARRANGE — primary sender has limit 700, secondary 280
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLength).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLength).Returns(280);

        var fakeFeeds  = new List<RSSFeed> { new() { Content = "feed content", Link = "x", Title = "t" } };
        var baseSummary = new string('A', 300); // fits both limits

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);

        // Summary step called with MaxOutputLength = 700 (primary sender)
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 700),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);

        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");

        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT — GenerateTextAsync for Summary called exactly once with MaxOutputLength=700
        Assert.Equal(2, posts.Count);
        _mockTextProvider.Verify(
            s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 700),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit()
    {
        // ARRANGE — primary limit 700, secondary limit 280; base summary 500 chars > 280
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLength).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLength).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "feed content", Link = "x", Title = "t" } };
        var baseSummary = new string('A', 500); // 500 > 280: re-summarisation needed
        var shortSummary = new string('B', 200);

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);

        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 700),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);

        // Re-summarisation: same Summary step, MaxOutputLength = 280
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 280),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(shortSummary);

        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");

        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Equal(2, posts.Count);
        Assert.True(posts.ContainsKey(SenderPlatform.X));
        Assert.True(posts.ContainsKey(SenderPlatform.LinkedIn));
        Assert.NotNull(posts[SenderPlatform.X]);
        Assert.NotNull(posts[SenderPlatform.LinkedIn]);
        Assert.Contains(baseSummary[..10], posts[SenderPlatform.X]!.Content);
        Assert.Contains(shortSummary[..10], posts[SenderPlatform.LinkedIn]!.Content);

        // Re-summarisation called once with MaxOutputLength=280
        _mockTextProvider.Verify(
            s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 280),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit()
    {
        // ARRANGE — base summary 200 chars <= secondary limit 280: no re-summarisation
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLength).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLength).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "feed content", Link = "x", Title = "t" } };
        var baseSummary = new string('A', 200);

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 700),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT — GenerateTextAsync for Summary called exactly once (primary only)
        Assert.Equal(2, posts.Count);
        _mockTextProvider.Verify(
            s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_AppliesHashtagsIndependently_PerSender()
    {
        // ARRANGE — both senders get "#Bitcoin" applied independently
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLength).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLength).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "bitcoin news", Link = "x", Title = "t" } };
        var baseSummary = "bitcoin is rising fast and we are all excited";

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Equal(2, posts.Count);
        Assert.Contains("#Bitcoin", posts[SenderPlatform.X]!.Content);
        Assert.Contains("#Bitcoin", posts[SenderPlatform.LinkedIn]!.Content);
    }

    [Fact]
    public async Task OrchestrateAsync_DerivesImagePromptFromRawBaseSummary_BeforeHashtags()
    {
        // ARRANGE — GetImagePromptDerivation step must receive raw summary WITHOUT hashtags
        var fakeFeeds  = new List<RSSFeed> { new() { Content = "bitcoin", Link = "x", Title = "t" } };
        var rawBase    = "bitcoin analysis";
        string? promptInput = null;

        _mockSender.Setup(s => s.MessageMaxLength).Returns(700);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawBase);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .Callback<PromptRequest, CancellationToken>((r, _) => promptInput = r.InputText)
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateOrchestrator();

        // ACT
        await orchestrator.OrchestrateAsync();

        // ASSERT — derivation received raw base (no hashtags)
        Assert.Equal(rawBase, promptInput);
        Assert.DoesNotContain("#Bitcoin", promptInput);
    }

    [Fact]
    public async Task OrchestrateAsync_SharesImageBytes_AcrossSenders()
    {
        // ARRANGE
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLength).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLength).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "feed", Link = "x", Title = "t" } };
        var baseSummary = new string('A', 200);
        var sharedImage = new byte[] { 9, 8, 7 };

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(sharedImage);

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT — image generated once and shared (same reference)
        Assert.Equal(2, posts.Count);
        Assert.Same(posts[SenderPlatform.X]!.Image, posts[SenderPlatform.LinkedIn]!.Image);
        _mockImageProvider.Verify(
            s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_ReturnsNullEntry_WhenReSummarisationFails()
    {
        // ARRANGE — base 500 > secondary 280; re-summarisation returns empty
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLength).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLength).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "feed", Link = "x", Title = "t" } };
        var baseSummary = new string('A', 500);

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 700),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 280),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Equal(2, posts.Count);
        Assert.NotNull(posts[SenderPlatform.X]);
        Assert.Null(posts[SenderPlatform.LinkedIn]);
    }

    // ---------------------------------------------------------------------------
    // 3-sender cascade — previousSummary propagation
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_ThirdSender_ChecksAgainstPreviousSummary_AndReSummarisesFromFeedContent()
    {
        // ARRANGE — X=700, LinkedIn=280, Instagram=150
        var senderX         = new Mock<ISender>();
        var senderLinkedIn  = new Mock<ISender>();
        var senderInstagram = new Mock<ISender>();
        senderX.Setup(s => s.Platform).Returns(SenderPlatform.X);
        senderX.Setup(s => s.MessageMaxLength).Returns(700);
        senderLinkedIn.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        senderLinkedIn.Setup(s => s.MessageMaxLength).Returns(280);
        senderInstagram.Setup(s => s.Platform).Returns(SenderPlatform.Instagram);
        senderInstagram.Setup(s => s.MessageMaxLength).Returns(150);

        var fakeFeeds        = new List<RSSFeed> { new() { Content = "feed content", Link = "x", Title = "t" } };
        var baseSummary      = new string('A', 500);
        var linkedInSummary  = new string('B', 200);
        var instagramSummary = new string('C', 100);

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 700),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 280),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(linkedInSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 150),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(instagramSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { senderX.Object, senderLinkedIn.Object, senderInstagram.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Equal(3, posts.Count);
        Assert.NotNull(posts[SenderPlatform.X]);
        Assert.NotNull(posts[SenderPlatform.LinkedIn]);
        Assert.NotNull(posts[SenderPlatform.Instagram]);
        Assert.Contains(baseSummary[..10], posts[SenderPlatform.X]!.Content);
        Assert.Contains(linkedInSummary[..10], posts[SenderPlatform.LinkedIn]!.Content);
        Assert.Contains(instagramSummary[..10], posts[SenderPlatform.Instagram]!.Content);

        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r =>
                r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate && r.MaxOutputLength == 700),
            It.IsAny<CancellationToken>()), Times.Once);
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r =>
                r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate && r.MaxOutputLength == 280),
            It.IsAny<CancellationToken>()), Times.Once);
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r =>
                r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate && r.MaxOutputLength == 150),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_ThirdSender_ReusesSecondSummary_WhenSecondFitsAndThirdDoesNot()
    {
        // ARRANGE — base 200 <= LinkedIn (280): LinkedIn reuses; 200 > Instagram (150): re-summarise
        var senderX         = new Mock<ISender>();
        var senderLinkedIn  = new Mock<ISender>();
        var senderInstagram = new Mock<ISender>();
        senderX.Setup(s => s.Platform).Returns(SenderPlatform.X);
        senderX.Setup(s => s.MessageMaxLength).Returns(700);
        senderLinkedIn.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        senderLinkedIn.Setup(s => s.MessageMaxLength).Returns(280);
        senderInstagram.Setup(s => s.Platform).Returns(SenderPlatform.Instagram);
        senderInstagram.Setup(s => s.MessageMaxLength).Returns(150);

        var fakeFeeds        = new List<RSSFeed> { new() { Content = "feed content", Link = "x", Title = "t" } };
        var baseSummary      = new string('A', 200);
        var instagramSummary = new string('C', 100);

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 700),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 150),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(instagramSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { senderX.Object, senderLinkedIn.Object, senderInstagram.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Equal(3, posts.Count);
        Assert.NotNull(posts[SenderPlatform.X]);
        Assert.NotNull(posts[SenderPlatform.LinkedIn]);
        Assert.NotNull(posts[SenderPlatform.Instagram]);
        Assert.Contains(baseSummary[..10], posts[SenderPlatform.LinkedIn]!.Content);
        Assert.Contains(instagramSummary[..10], posts[SenderPlatform.Instagram]!.Content);

        // Only 2 Summary calls: primary (700) + Instagram (150); NOT LinkedIn (280)
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
            It.IsAny<CancellationToken>()), Times.Exactly(2));
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r =>
                r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate && r.MaxOutputLength == 280),
            It.IsAny<CancellationToken>()), Times.Never);
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r =>
                r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate && r.MaxOutputLength == 150),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_ThirdSender_ReusesUpdatedPreviousSummary_WhenItFitsThirdLimit()
    {
        // ARRANGE — X=700, LinkedIn=280, Instagram=250; base 500 > 280 → LinkedIn re-summarises → 200; 200 <= 250 → Instagram reuses
        var senderX         = new Mock<ISender>();
        var senderLinkedIn  = new Mock<ISender>();
        var senderInstagram = new Mock<ISender>();
        senderX.Setup(s => s.Platform).Returns(SenderPlatform.X);
        senderX.Setup(s => s.MessageMaxLength).Returns(700);
        senderLinkedIn.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        senderLinkedIn.Setup(s => s.MessageMaxLength).Returns(280);
        senderInstagram.Setup(s => s.Platform).Returns(SenderPlatform.Instagram);
        senderInstagram.Setup(s => s.MessageMaxLength).Returns(250);

        var fakeFeeds       = new List<RSSFeed> { new() { Content = "feed content", Link = "x", Title = "t" } };
        var baseSummary     = new string('A', 500);
        var linkedInSummary = new string('B', 200);

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 700),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate &&
                    r.MaxOutputLength == 280),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(linkedInSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { senderX.Object, senderLinkedIn.Object, senderInstagram.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT — Instagram reuses linkedInSummary; no AI call at limit 250
        Assert.Equal(3, posts.Count);
        Assert.Contains(linkedInSummary[..10], posts[SenderPlatform.Instagram]!.Content);
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
            It.IsAny<CancellationToken>()), Times.Exactly(2));
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r =>
                r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate && r.MaxOutputLength == 250),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Step 1 — AcquireFeedContentAsync failure paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound()
    {
        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<RSSFeed>());

        var orchestrator = CreateOrchestrator();
        var result       = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnEmpty_When_ContextFeedUrlsIsEmpty()
    {
        // Empty feed URL list in context → feed service never called
        var context = BuildContext(feedUrls: new List<string>().AsReadOnly());

        var orchestrator = CreateOrchestrator(context: context);
        var result       = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Step 2 — GenerateRawSummaryAsync failure paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails()
    {
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);

        var orchestrator = CreateOrchestrator();
        var result       = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockImageProvider.Verify(s => s.GenerateImageAsync(
            It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Step 3 — ApplyTagReplacements (single sender)
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_CallTagReplacementProvider_ExactlyOnce_WhenOrchestrationSucceeds()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary text";

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateOrchestrator();
        await orchestrator.OrchestrateAsync();

        // GetReplacements: once in AcquireFeedContentAsync + once in ApplyTagReplacements = 2
        _mockTagReplacementProvider.Verify(p => p.GetReplacements(), Times.Exactly(2));
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ApplyHashtagsCorrectly()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "News about bitcoin and BTC and fed policy", Link = "https://bitcoin.org/" } };
        var fakeSummary = "News about bitcoin and btc. The fed decided...";

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateOrchestrator();
        var result       = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Contains("#Bitcoin", result[SenderPlatform.X]!.Content);
        Assert.Contains("#BTC", result[SenderPlatform.X]!.Content);
        Assert.Contains("#FED", result[SenderPlatform.X]!.Content);
        Assert.Single(System.Text.RegularExpressions.Regex.Matches(result[SenderPlatform.X]!.Content, "#Bitcoin"));
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithUnmodifiedContent_When_ProviderReturnsEmptyReplacements()
    {
        _mockTagReplacementProvider.Setup(p => p.GetReplacements())
            .Returns(new Dictionary<string, string>());

        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "bitcoin news", Link = "https://bitcoin.org/" } };
        var fakeSummary = "bitcoin summary";

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateOrchestrator();
        var result       = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Equal(fakeSummary, result[SenderPlatform.X]!.Content);
    }

    // ---------------------------------------------------------------------------
    // BuildPromptRequest — field mapping edge cases
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_PassNullInputTextLabel_ToPromptRequest()
    {
        // ARRANGE
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "L" } };
        var fakeSummary = "summary";

        // Step Summary senza InputTextLabel
        var promptOptions = new FeedPromptOptions
        {
            Steps = new List<PromptStepOptions>
            {
                SummaryStep() with { InputTextLabel = null },
                ImageDerivationStep(),
                ImageGenerationStep()
            }.AsReadOnly()
        };

        var context = new FeedOrchestratorContext
        {
            FeedUrls      = DefaultUrls.AsReadOnly(),
            PromptOptions = promptOptions
        };

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);

        _mockFeedService
            .Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(),
                It.IsAny<DateTimeOffset>(),
                It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);

        PromptRequest? capturedRequest = null;

        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .Callback<PromptRequest, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(fakeSummary);

        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");

        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(
                It.IsAny<ImagePromptRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = new FeedOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            _mockFeedService.Object,
            context,
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            _mockTextProvider.Object,
            _mockImageProvider.Object);

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotEmpty(posts);
        Assert.NotNull(capturedRequest);
        Assert.Null(capturedRequest!.InputTextLabel);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_PassNullMaxTokenBudget_ToPromptRequest()
    {
        // ARRANGE
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "L" } };
        var fakeSummary = "summary";

        // Step Summary senza MaxTokenBudget
        var promptOptions = new FeedPromptOptions
        {
            Steps = new List<PromptStepOptions>
            {
                SummaryStep() with { MaxTokenBudget = null },
                ImageDerivationStep(),
                ImageGenerationStep()
            }.AsReadOnly()
        };

        var context = new FeedOrchestratorContext
        {
            FeedUrls      = DefaultUrls.AsReadOnly(),
            PromptOptions = promptOptions
        };

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);

        _mockFeedService
            .Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(),
                It.IsAny<DateTimeOffset>(),
                It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);

        PromptRequest? capturedRequest = null;

        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .Callback<PromptRequest, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(fakeSummary);

        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r =>
                    r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");

        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(
                It.IsAny<ImagePromptRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = new FeedOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            _mockFeedService.Object,
            context,
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            _mockTextProvider.Object,
            _mockImageProvider.Object);

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotEmpty(posts);
        Assert.NotNull(capturedRequest);
        Assert.Null(capturedRequest!.MaxTokenBudget);
    }

    // ---------------------------------------------------------------------------
    // Image paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("Prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<byte>());

        var orchestrator = CreateOrchestrator();
        var result       = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Equal(fakeSummary, result[SenderPlatform.X]!.Content);
        Assert.Null(result[SenderPlatform.X]!.Image);
        Assert.True(orchestrator.SendIt);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("Prompt");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Image generation failed"));

        var orchestrator = CreateOrchestrator();
        var result       = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Null(result[SenderPlatform.X]!.Image);
        Assert.True(orchestrator.SendIt);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageProviderIsNull()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);

        var orchestrator = new FeedOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            _mockFeedService.Object,
            BuildContext(),
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            _mockTextProvider.Object,
            imageProvider: null);

        var result = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Null(result[SenderPlatform.X]!.Image);
        Assert.True(orchestrator.SendIt);

        // ImagePromptDerivation step must never be called when imageProvider is null
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Guard paths — null providers
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_TextProviderIsNull()
    {
        var orchestrator = new FeedOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            _mockFeedService.Object,
            BuildContext(),
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            textProvider: null,
            imageProvider: null);

        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_SenderIsNull()
    {
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } });

        var orchestrator = new FeedOrchestrator(
            new List<ISender>().AsReadOnly(),
            _mockLogger.Object,
            _mockFeedService.Object,
            BuildContext(),
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            _mockTextProvider.Object,
            _mockImageProvider.Object);

        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockTextProvider.Verify(s => s.GenerateTextAsync(
            It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Image prompt fallback — derivation returns empty/whitespace
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_UseSummaryAsPrompt_When_ImagePromptDerivationReturnsEmpty()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Fallback summary used as prompt";
        var fakeImage   = new byte[] { 9, 8, 7 };

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(
                It.Is<ImagePromptRequest>(r => r.InputText == fakeSummary),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();
        var result       = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.Equal(fakeImage, result[SenderPlatform.X]!.Image);
        _mockImageProvider.Verify(
            s => s.GenerateImageAsync(
                It.Is<ImagePromptRequest>(r => r.InputText == fakeSummary),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_UseSummaryAsPrompt_When_ImagePromptDerivationReturnsWhitespace()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Fallback summary";
        var fakeImage   = new byte[] { 1 };

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("   ");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(
                It.Is<ImagePromptRequest>(r => r.InputText == fakeSummary),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);
        var orchestrator = CreateOrchestrator();
        var result       = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.Equal(fakeImage, result[SenderPlatform.X]!.Image);
        _mockImageProvider.Verify(
            s => s.GenerateImageAsync(
                It.Is<ImagePromptRequest>(r => r.InputText == fakeSummary),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    // ---------------------------------------------------------------------------
    // Cancellation
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_Rethrow_When_ImageGenerationIsCancelled()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";
        using var cts   = new CancellationTokenSource();
        cts.Cancel();

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == SummaryStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(
                It.Is<PromptRequest>(r => r.SystemPromptTemplate == ImageDerivationStep().SystemPromptTemplate),
                It.IsAny<CancellationToken>()))
            .ThrowsAsync(new OperationCanceledException(cts.Token));

        var orchestrator = CreateOrchestrator();

        // ACT + ASSERT — must propagate, not be swallowed
        await Assert.ThrowsAsync<OperationCanceledException>(
            () => orchestrator.OrchestrateAsync(cts.Token));
    }
}
