using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Implementation;

namespace XPoster.Tests;

public class PowerLawGeneratorTests
{
    private readonly Mock<ISender> _mockSender;
    private readonly Mock<ILogger<PowerLawGenerator>> _mockLogger;
    private readonly Mock<ICryptoService> _mockCryptoService;
    private readonly Mock<ITimeProvider> _mockTimeProvider;

    public PowerLawGeneratorTests()
    {
        _mockSender = new Mock<ISender>();
        _mockLogger = new Mock<ILogger<PowerLawGenerator>>();
        _mockCryptoService = new Mock<ICryptoService>();
        _mockTimeProvider = new Mock<ITimeProvider>();
    }

    [Fact]
    public async Task GenerateAsync_Should_CreateCorrectMessage_WithActualValue()
    {
        // ARRANGE
        // Simuliamo la risposta del nostro nuovo servizio
        var fixedDate = new DateTime(2025, 7, 21);
        decimal fakeBtcPrice = 65000.00m;
        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(fakeBtcPrice);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate); // Fornisci una data fissa

        var generator = new PowerLawGenerator(_mockSender.Object, _mockLogger.Object, _mockCryptoService.Object, _mockTimeProvider.Object);

        // ACT
        var message = await generator.GenerateAsync();

        // ASSERT
        Assert.NotNull(message);
        // Verifichiamo che il messaggio contenga sia il valore della powerlaw
        Assert.Contains("Value of #BTC for the #powerlaw today would be:", message.Content);
        // E che contenga anche il calcolo basato sul valore reale (finto) che abbiamo fornito
        Assert.Contains("% of actual", message.Content);
        // Verifichiamo che il nostro servizio sia stato chiamato
        _mockCryptoService.Verify(s => s.GetCryptoValue("BTC"), Times.Once);
    }

    [Fact]
    public async Task GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate()
    {
        // ARRANGE
        var fixedDate = new DateTime(2025, 7, 21);
        decimal fakeBtcPrice = 65000.00m;

        _mockCryptoService.Setup(s => s.GetCryptoValue("BTC")).ReturnsAsync(fakeBtcPrice);
        _mockTimeProvider.Setup(t => t.GetCurrentTime()).Returns(fixedDate); // Fornisci una data fissa

        var generator = new PowerLawGenerator(_mockSender.Object, _mockLogger.Object, _mockCryptoService.Object, _mockTimeProvider.Object);

        // ACT
        var message = await generator.GenerateAsync();

        // ASSERT
        // Ora possiamo calcolare il valore atteso e verificarlo!
        var expectedDays = (fixedDate.Date - new DateTime(2009, 1, 3)).Days;
        var expectedValue = Math.Pow(10, -17) * Math.Pow(expectedDays, 5.83d);

        Assert.NotNull(message);
        Assert.Contains($"would be: {expectedValue:F2} #USD", message.Content);
    }
}
