namespace XPoster.Abstraction;

/// <summary>
/// Describes the full execution profile for a scheduled posting slot.
/// </summary>
public sealed class ScheduledGenerationProfile
{
    /// <summary>Hour of day (0-23) when this slot is active.</summary>
    public int Hour { get; init; }

    /// <summary>Sender strategy used for this slot.</summary>
    public MessageSender SenderType { get; init; }

    /// <summary>Generator type to instantiate for this slot.</summary>
    public Type GeneratorType { get; init; }

    /// <summary>Optional AI provider used by this slot when the generator requires it.</summary>
    public AiProvider? AiProvider { get; init; }

    /// <summary>
    /// Initialises a new instance of <see cref="ScheduledGenerationProfile"/>.
    /// </summary>
    /// <param name="hour">Hour of day (0-23) when this slot is active.</param>
    /// <param name="senderType">Sender strategy used for this slot.</param>
    /// <param name="generatorType">Generator type to instantiate for this slot.</param>
    /// <param name="aiProvider">Optional AI provider for generators that require AI services.</param>
    public ScheduledGenerationProfile(int hour, MessageSender senderType, Type generatorType, AiProvider? aiProvider = null)
    {
        Hour = hour;
        SenderType = senderType;
        GeneratorType = generatorType;
        AiProvider = aiProvider;
    }
}
