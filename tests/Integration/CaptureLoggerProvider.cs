using Microsoft.Extensions.Logging;

namespace XPoster.Tests.Integration;

/// <summary>
/// Minimal <see cref="ILoggerProvider" /> that appends every formatted log message
/// to a shared <see cref="List{T}" /> so that tests can assert that Polly's
/// <c>OnRetry</c> callback emitted at least one structured log entry.
/// </summary>
internal sealed class CaptureLoggerProvider : ILoggerProvider
{
    private readonly List<string> _messages;

    public CaptureLoggerProvider(List<string> messages) => _messages = messages;

    public ILogger CreateLogger(string categoryName) => new CaptureLogger(_messages);

    public void Dispose() { }

    private sealed class CaptureLogger : ILogger
    {
        private readonly List<string> _messages;

        public CaptureLogger(List<string> messages) => _messages = messages;

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            _messages.Add(formatter(state, exception));
        }
    }
}
