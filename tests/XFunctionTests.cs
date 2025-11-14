using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Tests;

public class XFunctionTests
{
    private readonly Mock<IGeneratorFactory> _mockFactory;
    private readonly Mock<ILogger<XFunction>> _mockLogger;
    private readonly Mock<BaseGenerator> _mockGenerator;

    public XFunctionTests()
    {
        // Inizializziamo i mock delle dipendenze dirette di XFunction
        _mockFactory = new Mock<IGeneratorFactory>();
        _mockLogger = new Mock<ILogger<XFunction>>();

        // Creiamo un mock per il generatore che la factory restituirà.
        // Usiamo MockBehavior.Strict per assicurarci che solo i metodi configurati vengano chiamati.
        // I due null nel costruttore sono per le dipendenze di BaseGenerator (sender e logger),
        // che non ci interessano in questo test.
        _mockGenerator = new Mock<BaseGenerator>(MockBehavior.Strict, null, null);
    }

    [Fact]
    public async Task Run_Should_DoNothing_When_GeneratorIsDisabled()
    {
        // ARRANGE (Prepara lo scenario)

        // 1. Configura il generatore finto per essere disabilitato
        _mockGenerator.Setup(g => g.SendIt).Returns(false);
        _mockGenerator.Setup(g => g.Name).Returns("DisabledTestGenerator");

        // 2. Configura la factory finta per restituire il nostro generatore disabilitato
        _mockFactory.Setup(f => f.Generate()).Returns(_mockGenerator.Object);

        // 3. Crea l'istanza della funzione con le dipendenze finte
        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);

        // ACT (Esegui l'azione)
        await function.Run(null); // Il TimerInfo può essere null per questo test

        // ASSERT (Verifica il risultato)

        // Verifichiamo che i metodi per generare e inviare il messaggio
        // non siano MAI stati chiamati, perché SendIt era false.
        _mockGenerator.Verify(g => g.GenerateAsync(), Times.Never());
        _mockGenerator.Verify(g => g.PostAsync(It.IsAny<Post>()), Times.Never());
    }
    [Fact]
    public async Task Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()
    {
        // ARRANGE
        var testMessage = new Post { Content = "Test" };

        // 1. Configura il generatore finto per essere abilitato
        _mockGenerator.Setup(g => g.SendIt).Returns(true);
        _mockGenerator.Setup(g => g.Name).Returns("EnabledTestGenerator");

        // 2. Configura i metodi del generatore per restituire valori e completare l'esecuzione
        _mockGenerator.Setup(g => g.GenerateAsync()).ReturnsAsync(testMessage);
        _mockGenerator.Setup(g => g.PostAsync(testMessage)).ReturnsAsync(true);

        // 3. Configura la factory finta per restituire il nostro generatore abilitato
        _mockFactory.Setup(f => f.Generate()).Returns(_mockGenerator.Object);

        // 4. Crea l'istanza della funzione
        var function = new XFunction(_mockFactory.Object, _mockLogger.Object);

        // ACT
        await function.Run(null);

        // ASSERT
        // Verifichiamo che i metodi per generare e inviare il messaggio
        // siano stati chiamati ESATTAMENTE una volta.
        _mockGenerator.Verify(g => g.GenerateAsync(), Times.Once());
        _mockGenerator.Verify(g => g.PostAsync(testMessage), Times.Once());
    }
}