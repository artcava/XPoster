using XPoster.Contracts;

namespace XPoster.Abstraction;

/// <summary>
/// Describes the full execution profile for a scheduled posting slot.
/// </summary>
public sealed class ScheduledOrchestrationProfile
{
    /// <summary>Hour of day (0-23) when this slot is active.</summary>
    public int Hour { get; init; }

    /// <summary>Target platform for this slot. Drives sender resolution in <see cref="XPoster.Orchestrators.OrchestratorFactory"/>.</summary>
    public SenderPlatform SenderPlatform { get; init; }

    /// <summary>Orchestrator type to instantiate for this slot.</summary>
    public Type OrchestratorType { get; init; }

    /// <summary>
    /// Optional AI provider for text generation (<see cref="ITextToTextProvider"/>).
    /// When <c>null</c>, no <see cref="ITextToTextProvider"/> is injected into the orchestrator.
    /// </summary>
    public AiProvider? TextProvider { get; init; }

    /// <summary>
    /// Optional AI provider for image generation (<see cref="ITextToImageProvider"/>).
    /// May differ from <see cref="TextProvider"/> to allow mixing providers per capability
    /// (e.g. DeepSeek for text + FalAi for image within the same slot).
    /// When <c>null</c>, no <see cref="ITextToImageProvider"/> is injected into the orchestrator.
    /// </summary>
    public AiProvider? ImageProvider { get; init; }

    /// <summary>
    /// Initialises a new instance of <see cref="ScheduledOrchestrationProfile"/> with independent
    /// text and image provider selections.
    /// </summary>
    /// <param name="hour">Hour of day (0-23) when this slot is active.</param>
    /// <param name="senderPlatform">Target platform for this slot.</param>
    /// <param name="orchestratorType">Orchestrator type to instantiate for this slot.</param>
    /// <param name="textProvider">Optional AI provider for text generation. Null means no text capability for this slot.</param>
    /// <param name="imageProvider">Optional AI provider for image generation. Null means no image capability for this slot.</param>
    public ScheduledOrchestrationProfile(
        int hour,
        SenderPlatform senderPlatform,
        Type orchestratorType,
        AiProvider? textProvider = null,
        AiProvider? imageProvider = null)
    {
        Hour = hour;
        SenderPlatform = senderPlatform;
        OrchestratorType = orchestratorType;
        TextProvider = textProvider;
        ImageProvider = imageProvider;
    }
}
