using XPoster.Credentials;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Golden-vector tests for <see cref="XOAuth1Signer"/>, driven by the canonical
/// OAuth 1.0a photo example (https://oauth.net/core/1.0a/#signing_process).
/// </summary>
public class XOAuth1SignerTests
{
    private const string ConsumerKey = "dpf43f3p2l4k3l03";
    private const string ConsumerSecret = "kd94hf93k423kf44";
    private const string AccessToken = "nnch734d00sl2jdk";
    private const string AccessTokenSecret = "pfkkdhi9sl3r4s00";
    private const long Timestamp = 1191242096;
    private const string Nonce = "kllo9940pd9333jh";

    private static XCredentials BuildCredentials() => new()
    {
        XApiKey = ConsumerKey,
        XApiSecret = ConsumerSecret,
        XAccessToken = AccessToken,
        XAccessTokenSecret = AccessTokenSecret
    };

    [Theory]
    [InlineData("abcXYZ012", "abcXYZ012")]
    [InlineData("-_~.", "-_~.")]
    [InlineData("Hello World", "Hello%20World")]
    [InlineData("a=b&c", "a%3Db%26c")]
    [InlineData("100%25", "100%2525")]
    public void PercentEncode_InputValue_ReturnsExpectedEncoding(string input, string expected)
    {
        Assert.Equal(expected, XOAuth1Signer.PercentEncode(input));
    }

    [Fact]
    public void ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString()
    {
        var uri = new Uri("http://photos.example.net/photos?file=vacation.jpg&size=original");
        var parameters = BuildPhotoParameters();

        var baseString = XOAuth1Signer.ComputeSignatureBaseString("GET", uri, parameters);

        const string expected =
            "GET&http%3A%2F%2Fphotos.example.net%2Fphotos&file%3Dvacation.jpg" +
            "%26oauth_consumer_key%3Ddpf43f3p2l4k3l03" +
            "%26oauth_nonce%3Dkllo9940pd9333jh" +
            "%26oauth_signature_method%3DHMAC-SHA1" +
            "%26oauth_timestamp%3D1191242096" +
            "%26oauth_token%3Dnnch734d00sl2jdk" +
            "%26oauth_version%3D1.0" +
            "%26size%3Doriginal";

        Assert.Equal(expected, baseString);
    }

    [Fact]
    public void ComputeSignature_PhotoExample_ReturnsExpectedBase64()
    {
        var uri = new Uri("http://photos.example.net/photos?file=vacation.jpg&size=original");

        var signature = XOAuth1Signer.ComputeSignature(
            "GET",
            uri,
            BuildPhotoParameters(),
            ConsumerSecret,
            AccessTokenSecret);

        Assert.Equal("tR3+Ty81lMeYAr/Fid0kMTYa/WM=", signature);
    }

    [Fact]
    public void BuildAuthorizationHeader_PhotoExample_ContainsOAuthParameters()
    {
        var uri = new Uri("http://photos.example.net/photos?file=vacation.jpg&size=original");

        var header = XOAuth1Signer.BuildAuthorizationHeader(HttpMethod.Get, uri, BuildCredentials(), Timestamp, Nonce);

        Assert.StartsWith("OAuth ", header);
        Assert.Contains($"oauth_consumer_key=\"{ConsumerKey}\"", header);
        Assert.Contains($"oauth_nonce=\"{Nonce}\"", header);
        Assert.Contains("oauth_signature_method=\"HMAC-SHA1\"", header);
        Assert.Contains($"oauth_timestamp=\"{Timestamp}\"", header);
        Assert.Contains($"oauth_token=\"{AccessToken}\"", header);
        Assert.Contains("oauth_version=\"1.0\"", header);
        Assert.Contains("oauth_signature=\"tR3+Ty81lMeYAr/Fid0kMTYa/WM=\"", header);
    }

    [Fact]
    public void BuildAuthorizationHeader_PostToTweetsEndpoint_SignsOAuthOnlyParameters()
    {
        var uri = new Uri("https://api.twitter.com/2/tweets");

        var header = XOAuth1Signer.BuildAuthorizationHeader(HttpMethod.Post, uri, BuildCredentials(), Timestamp, Nonce);

        Assert.StartsWith("OAuth ", header);
        Assert.Contains($"oauth_signature=\"", header);
        Assert.Contains($"oauth_consumer_key=\"{ConsumerKey}\"", header);
        Assert.Contains($"oauth_token=\"{AccessToken}\"", header);
        Assert.DoesNotContain("file=", header);
    }

    private static Dictionary<string, string> BuildPhotoParameters() => new()
    {
        ["file"] = "vacation.jpg",
        ["oauth_consumer_key"] = ConsumerKey,
        ["oauth_nonce"] = Nonce,
        ["oauth_signature_method"] = "HMAC-SHA1",
        ["oauth_timestamp"] = Timestamp.ToString(),
        ["oauth_token"] = AccessToken,
        ["oauth_version"] = "1.0",
        ["size"] = "original"
    };
}