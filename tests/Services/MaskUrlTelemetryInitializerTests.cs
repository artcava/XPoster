using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Moq;
using Microsoft.Extensions.Logging;
namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="MaskUrlTelemetryInitializer"/>.
/// Covers: non-Http dependency (skip), Http non-Facebook (skip),
/// Http Facebook with access_token (masked), without access_token (unchanged),
/// empty Data (skip), malformed URL (fallback), null telemetry type (skip).
/// </summary>
public class MaskUrlTelemetryInitializerTests
{
    private readonly MaskUrlTelemetryInitializer _sut = new(new Mock<ILogger<MaskUrlTelemetryInitializer>>().Object);

    [Fact]
    public void Initialize_WhenTelemetryIsNotDependency_DoesNothing()
    {
        var telemetry = new Mock<ITelemetry>();
        _sut.Initialize(telemetry.Object);
    }

    [Fact]
    public void Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData()
    {
        var dep = new DependencyTelemetry
        {
            Type = "SQL",
            Data = "SELECT * FROM table WHERE access_token=secret"
        };
        _sut.Initialize(dep);
        Assert.Equal("SELECT * FROM table WHERE access_token=secret", dep.Data);
    }

    [Fact]
    public void Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData()
    {
        var dep = new DependencyTelemetry
        {
            Type = "Http",
            Data = "https://api.twitter.com/2/tweets?access_token=mytoken"
        };
        _sut.Initialize(dep);
        Assert.Equal("https://api.twitter.com/2/tweets?access_token=mytoken", dep.Data);
    }

    [Fact]
    public void Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged()
    {
        const string url = "https://graph.facebook.com/v20.0/me/photos?limit=10";
        var dep = new DependencyTelemetry { Type = "Http", Target = url, Data = url };
        _sut.Initialize(dep);
        Assert.Equal(url, dep.Data);
    }

    [Fact]
    public void Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked()
    {
        const string url = "https://graph.facebook.com/v20.0/123/photos?access_token=EAABsecrettoken&limit=10";
        var dep = new DependencyTelemetry { Type = "Http", Target = url, Data = url };
        _sut.Initialize(dep);

        Assert.DoesNotContain("EAABsecrettoken", dep.Data);
        Assert.Contains("MASKED", dep.Data);
        Assert.Contains("graph.facebook.com", dep.Data);
        Assert.Contains("limit=10", dep.Data);
    }

    [Fact]
    public void Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked()
    {
        const string url = "https://graph.facebook.com/v20.0/me/feed?access_token=supersecret";
        var dep = new DependencyTelemetry { Type = "Http", Target = url, Data = url };
        _sut.Initialize(dep);

        Assert.DoesNotContain("supersecret", dep.Data);
        Assert.Contains("MASKED", dep.Data);
    }

    [Fact]
    public void Initialize_WhenDataIsEmpty_DoesNotThrow()
    {
        var dep = new DependencyTelemetry { Type = "Http", Target = string.Empty, Data = string.Empty };
        var ex = Record.Exception(() => _sut.Initialize(dep));
        Assert.Null(ex);
        Assert.Equal(string.Empty, dep.Data);
    }

    [Fact]
    public void Initialize_WhenDataIsNull_DoesNotThrow()
    {
        var dep = new DependencyTelemetry { Type = "Http", Target = null!, Data = null! };
        var ex = Record.Exception(() => _sut.Initialize(dep));
        Assert.Null(ex);
    }

    [Fact]
    public void Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged()
    {
        var original = "graph.facebook.com/not-a-valid-url with spaces?access_token=secret";

        var dep = new DependencyTelemetry
        {
            Type = "Http",
            Data = original
        };

        _sut.Initialize(dep);

        Assert.Equal(original, dep.Data);
    }

    [Fact]
    public void Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged()
    {
        const string url = "https://graph.facebook.com/v20.0/me";
        var dep = new DependencyTelemetry { Type = "Http", Target = url, Data = url };
        _sut.Initialize(dep);
        Assert.Equal(url, dep.Data);
    }

    [Fact]
    public void Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode()
    {
        const string url = "https://graph.facebook.com/v20.0/me/feed?access_token=%5BMASKED%5D";
        var dep = new DependencyTelemetry { Type = "Http", Target = url, Data = url };
        _sut.Initialize(dep);
        Assert.Contains("MASKED", dep.Data);
        Assert.DoesNotContain("MASKEDMASKED", dep.Data);
    }
}