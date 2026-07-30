using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Unit tests for <see cref="AiModelCatalog"/>.
/// </summary>
public class AiModelCatalogTests
{
    // ── Construction ──────────────────────────────────────────────────────────

    [Fact]
    public void Empty_SupportsNoModelClass()
    {
        Assert.False(AiModelCatalog.Empty.Supports(AiModelClass.Text));
        Assert.False(AiModelCatalog.Empty.Supports(AiModelClass.Image));
    }

    [Fact]
    public void Constructor_NullDictionary_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => new AiModelCatalog(null!));
    }

    [Fact]
    public void Constructor_ExcludesNullOrWhitespaceEntries()
    {
        var catalog = new AiModelCatalog(new Dictionary<AiModelClass, string>
        {
            [AiModelClass.Text] = "   ",
            [AiModelClass.Image] = "image-model"
        });

        Assert.False(catalog.Supports(AiModelClass.Text));
        Assert.True(catalog.Supports(AiModelClass.Image));
    }

    // ── Supports ──────────────────────────────────────────────────────────────

    [Fact]
    public void Supports_ReturnsTrueForRegisteredModelClass()
    {
        var catalog = new AiModelCatalog(new Dictionary<AiModelClass, string>
        {
            [AiModelClass.Text] = "gpt-4"
        });

        Assert.True(catalog.Supports(AiModelClass.Text));
    }

    [Fact]
    public void Supports_ReturnsFalseForMissingModelClass()
    {
        var catalog = new AiModelCatalog(new Dictionary<AiModelClass, string>
        {
            [AiModelClass.Text] = "gpt-4"
        });

        Assert.False(catalog.Supports(AiModelClass.Image));
    }

    // ── TryGet ────────────────────────────────────────────────────────────────

    [Fact]
    public void TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported()
    {
        var catalog = new AiModelCatalog(new Dictionary<AiModelClass, string>
        {
            [AiModelClass.Image] = "flux-schnell"
        });

        var found = catalog.TryGet(AiModelClass.Image, out var modelName);

        Assert.True(found);
        Assert.Equal("flux-schnell", modelName);
    }

    [Fact]
    public void TryGet_ReturnsFalseAndNullModelName_WhenNotSupported()
    {
        var catalog = new AiModelCatalog(new Dictionary<AiModelClass, string>
        {
            [AiModelClass.Image] = "flux-schnell"
        });

        var found = catalog.TryGet(AiModelClass.Text, out var modelName);

        Assert.False(found);
        Assert.Null(modelName);
    }

    // ── GetRequired ───────────────────────────────────────────────────────────

    [Fact]
    public void GetRequired_ReturnsModelName_WhenSupported()
    {
        var catalog = new AiModelCatalog(new Dictionary<AiModelClass, string>
        {
            [AiModelClass.Text] = "deepseek-chat"
        });

        Assert.Equal("deepseek-chat", catalog.GetRequired(AiModelClass.Text));
    }

    [Fact]
    public void GetRequired_Throws_WhenNotSupported()
    {
        var catalog = new AiModelCatalog(new Dictionary<AiModelClass, string>
        {
            [AiModelClass.Text] = "deepseek-chat"
        });

        Assert.Throws<InvalidOperationException>(() => catalog.GetRequired(AiModelClass.Image));
    }
}
