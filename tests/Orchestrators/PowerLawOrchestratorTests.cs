using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Orchestrators;

namespace XPoster.Tests.Orchestrators;

public class PowerLawOrchestratorTests
{
    private readonly Mock<ISender> _mockSender;
    private readonly Mock<ILogger<PowerLawOrchestrator>> _mockLogger;
    private readonly Mock<ICryptoService> _mockCryptoService;
    private readonly Mock<ITimeProvider> _mockTimeProvider;

    public PowerLawOrchestratorTests()
    {
        _mockSender = new Mock<ISender>();
        _mockLogger = new Mock<ILogger<PowerLawOrchestrator>>();
        _mockCryptoService = new Mock<ICryptoService>();
        _mockTimeProvider = new Mock<ITimeProvider>();
    }

    [Fact]
    public async Task GenerateAsync_Should_CreateCorrectMessage_WithActualValue()
    {
        var fixedDate = new DateTime(2025, 7, 21);
        decimal fakeBtcPrice = 65000.00m;
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(fakeBtcPrice);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);

        var orchestrator = new PowerLawOrchestrator(_mockSender.Object, _mockLogger.Object, _mockCryptoService.Object, _mockTimeProvider.Object);

        var message = await orchestrator.OrchestrateAsync();

        Assert.NotNull(message);
        Assert.Contains("Value of #BTC for the #powerlaw today would be:", message.Content);
        Assert.Contains("% of actual", message.Content);
        _mockCryptoService.Verify(s => s.GetCryptoValue("BTC"), Times.Once);
    }

    [Fact]
    public async Task GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate()
    {
        var fixedDate = new DateTime(2025, 7, 21);
        decimal fakeBtcPrice = 65000.00m;

        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(fakeBtcPrice);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);

        var orchestrator = new PowerLawOrchestrator(_mockSender.Object, _mockLogger.Object, _mockCryptoService.Object, _mockTimeProvider.Object);

        var message = await orchestrator.OrchestrateAsync();

        var expectedDays = (fixedDate.Date - new DateTime(2009, 1, 3)).Days;
        var expectedValue = Math.Pow(10, -17) * Math.Pow(expectedDays, 5.83d);

        Assert.NotNull(message);
        Assert.Contains($"would be: {expectedValue:F2} #USD", message.Content);
    }

    [Fact]
    public async Task GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis()
    {
        var invalidDate = new DateTime(2008, 12, 31);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(invalidDate);

        var orchestrator = new PowerLawOrchestrator(
            _mockSender.Object,
            _mockLogger.Object,
            _mockCryptoService.Object,
            _mockTimeProvider.Object);

        var result = await orchestrator.OrchestrateAsync();

        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
    }

    [Fact]
    public async Task GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully()
    {
        var fixedDate = new DateTime(2025, 7, 21);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(0m);

        var orchestrator = new PowerLawOrchestrator(
            _mockSender.Object,
            _mockLogger.Object,
            _mockCryptoService.Object,
            _mockTimeProvider.Object);

        var result = await orchestrator.OrchestrateAsync();

        Assert.NotNull(result);
        Assert.DoesNotContain("% of actual", result.Content);
    }

    [Theory]
    [InlineData(-100.50)]
    [InlineData(0)]
    public async Task GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(decimal cryptoValue)
    {
        var fixedDate = new DateTime(2025, 7, 21);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate);
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(cryptoValue);

        var orchestrator = new PowerLawOrchestrator(
            _mockSender.Object,
            _mockLogger.Object,
            _mockCryptoService.Object,
            _mockTimeProvider.Object);

        var result = await orchestrator.OrchestrateAsync();

        Assert.NotNull(result);
    }
}
