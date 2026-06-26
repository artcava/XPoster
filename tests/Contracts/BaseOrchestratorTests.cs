using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Tests.Contracts;

/// <summary>
/// Tests for the shared PostAsync logic in BaseOrchestrator.
/// Uses a minimal concrete subclass (TestOrchestrator) to exercise all guard branches
/// and the new parallel fan-out dispatch semantics.
/// </summary>
public class BaseOrchestratorTests
{
    // Minimal concrete subclass — accepts a sender list and lets us control SendIt / ProduceImage per test
    private class TestOrchestrator : BaseOrchestrator
    {
        private bool _sendIt;
        public override string Name => "TestOrchestrator";
        public override bool SendIt { get => _sendIt; set => _sendIt = value; }
        public override bool ProduceImage { get; set; }
        public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
            new List<SenderPlatform>().AsReadOnly();
        public override Task<IReadOnlyList<Post?>> OrchestrateAsync() =>
            Task.FromResult<IReadOnlyList<Post?>>(Array.Empty<Post?>());

        public TestOrchestrator(
            IReadOnlyList<ISender> senders,
            ILogger logger,
            bool sendIt = true,
            bool produceImage = false)
            : base(senders, logger)
        {
            _sendIt = sendIt;
            ProduceImage = produceImage;
        }
    }

    private readonly Mock<ISender> _mockSender;
    private readonly Mock<ILogger> _mockLogger;

    public BaseOrchestratorTests()
    {
        _mockSender = new Mock<ISender>();
        _mockLogger = new Mock<ILogger>();
    }

    // ---------------------------------------------------------------------------
    // Guard: SendIt = false
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task PostAsync_ReturnsFalse_When_SendIt_IsFalse()
    {
        var orchestrator = new TestOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            sendIt: false);

        var result = await orchestrator.PostAsync(new List<Post?> { new Post { Content = "Hello" } }.AsReadOnly());

        Assert.False(result);
        _mockSender.Verify(s => s.SendAsync(It.IsAny<Post>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Guard: empty sender list
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task PostAsync_ReturnsFalse_WhenSenderListIsEmpty()
    {
        var orchestrator = new TestOrchestrator(
            new List<ISender>().AsReadOnly(),
            _mockLogger.Object);

        var result = await orchestrator.PostAsync(new List<Post?> { new Post { Content = "Hello" } }.AsReadOnly());

        Assert.False(result);
    }

    // ---------------------------------------------------------------------------
    // Guard: null post at position i
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task PostAsync_SkipsNullPost_ReturnsFalse()
    {
        var orchestrator = new TestOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object);

        var result = await orchestrator.PostAsync(new List<Post?> { null }.AsReadOnly());

        Assert.False(result);
        _mockSender.Verify(s => s.SendAsync(It.IsAny<Post>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Guard: empty / whitespace content
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task PostAsync_ReturnsFalse_When_Content_IsEmpty()
    {
        var orchestrator = new TestOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object);

        var result = await orchestrator.PostAsync(new List<Post?> { new Post { Content = string.Empty } }.AsReadOnly());

        Assert.False(result);
        _mockSender.Verify(s => s.SendAsync(It.IsAny<Post>()), Times.Never);
    }

    [Fact]
    public async Task PostAsync_ReturnsFalse_When_Content_IsWhiteSpace()
    {
        var orchestrator = new TestOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object);

        var result = await orchestrator.PostAsync(new List<Post?> { new Post { Content = "   " } }.AsReadOnly());

        Assert.False(result);
        _mockSender.Verify(s => s.SendAsync(It.IsAny<Post>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Happy path: all senders succeed
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task PostAsync_DispatchesEachPostToAlignedSender()
    {
        var mockSender1 = new Mock<ISender>();
        var mockSender2 = new Mock<ISender>();
        mockSender1.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);
        mockSender2.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);

        var post1 = new Post { Content = "Post for sender 1" };
        var post2 = new Post { Content = "Post for sender 2" };

        var orchestrator = new TestOrchestrator(
            new List<ISender> { mockSender1.Object, mockSender2.Object }.AsReadOnly(),
            _mockLogger.Object);

        var result = await orchestrator.PostAsync(new List<Post?> { post1, post2 }.AsReadOnly());

        Assert.True(result);
        mockSender1.Verify(s => s.SendAsync(post1), Times.Once);
        mockSender2.Verify(s => s.SendAsync(post2), Times.Once);
    }

    [Fact]
    public async Task PostAsync_ReturnsTrue_When_AllConditionsMet()
    {
        _mockSender.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);
        var orchestrator = new TestOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object);
        var post = new Post { Content = "Hello" };

        var result = await orchestrator.PostAsync(new List<Post?> { post }.AsReadOnly());

        Assert.True(result);
        _mockSender.Verify(s => s.SendAsync(post), Times.Once);
    }

    // ---------------------------------------------------------------------------
    // Partial failure: one sender fails → false overall
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task PostAsync_ReturnsFalse_WhenOneSenderFails()
    {
        var mockSender1 = new Mock<ISender>();
        var mockSender2 = new Mock<ISender>();
        mockSender1.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);
        mockSender2.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(false);

        var orchestrator = new TestOrchestrator(
            new List<ISender> { mockSender1.Object, mockSender2.Object }.AsReadOnly(),
            _mockLogger.Object);

        var result = await orchestrator.PostAsync(new List<Post?>
        {
            new Post { Content = "OK" },
            new Post { Content = "Fail" }
        }.AsReadOnly());

        Assert.False(result);
    }

    // ---------------------------------------------------------------------------
    // ProduceImage warning
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()
    {
        _mockSender.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);
        var orchestrator = new TestOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            produceImage: true);
        var post = new Post { Content = "Hello", Image = null };

        var result = await orchestrator.PostAsync(new List<Post?> { post }.AsReadOnly());

        // Warning does not block posting
        Assert.True(result);
        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("expected an image")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent()
    {
        _mockSender.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);
        var orchestrator = new TestOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            produceImage: true);
        var post = new Post { Content = "Hello", Image = new byte[] { 1, 2, 3 } };

        var result = await orchestrator.PostAsync(new List<Post?> { post }.AsReadOnly());

        Assert.True(result);
        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Never);
    }

    [Fact]
    public async Task PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()
    {
        _mockSender.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(false);
        var orchestrator = new TestOrchestrator(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object);
        var post = new Post { Content = "Hello" };

        var result = await orchestrator.PostAsync(new List<Post?> { post }.AsReadOnly());

        Assert.False(result);
    }
}
