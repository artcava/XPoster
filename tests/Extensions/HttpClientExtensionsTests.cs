using Microsoft.Extensions.DependencyInjection;
using XPoster.Extensions;

namespace XPoster.Tests.Extensions;

public class HttpClientExtensionsTests
{
    private static readonly string[] ExpectedClientNames =
    [
        "OpenAI",
        "AzureFoundry",
        "DeepSeek",
        "Perplexity",
        "LinkedIn",
        "Instagram",
        "Facebook",
        "FalAi",
        "Feed"
    ];

    [Fact]
    public void AddHttpClients_ReturnsSameServiceCollection()
    {
        var services = new ServiceCollection();

        var returned = services.AddHttpClients();

        Assert.Same(services, returned);
    }

    [Fact]
    public void AddHttpClients_RegistersIHttpClientFactory()
    {
        var services = new ServiceCollection();

        services.AddHttpClients();
        using var provider = services.BuildServiceProvider();

        var factory = provider.GetService<IHttpClientFactory>();

        Assert.NotNull(factory);
    }

    [Theory]
    [InlineData("OpenAI")]
    [InlineData("AzureFoundry")]
    [InlineData("DeepSeek")]
    [InlineData("Perplexity")]
    [InlineData("LinkedIn")]
    [InlineData("Instagram")]
    [InlineData("Facebook")]
    [InlineData("FalAi")]
    [InlineData("Feed")]
    public void AddHttpClients_RegistersExpectedNamedClients(string clientName)
    {
        var services = new ServiceCollection();

        services.AddHttpClients();
        using var provider = services.BuildServiceProvider();

        var factory = provider.GetRequiredService<IHttpClientFactory>();
        var client = factory.CreateClient(clientName);

        Assert.NotNull(client);
    }

    [Fact]
    public void AddHttpClients_CanCreateAllExpectedNamedClients()
    {
        var services = new ServiceCollection();

        services.AddHttpClients();
        using var provider = services.BuildServiceProvider();

        var factory = provider.GetRequiredService<IHttpClientFactory>();

        foreach (var clientName in ExpectedClientNames)
        {
            var client = factory.CreateClient(clientName);
            Assert.NotNull(client);
        }
    }
}