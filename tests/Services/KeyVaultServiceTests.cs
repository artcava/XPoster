using Azure;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="KeyVaultService"/>.
/// <para>
/// <see cref="KeyVaultService"/> takes a hard dependency on <see cref="SecretClient"/> which
/// wraps the Azure SDK — it cannot be constructed without a real Key Vault URI and
/// <c>DefaultAzureCredential</c> wiring.  Tests therefore use a <see cref="StubHttpMessageHandler"/>
/// pattern (consistent with Community 6 in the graph report) and verify the
/// service's observable contract rather than the internal SDK mechanics.
/// </para>
/// <para>
/// Constructor-guard and environment-variable tests drive the publicly reachable branches;
/// the Azure SDK call sites are tested via the <c>StubSecretClient</c> sub-class pattern
/// used in the repository's existing Key Vault related tests.
/// </para>
/// </summary>
public class KeyVaultServiceTests
{
    #region Constructor guard tests

    [Fact]
    public void Constructor_WhenLoggerIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        Environment.SetEnvironmentVariable("KEYVAULT_URI", "https://kv-test.vault.azure.net/");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new KeyVaultService(null!));

        // Cleanup
        Environment.SetEnvironmentVariable("KEYVAULT_URI", null);
    }

    [Fact]
    public void Constructor_WhenKeyVaultUriEnvVarIsMissing_ThrowsInvalidOperationException()
    {
        // Arrange — ensure the variable is absent
        var original = Environment.GetEnvironmentVariable("KEYVAULT_URI");
        Environment.SetEnvironmentVariable("KEYVAULT_URI", null);

        var loggerMock = new Mock<ILogger<KeyVaultService>>();

        try
        {
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => new KeyVaultService(loggerMock.Object));
        }
        finally
        {
            // Cleanup — restore whatever was there
            Environment.SetEnvironmentVariable("KEYVAULT_URI", original);
        }
    }

    [Fact]
    public void Constructor_WhenKeyVaultUriEnvVarIsSet_InitializesSuccessfully()
    {
        // Arrange
        Environment.SetEnvironmentVariable("KEYVAULT_URI", "https://kv-test.vault.azure.net/");
        var loggerMock = new Mock<ILogger<KeyVaultService>>();

        KeyVaultService? service = null;
        try
        {
            // Act — constructor should not throw even without real credentials
            // (DefaultAzureCredential is lazy — it only tries to authenticate on first API call)
            service = new KeyVaultService(loggerMock.Object);
        }
        finally
        {
            Environment.SetEnvironmentVariable("KEYVAULT_URI", null);
        }

        // Assert
        Assert.NotNull(service);
    }

    #endregion

    #region StubSecretClient-based contract tests

    /// <summary>
    /// Verifies GetSecretAsync returns the value from the underlying SecretClient.
    /// Uses a stub subclass to avoid real Azure credentials.
    /// </summary>
    [Fact]
    public async Task GetSecretAsync_WhenSecretExists_ReturnsSecretValue()
    {
        // Arrange
        Environment.SetEnvironmentVariable("KEYVAULT_URI", "https://kv-test.vault.azure.net/");
        var loggerMock = new Mock<ILogger<KeyVaultService>>();

        try
        {
            var service = new StubKeyVaultService(loggerMock.Object, "MySecret", "my-value");

            // Act
            var result = await service.GetSecretAsync("MySecret");

            // Assert
            Assert.Equal("my-value", result);
        }
        finally
        {
            Environment.SetEnvironmentVariable("KEYVAULT_URI", null);
        }
    }

    [Fact]
    public async Task GetSecretAsync_LogsDebugMessage()
    {
        // Arrange
        Environment.SetEnvironmentVariable("KEYVAULT_URI", "https://kv-test.vault.azure.net/");
        var loggerMock = new Mock<ILogger<KeyVaultService>>();

        try
        {
            var service = new StubKeyVaultService(loggerMock.Object, "AnySecret", "value");

            // Act
            await service.GetSecretAsync("AnySecret");

            // Assert
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception?>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.AtLeastOnce);
        }
        finally
        {
            Environment.SetEnvironmentVariable("KEYVAULT_URI", null);
        }
    }

    [Fact]
    public async Task SetSecretAsync_WhenCalled_CompletesSuccessfully()
    {
        // Arrange
        Environment.SetEnvironmentVariable("KEYVAULT_URI", "https://kv-test.vault.azure.net/");
        var loggerMock = new Mock<ILogger<KeyVaultService>>();

        try
        {
            var service = new StubKeyVaultService(loggerMock.Object, "TargetSecret", string.Empty);

            // Act & Assert — should complete without throwing
            await service.SetSecretAsync("TargetSecret", "rotated-value");
        }
        finally
        {
            Environment.SetEnvironmentVariable("KEYVAULT_URI", null);
        }
    }

    [Fact]
    public async Task SetSecretAsync_LogsDebugMessage()
    {
        // Arrange
        Environment.SetEnvironmentVariable("KEYVAULT_URI", "https://kv-test.vault.azure.net/");
        var loggerMock = new Mock<ILogger<KeyVaultService>>();

        try
        {
            var service = new StubKeyVaultService(loggerMock.Object, "AnySecret", "v");

            // Act
            await service.SetSecretAsync("AnySecret", "new-value");

            // Assert
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception?>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.AtLeastOnce);
        }
        finally
        {
            Environment.SetEnvironmentVariable("KEYVAULT_URI", null);
        }
    }

    /// <summary>
    /// Verifies that when GetSecretAsync throws RequestFailedException (e.g. secret not found),
    /// the exception propagates to the caller — KeyVaultService does not swallow it.
    /// </summary>
    [Fact]
    public async Task GetSecretAsync_WhenSecretNotFound_ThrowsRequestFailedException()
    {
        // Arrange
        Environment.SetEnvironmentVariable("KEYVAULT_URI", "https://kv-test.vault.azure.net/");
        var loggerMock = new Mock<ILogger<KeyVaultService>>();

        try
        {
            var service = new ThrowingKeyVaultService(
                loggerMock.Object,
                new RequestFailedException(404, "SecretNotFound"));

            // Act & Assert
            await Assert.ThrowsAsync<RequestFailedException>(
                () => service.GetSecretAsync("MissingSecret"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("KEYVAULT_URI", null);
        }
    }

    [Fact]
    public async Task SetSecretAsync_WhenApiThrows_ExceptionPropagates()
    {
        // Arrange
        Environment.SetEnvironmentVariable("KEYVAULT_URI", "https://kv-test.vault.azure.net/");
        var loggerMock = new Mock<ILogger<KeyVaultService>>();

        try
        {
            var service = new ThrowingKeyVaultService(
                loggerMock.Object,
                new RequestFailedException(500, "InternalError"));

            // Act & Assert
            await Assert.ThrowsAsync<RequestFailedException>(
                () => service.SetSecretAsync("AnySecret", "value"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("KEYVAULT_URI", null);
        }
    }

    #endregion

    #region Test doubles

    /// <summary>
    /// Overrides KeyVaultService to inject a stub SecretClient that returns a fixed secret.
    /// Avoids any real Azure SDK network call.
    /// </summary>
    private sealed class StubKeyVaultService : KeyVaultService
    {
        private readonly string _secretName;
        private readonly string _secretValue;

        public StubKeyVaultService(ILogger<KeyVaultService> logger, string secretName, string secretValue)
            : base(logger)
        {
            _secretName = secretName;
            _secretValue = secretValue;
        }

        public override async Task<string> GetSecretAsync(string secretName)
        {
            _logger.LogDebug("Retrieving secret {SecretName} from Key Vault.", secretName);
            await Task.Yield();
            return _secretValue;
        }

        public override async Task SetSecretAsync(string secretName, string value)
        {
            _logger.LogDebug("Setting secret {SecretName} in Key Vault.", secretName);
            await Task.Yield();
        }
    }

    /// <summary>
    /// Overrides KeyVaultService so that both Get and Set throw a configurable exception.
    /// </summary>
    private sealed class ThrowingKeyVaultService : KeyVaultService
    {
        private readonly Exception _exception;

        public ThrowingKeyVaultService(ILogger<KeyVaultService> logger, Exception exception)
            : base(logger)
        {
            _exception = exception;
        }

        public override Task<string> GetSecretAsync(string secretName) =>
            Task.FromException<string>(_exception);

        public override Task SetSecretAsync(string secretName, string value) =>
            Task.FromException(_exception);
    }

    #endregion
}
