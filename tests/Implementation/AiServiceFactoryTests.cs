using Microsoft.Extensions.DependencyInjection;
using Moq;
using XPoster.Abstraction;
using XPoster.Implementation;

namespace XPoster.Tests.Implementation;

public class AiServiceFactoryTests
{
    private readonly Mock<IServiceProvider> _serviceProvider;

    public AiServiceFactoryTests()
    {
        _serviceProvider = new Mock<IServiceProvider>();
    }

    [Fact]
    public void GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable()
    {
        // ARRANGE
        var aiService = new Mock<IAiService>();
        _serviceProvider
            .Setup(sp => sp.GetService(typeof(XPoster.Services.OpenAiService)))
            .Returns(aiService.Object);

        var factory = new AiServiceFactory(_serviceProvider.Object);

        // ACT
        var result = factory.GetByProvider(AiProvider.OpenAi);

        // ASSERT
        Assert.Same(aiService.Object, result);
    }

    [Fact]
    public void GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped()
    {
        // ARRANGE
        var factory = new AiServiceFactory(_serviceProvider.Object);

        // ACT
        var action = () => factory.GetByProvider(AiProvider.Perplexity);

        // ASSERT
        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Contains("No IAiService registered", exception.Message);
    }

    [Fact]
    public void GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved()
    {
        // ARRANGE
        _serviceProvider
            .Setup(sp => sp.GetService(typeof(XPoster.Services.OpenAiService)))
            .Returns((object?)null);

        var factory = new AiServiceFactory(_serviceProvider.Object);

        // ACT
        var action = () => factory.GetByProvider(AiProvider.OpenAi);

        // ASSERT
        var exception = Assert.Throws<InvalidOperationException>(action);
        Assert.Contains("Could not resolve IAiService", exception.Message);
    }
}
