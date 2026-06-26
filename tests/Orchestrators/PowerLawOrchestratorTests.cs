using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Orchestrators;

namespace XPoster.Tests.Orchestrators;

public class PowerLawOrchestratorTests
{
    private readonly Mock<ISender>                        _mockSender;
    private readonly Mock<ILogger<PowerLawOrchestrator>>  _mockLogger;
    private readonly Mock<ICryptoService>                 _mockCryptoService;
    private readonly Mock<ITimeProvider>                  _mockTimeProvider;

    public PowerLawOrchestratorTests()
    {
        _mockSender        = new Mock<ISender>();
        _mockLogger        = new Mock<ILogger<PowerLawOrchestrator>>();
        _mockCryptoService = new Mock<ICryptoService>();
        _mockTimeProvider  = new Mock<ITimeProvider>();
    }

    private PowerLawOrchestrator CreateOrchestrator(IReadOnlyList<ISender>? senders = null) =>
        new(
            senders ?? new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            _mockCryptoService.Object,
            _mockTimeProvider.Object);

    // ---------------------------------------------------------------------------
    // Happy path — single sender
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateAsync_Should_CreateCorrectMessage_WithActualValue()
    {
        var fixedDate     = new DateTime(2025, 7, 21);
        decimal fakeBtcPrice = 65000.00m;
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(fakeBtcPrice);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);

        var posts = await CreateOrchestrator().OrchestrateAsync();

        Assert.Single(posts);
        Assert.NotNull(posts[0]);
        Assert.Contains("Value of #BTC for the #powerlaw today would be:", posts[0]!.Content);
        Assert.Contains("%", posts[0]!.Content);
        Assert.DoesNotContain(Post.Firm, posts[0]!.Content);
        _mockCryptoService.Verify(s => s.GetCryptoValue("BTC"), Times.Once);
    }

    [Fact]
    public async Task GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate()
    {
        var fixedDate    = new DateTime(2025, 7, 21);
        decimal fakePrice = 65000.00m;
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(fakePrice);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);

        var posts = await CreateOrchestrator().OrchestrateAsync();

        var expectedDays  = (fixedDate.Date - new DateTime(2009, 1, 3)).Days;
        var expectedValue = Math.Pow(10, -17) * Math.Pow(expectedDays, 5.83d);

        Assert.Single(posts);
        Assert.Contains($"would be: {expectedValue:F2} #USD", posts[0]!.Content);
    }

    // ---------------------------------------------------------------------------
    // Fan-out: same post broadcast to all senders
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_BroadcastsSamePost_ToAllSenders()
    {
        var sender2 = new Mock<ISender>();
        var sender3 = new Mock<ISender>();
        var senders = new List<ISender>
        {
            _mockSender.Object,
            sender2.Object,
            sender3.Object
        }.AsReadOnly();

        var fixedDate = new DateTime(2025, 7, 21);
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(65000m);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);

        var posts = await CreateOrchestrator(senders).OrchestrateAsync();

        // One entry per sender, all pointing to the same Post instance
        Assert.Equal(3, posts.Count);
        Assert.NotNull(posts[0]);
        Assert.Same(posts[0], posts[1]);
        Assert.Same(posts[0], posts[2]);
    }

    // ---------------------------------------------------------------------------
    // Failure paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis()
    {
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(new DateTime(2008, 12, 31));

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
    }

    [Fact]
    public async Task GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully()
    {
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(new DateTime(2025, 7, 21));
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(0m);

        var posts = await CreateOrchestrator().OrchestrateAsync();

        Assert.Single(posts);
        Assert.NotNull(posts[0]);
        Assert.DoesNotContain("%", posts[0]!.Content);
    }

    [Theory]
    [InlineData(-100.50)]
    [InlineData(0)]
    public async Task GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(decimal cryptoValue)
    {
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(new DateTime(2025, 7, 21));
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(cryptoValue);

        var posts = await CreateOrchestrator().OrchestrateAsync();

        Assert.Single(posts);
        Assert.NotNull(posts[0]);
    }
}
