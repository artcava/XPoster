using Microsoft.Extensions.Configuration;
using XPoster.Workflows.Models;

namespace XPoster.Workflows.Services;

/// <summary>
/// Default <see cref="IStepOptionsResolver"/> implementation that binds prompt
/// configuration from the <c>PromptSteps:{{StepId}}</c> section of <see cref="IConfiguration"/>.
/// </summary>
public class ConfigurationStepOptionsResolver : IStepOptionsResolver
{
    private readonly IConfiguration _configuration;

    /// <summary>Initializes a new instance of the <see cref="ConfigurationStepOptionsResolver"/> class.</summary>
    public ConfigurationStepOptionsResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <inheritdoc />
    public PromptStepOptions Resolve(string stepId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(stepId);

        var stepOptions = _configuration
            .GetSection($"PromptSteps:{stepId}")
            .Get<PromptStepOptions>();

        return stepOptions
            ?? throw new InvalidOperationException($"PromptStepOptions missing for StepId: '{stepId}'.");
    }
}