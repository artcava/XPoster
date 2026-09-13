using XPoster.Services;

namespace XPoster.Tests.Extensions;

public class HttpResponseBodySanitizerTests
{
    private readonly HttpResponseBodySanitizer _sanitizer = new();

    // ---------------------------------------------------------------
    // Bearer tokens
    // ---------------------------------------------------------------

    [Fact]
    public void Sanitize_MasksBearerTokenInHeader()
    {
        var input = "Authorization: Bearer abc123.h4t5";
        var result = _sanitizer.Sanitize(input);

        Assert.DoesNotContain("abc123.h4t5", result);
        Assert.Contains("Bearer ***", result);
    }

    [Fact]
    public void Sanitize_MasksBearerTokenInJson()
    {
        var input = "{\"error\":{\"message\":\"Authorization: Bearer tok123\",\"type\":\"invalid\"}}";
        var result = _sanitizer.Sanitize(input);

        Assert.DoesNotContain("tok123", result);
        Assert.Contains("Bearer ***", result);
    }

    // ---------------------------------------------------------------
    // API keys
    // ---------------------------------------------------------------

    [Fact]
    public void Sanitize_MasksJsonApiKey()
    {
        var input = "{\"api_key\":\"secretKey12345\"}";
        var result = _sanitizer.Sanitize(input);

        Assert.DoesNotContain("secretKey12345", result);
        Assert.Contains("***", result);
    }

    [Fact]
    public void Sanitize_MasksApiKeyHeaderWithColon()
    {
        var input = "\"X-Api-Key\": \"abcdef1234\"";
        var result = _sanitizer.Sanitize(input);

        Assert.DoesNotContain("abcdef1234", result);
        Assert.Contains("***", result);
    }

    // ---------------------------------------------------------------
    // Access / refresh / client secret tokens
    // ---------------------------------------------------------------

    [Fact]
    public void Sanitize_MasksAccessTokenJsonField()
    {
        var input = "{\"access_token\":\"tok1234567890abc\"}";
        var result = _sanitizer.Sanitize(input);

        Assert.DoesNotContain("tok1234567890abc", result);
        Assert.Contains("access_token=***", result);
    }

    [Fact]
    public void Sanitize_MasksRefreshTokenField()
    {
        var input = "{\"refresh_token\":\"refreshTokValue99\"}";
        var result = _sanitizer.Sanitize(input);

        Assert.DoesNotContain("refreshTokValue99", result);
        Assert.Contains("refresh_token=***", result);
    }

    // ---------------------------------------------------------------
    // Does not break non-secret text
    // ---------------------------------------------------------------

    [Fact]
    public void Sanitize_LeavesCleanTextUnchanged()
    {
        var input = "{\"status\":\"ok\",\"id\":12345}";
        var result = _sanitizer.Sanitize(input);

        Assert.Equal(input, result);
    }

    // ---------------------------------------------------------------
    // Empty / null
    // ---------------------------------------------------------------

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Sanitize_ReturnsEmptyForNullOrEmpty(string? input)
    {
        Assert.Equal(input, _sanitizer.Sanitize(input!));
    }

    // ---------------------------------------------------------------
    // URL query-string masking
    // ---------------------------------------------------------------

    [Fact]
    public void SanitizeUrl_MasksAccessTokenQuery()
    {
        var url = "https://graph.facebook.com/v23.0/me/photos?access_token=abcToken123&fields=id";
        var result = _sanitizer.SanitizeUrl(url);

        Assert.DoesNotContain("abcToken123", result);
        Assert.Contains("access_token=***", result);
        Assert.Contains("fields=id", result);
    }

    [Fact]
    public void SanitizeUrl_LeavesNonSensitiveQueryUntouched()
    {
        var url = "https://api.x.com/v2/tweets?q=hello&count=10";
        var result = _sanitizer.SanitizeUrl(url);

        Assert.Equal(url, result);
    }

    [Fact]
    public void SanitizeUrl_NoQuery_ReturnsAsIs()
    {
        var url = "https://api.x.com/v2/tweets";
        var result = _sanitizer.SanitizeUrl(url);

        Assert.Equal(url, result);
    }

    [Theory]
    [InlineData("ACCESS_TOKEN")]
    [InlineData("Api_Key")]
    public void SanitizeUrl_CaseInsensitiveKeys(string key)
    {
        var url = $"https://api.example.com?{key}=mySecret12345";
        var result = _sanitizer.SanitizeUrl(url);

        Assert.DoesNotContain("mySecret12345", result);
        Assert.Contains("***", result);
    }
}