namespace XPoster.Tests;

public class CryptoServiceTests
{
    [Fact]
    public async Task GetCryptoValue_Should_ReturnValidPrice_ForBTC()
    {
        // Test integrazione API o mock HttpClient
    }

    [Fact]
    public async Task GetCryptoValue_Should_ReturnZero_WhenAPIFails()
    {
        // Test gestione errori
    }
}

public class FeedServiceTests
{
    [Fact]
    public async Task GetFeedsAsync_Should_ParseRSSCorrectly()
    {
        // Test parsing XML RSS
    }

    [Fact]
    public async Task GetFeedsAsync_Should_FilterByDateRange()
    {
        // Test filtro temporale
    }

    [Fact]
    public async Task GetFeedsAsync_Should_HandleInvalidXML_Gracefully()
    {
        // Test robustezza
    }
}
