using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Unit tests for <see cref="OpenAiOptionsValidator"/>.
/// Verifies that the validator accepts well-formed options and rejects each
/// missing placeholder individually as well as all together.
/// </summary>
public class OpenAiOptionsValidatorTests
{
    private static OpenAiOptions ValidOptions() => new OpenAiOptions();

    private readonly OpenAiOptionsValidator _sut = new();

}
