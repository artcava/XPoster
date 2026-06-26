using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Orchestrators;
using XPoster.Models;

namespace XPoster.Tests.Orchestrators;

public class FeedOrchestratorTests
{
    private readonly Mock<ISender>                     _mockSender;
    private readonly Mock<ILogger<FeedOrchestrator>>   _mockLogger;
    private readonly Mock<IFeedService>                _mockFeedService;
    private readonly Mock<IFeedUrlProvider>            _mockFeedUrlProvider;
    private readonly Mock<ITagReplacementProvider>     _mockTagReplacementProvider;
    private readonly Mock<ITextToTextProvider>         _mockTextProvider;
    private readonly Mock<ITextToImageProvider>        _mockImageProvider;

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

    public FeedOrchestratorTests()
    {
        _mockSender                 = new Mock<ISender>();
        _mockSender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        _mockLogger                 = new Mock<ILogger<FeedOrchestrator>>();
        _mockFeedService            = new Mock<IFeedService>();
        _mockFeedUrlProvider        = new Mock<IFeedUrlProvider>();
        _mockTagReplacementProvider = new Mock<ITagReplacementProvider>();
        _mockTextProvider           = new Mock<ITextToTextProvider>();
        _mockImageProvider          = new Mock<ITextToImageProvider>();

        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(DefaultUrls);
        _mockTagReplacementProvider.Setup(p => p.GetReplacements())
            .Returns(DefaultReplacements);
    }

    /// <summary>Factory for a single-sender orchestrator (happy-path baseline).</summary>
    private FeedOrchestrator CreateOrchestrator(ISender? sender = null) =>
        new(
            new List<ISender> { sender ?? _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            _mockTextProvider.Object, _mockImageProvider.Object);

    /// <summary>Factory for a multi-sender orchestrator (fan-out tests).</summary>
    private FeedOrchestrator CreateMultiSenderOrchestrator(IReadOnlyList<ISender> senders) =>
        new(
            senders,
            _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            _mockTextProvider.Object, _mockImageProvider.Object);

    // ---------------------------------------------------------------------------
    // Happy path — single sender
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound()
    {
        // ARRANGE
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Notizia su Bitcoin", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Questo è un riassunto";
        var fakePrompt  = "Prompt per immagine";
        var fakeImage   = new byte[] { 1, 2, 3 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);
        _mockImageProvider.Setup(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()))
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

        _mockFeedUrlProvider.Verify(p => p.GetFeedUrls(), Times.Once);
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()),
            Times.Exactly(2));
        _mockTextProvider.Verify(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockTextProvider.Verify(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockImageProvider.Verify(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()), Times.Once);
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
        primarySender.Setup(s => s.MessageMaxLenght).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLenght).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "feed content", Link = "x", Title = "t" } };
        var baseSummary = new string('A', 300); // fits both limits

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), 700, It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT — GetSummaryAsync called exactly once with primary limit (700)
        Assert.Equal(2, posts.Count);
        _mockTextProvider.Verify(
            s => s.GetSummaryAsync(It.IsAny<string>(), 700, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit()
    {
        // ARRANGE — primary limit 700, secondary limit 280; base summary 500 chars > 280
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLenght).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLenght).Returns(280);

        var fakeFeeds    = new List<RSSFeed> { new() { Content = "feed content", Link = "x", Title = "t" } };
        var baseSummary  = new string('A', 500); // 500 > 280: re-summarisation needed
        var shortSummary = new string('B', 200);

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), 700, It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(baseSummary, 280, It.IsAny<CancellationToken>()))
            .ReturnsAsync(shortSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
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
        Assert.Contains(baseSummary[..10],  posts[SenderPlatform.X]!.Content);        // primary uses base
        Assert.Contains(shortSummary[..10], posts[SenderPlatform.LinkedIn]!.Content); // secondary uses re-summarised
        _mockTextProvider.Verify(
            s => s.GetSummaryAsync(baseSummary, 280, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit()
    {
        // ARRANGE — base summary 200 chars <= secondary limit 280: AI call must be skipped
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLenght).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLenght).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "feed content", Link = "x", Title = "t" } };
        var baseSummary = new string('A', 200); // 200 <= 280: no re-summarisation

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), 700, It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT — GetSummaryAsync called exactly once (only for primary)
        Assert.Equal(2, posts.Count);
        _mockTextProvider.Verify(
            s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_AppliesHashtagsIndependently_PerSender()
    {
        // ARRANGE — base summary contains "bitcoin"; both senders get "#Bitcoin" applied independently
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLenght).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLenght).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "bitcoin news", Link = "x", Title = "t" } };
        var baseSummary = "bitcoin is rising fast and we are all excited"; // fits both limits

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), 700, It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT — each post independently has the hashtag applied
        Assert.Equal(2, posts.Count);
        Assert.True(posts.ContainsKey(SenderPlatform.X));
        Assert.True(posts.ContainsKey(SenderPlatform.LinkedIn));
        Assert.Contains("#Bitcoin", posts[SenderPlatform.X]!.Content);
        Assert.Contains("#Bitcoin", posts[SenderPlatform.LinkedIn]!.Content);
    }

    [Fact]
    public async Task OrchestrateAsync_DerivesImagePromptFromRawBaseSummary_BeforeHashtags()
    {
        // ARRANGE — raw base summary is clean prose; GetImagePromptAsync must receive it WITHOUT hashtags
        var fakeFeeds   = new List<RSSFeed> { new() { Content = "bitcoin", Link = "x", Title = "t" } };
        var rawBase     = "bitcoin analysis"; // no hashtag yet
        string? promptInput = null;

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(700);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(rawBase);
        _mockTextProvider
            .Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Callback<string, CancellationToken>((input, _) => promptInput = input)
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateOrchestrator();

        // ACT
        await orchestrator.OrchestrateAsync();

        // ASSERT — prompt was derived from rawBase (no hashtags)
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
        primarySender.Setup(s => s.MessageMaxLenght).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLenght).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "feed", Link = "x", Title = "t" } };
        var baseSummary = new string('A', 200);
        var sharedImage = new byte[] { 9, 8, 7 };

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), 700, It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(sharedImage);

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT — image generated once and shared (same reference)
        Assert.Equal(2, posts.Count);
        Assert.True(posts.ContainsKey(SenderPlatform.X));
        Assert.True(posts.ContainsKey(SenderPlatform.LinkedIn));
        Assert.Same(posts[SenderPlatform.X]!.Image, posts[SenderPlatform.LinkedIn]!.Image);
        _mockImageProvider.Verify(
            s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_ReturnsNullEntry_WhenReSummarisationFails()
    {
        // ARRANGE — base 500 > secondary 280; re-summarisation returns empty
        var primarySender   = new Mock<ISender>();
        var secondarySender = new Mock<ISender>();
        primarySender.Setup(s => s.Platform).Returns(SenderPlatform.X);
        primarySender.Setup(s => s.MessageMaxLenght).Returns(700);
        secondarySender.Setup(s => s.Platform).Returns(SenderPlatform.LinkedIn);
        secondarySender.Setup(s => s.MessageMaxLenght).Returns(280);

        var fakeFeeds   = new List<RSSFeed> { new() { Content = "feed", Link = "x", Title = "t" } };
        var baseSummary = new string('A', 500);

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), 700, It.IsAny<CancellationToken>()))
            .ReturnsAsync(baseSummary);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(baseSummary, 280, It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty); // re-summarisation fails
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateMultiSenderOrchestrator(
            new List<ISender> { primarySender.Object, secondarySender.Object }.AsReadOnly());

        // ACT
        var posts = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Equal(2, posts.Count);
        Assert.True(posts.ContainsKey(SenderPlatform.X));
        Assert.True(posts.ContainsKey(SenderPlatform.LinkedIn));
        Assert.NotNull(posts[SenderPlatform.X]);       // primary OK
        Assert.Null(posts[SenderPlatform.LinkedIn]);   // secondary failed → null entry
    }

    // ---------------------------------------------------------------------------
    // Step 1 — AcquireFeedContentAsync failure paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound()
    {
        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(new List<RSSFeed>());

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockTextProvider.Verify(s => s.GetSummaryAsync(
            It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_FeedUrlProviderReturnsEmptyList()
    {
        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(new List<string>());

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()),
            Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Step 2 — GenerateRawSummaryAsync failure paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails()
    {
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockImageProvider.Verify(s => s.GenerateImageAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Step 3 — ApplyTagReplacements (single sender)
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_CallTagReplacementProvider_ExactlyOnce_WhenOrchestrationSucceeds()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary text";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
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

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1, 2, 3 });

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Contains("#Bitcoin", result[SenderPlatform.X]!.Content);
        Assert.Contains("#BTC",     result[SenderPlatform.X]!.Content);
        Assert.Contains("#FED",     result[SenderPlatform.X]!.Content);
        Assert.Single(System.Text.RegularExpressions.Regex.Matches(result[SenderPlatform.X]!.Content, "#Bitcoin"));
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithUnmodifiedContent_When_ProviderReturnsEmptyReplacements()
    {
        _mockTagReplacementProvider.Setup(p => p.GetReplacements())
            .Returns(new Dictionary<string, string>());

        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "bitcoin news", Link = "https://bitcoin.org/" } };
        var fakeSummary = "bitcoin summary";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Equal(fakeSummary, result[SenderPlatform.X]!.Content);
    }

    // ---------------------------------------------------------------------------
    // Image paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<byte>());

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

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

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Image generation failed"));

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

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

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);

        var orchestrator = new FeedOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            _mockTextProvider.Object, imageProvider: null);

        var result = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Null(result[SenderPlatform.X]!.Image);
        Assert.True(orchestrator.SendIt);
        _mockTextProvider.Verify(s => s.GetImagePromptAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Guard paths — null providers
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_TextProviderIsNull()
    {
        var orchestrator = new FeedOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            textProvider: null, imageProvider: null);

        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()),
            Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_SenderIsNull()
    {
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);

        // Empty sender list — _sender will be null
        var orchestrator = new FeedOrchestrator(
            new List<ISender>().AsReadOnly(),
            _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            _mockTextProvider.Object, _mockImageProvider.Object);

        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockTextProvider.Verify(s => s.GetSummaryAsync(
            It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Image prompt fallback
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsEmpty()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Fallback summary used as prompt";
        var fakeImage   = new byte[] { 9, 8, 7 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Equal(fakeImage, result[SenderPlatform.X]!.Image);
        _mockImageProvider.Verify(
            s => s.GenerateImageAsync(fakeSummary, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace()
    {
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Fallback summary";
        var fakeImage   = new byte[] { 1 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("   ");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.True(result.ContainsKey(SenderPlatform.X));
        Assert.Equal(fakeImage, result[SenderPlatform.X]!.Image);
        _mockImageProvider.Verify(
            s => s.GenerateImageAsync(fakeSummary, It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
