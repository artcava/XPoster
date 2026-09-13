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
    /// Creates an <see cref="IHttpClientFactory"/> mock whose <c>CreateClient</c> returns an
    /// <see cref="HttpClient"/> backed by the given custom handler.
    /// </summary>
    public static IHttpClientFactory BuildFactory(string clientName, HttpMessageHandler handler)
    {
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(clientName)).Returns(new HttpClient(handler));
        return factory.Object;
    }

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

/// <summary>
/// <see cref="HttpMessageHandler"/> that records every request it receives (including the
/// outgoing body) and delegates response construction to a caller-supplied function, so
/// tests can assert on the exact requests sent by the code under test.
/// </summary>
internal sealed class StubHttpMessageHandler : HttpMessageHandler
{
    /// <summary>Captures a single request observed by the handler.</summary>
    public sealed record CapturedRequest(HttpRequestMessage Message, string? Body);

    private readonly Func<HttpRequestMessage, HttpResponseMessage> _responder;
    private readonly List<CapturedRequest> _requests = new();

    /// <summary>Gets the requests dispatched through this handler, in order.</summary>
    public IReadOnlyList<CapturedRequest> Requests => _requests;

    public StubHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responder)
    {
        ArgumentNullException.ThrowIfNull(responder);
        _responder = responder;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string? body = null;
        if (request.Content is not null)
        {
            body = await request.Content.ReadAsStringAsync(cancellationToken);
        }

        _requests.Add(new CapturedRequest(request, body));
        return _responder(request);
    }
}
