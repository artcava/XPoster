using Microsoft.Extensions.DependencyInjection;
using XPoster.Contracts;
using XPoster.SenderPlugins;

namespace XPoster.Extensions;

/// <summary>
/// Extension methods for registering sender plugins as keyed services with <see cref="SenderPlatform"/> enum.
/// </summary>
public static class SenderPluginsServiceCollectionExtensions
{
    /// <summary>
    /// Registers all sender plugin implementations
    /// </summary>
    /// <remarks>
    /// Sender plugin capability matrix:
    /// <list type="table">
    ///   <listheader><term>Plugin</term><term>Supported Platforms</term></listheader>
    ///   <item><term>X</term><term>✓</term></item>
    ///   <item><term>LinkedIn</term><term>✓</term></item>
    ///   <item><term>Instagram</term><term>✓</term></item>
    ///   <item><term>Facebook</term><term>✓</term></item>
    ///   <item><term>DryRun</term><term>✓</term></item>
    /// </list>
    /// </remarks>
    public static IServiceCollection AddXPosterSenderPlugins(this IServiceCollection services)
    {
        // X sender plugin
        services.AddKeyedTransient<ISender, XSender>(SenderPlatform.X);
        // LinkedIn sender plugin
        services.AddKeyedTransient<ISender, InSender>(SenderPlatform.LinkedIn);
        // Instagram sender plugin
        services.AddKeyedTransient<ISender, IgSender>(SenderPlatform.Instagram);
        // Facebook sender plugin
        services.AddKeyedTransient<ISender, FbSender>(SenderPlatform.Facebook);
        // DryRun sender plugin
        services.AddKeyedTransient<ISender, DryRunSender>(SenderPlatform.DryRun);

        return services;
    }
}
