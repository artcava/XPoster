using System.Net;
using Moq;
using Moq.Protected;

namespace XPoster.Tests.Helpers;

/// <summary>
/// Factory helpers for creating <see cref="HttpMessageHandler"/> mocks that simulate
/// transient HTTP failure sequences (e.g. 429 → 429 → 200) for Polly resilience tests.
/// All handlers create a fresh <see cref="HttpResponseMessage"/> on every call so that
/// the response stream can be read multiple times across retry iterations.
/// </summary>
internal static class ResilienceTestHelpers
{
    /// <summary>
    /// Creates an <see cref="IHttpClientFactory"/> mock whose <c>CreateClient</c> returns an
    /// <see cref="HttpClient"/> backed by a handler that returns <paramref name="responses"/> in order,
    /// then repeats the last response for any additional calls.
    /// </summary>
    /// <param name="clientName">The named-client key the factory will respond to (e.g. "LinkedIn").</param>
    /// <param name="responses">Ordered sequence of (statusCode, jsonBody) pairs.</param>
    public static IHttpClientFactory BuildFactory(
        string clientName,
        params (HttpStatusCode statusCode, string body)[] responses)
    {
        var handler = BuildSequenceHandler(responses);
        var client = new HttpClient(handler);

        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(clientName)).Returns(client);
        return factory.Object;
    }

    /// <summary>
    /// Creates an <see cref="IHttpClientFactory"/> mock that always returns the same single response.
    /// </summary>
    public static IHttpClientFactory BuildFactory(string clientName, HttpStatusCode code, string body)
        => BuildFactory(clientName, (code, body));

    /// <summary>
    /// Builds a <see cref="HttpMessageHandler"/> that returns the given responses in sequence.
    /// Subsequent calls beyond the sequence length repeat the last entry.
    /// </summary>
    public static HttpMessageHandler BuildSequenceHandler(
        params (HttpStatusCode statusCode, string body)[] responses)
    {
        var callIndex = 0;
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns(() =>
            {
                var idx = Math.Min(callIndex++, responses.Length - 1);
                var (code, body) = responses[idx];
                return Task.FromResult(new HttpResponseMessage(code)
                {
                    Content = new StringContent(body, System.Text.Encoding.UTF8, "application/json")
                });
            });
        return mock.Object;
    }
}
