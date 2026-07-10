using Microsoft.Extensions.DependencyInjection;
using XPoster.Contracts;
using XPoster.Extensions;
using XPoster.Services;

namespace XPoster.Tests.Extensions;

public class AiProviderServiceCollectionExtensionsTests
{
    [Fact]
    public void AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider()
    {
        var services = new ServiceCollection();

        services.AddXPosterAiProviders();

        AssertKeyedTransient<ITextToTextProvider, OpenAiService>(services, AiProvider.OpenAi);
        AssertKeyedTransient<ITextToImageProvider, OpenAiService>(services, AiProvider.OpenAi);
    }

    [Fact]
    public void AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider()
    {
        var services = new ServiceCollection();

        services.AddXPosterAiProviders();

        AssertKeyedTransient<ITextToTextProvider, AzureFoundryService>(services, AiProvider.AzureFoundry);
        AssertKeyedTransient<ITextToImageProvider, AzureFoundryService>(services, AiProvider.AzureFoundry);
    }

    [Fact]
    public void AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly()
    {
        var services = new ServiceCollection();

        services.AddXPosterAiProviders();

        AssertKeyedTransient<ITextToTextProvider, DeepSeekService>(services, AiProvider.DeepSeek);
        AssertNoKeyedRegistration<ITextToImageProvider>(services, AiProvider.DeepSeek);
    }

    [Fact]
    public void AddXPosterAiProviders_RegistersPerplexity_AsTextOnly()
    {
        var services = new ServiceCollection();

        services.AddXPosterAiProviders();

        AssertKeyedTransient<ITextToTextProvider, PerplexityService>(services, AiProvider.Perplexity);
        AssertNoKeyedRegistration<ITextToImageProvider>(services, AiProvider.Perplexity);
    }

    [Fact]
    public void AddXPosterAiProviders_RegistersFalAi_AsImageOnly()
    {
        var services = new ServiceCollection();

        services.AddXPosterAiProviders();

        AssertKeyedTransient<ITextToImageProvider, FalAiImageService>(services, AiProvider.FalAi);
        AssertNoKeyedRegistration<ITextToTextProvider>(services, AiProvider.FalAi);
    }

    [Fact]
    public void AddXPosterAiProviders_ReturnsSameServiceCollection()
    {
        var services = new ServiceCollection();

        var returned = services.AddXPosterAiProviders();

        Assert.Same(services, returned);
    }

    [Fact]
    public void AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices()
    {
        var services = new ServiceCollection();

        services.AddXPosterAiProviders();

        var keyedRegistrations = services.Count(static d => d.IsKeyedService);

        Assert.Equal(7, keyedRegistrations);
    }

    private static void AssertKeyedTransient<TService, TImplementation>(
        IServiceCollection services,
        AiProvider key)
        where TService : class
        where TImplementation : class, TService
    {
        var descriptor = services.SingleOrDefault(d =>
            d.IsKeyedService
            && d.ServiceType == typeof(TService)
            && Equals(d.ServiceKey, key));

        Assert.NotNull(descriptor);
        Assert.Equal(ServiceLifetime.Transient, descriptor!.Lifetime);
        Assert.Equal(typeof(TImplementation), descriptor.KeyedImplementationType);
        Assert.Null(descriptor.KeyedImplementationFactory);
        Assert.Null(descriptor.KeyedImplementationInstance);
    }

    private static void AssertNoKeyedRegistration<TService>(
        IServiceCollection services,
        AiProvider key)
        where TService : class
    {
        var descriptor = services.SingleOrDefault(d =>
            d.IsKeyedService
            && d.ServiceType == typeof(TService)
            && Equals(d.ServiceKey, key));

        Assert.Null(descriptor);
    }
}