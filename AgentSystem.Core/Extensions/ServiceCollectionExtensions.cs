using AgentSystem.Core.Configuration;
using AgentSystem.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgentSystem.Core.Extensions;

/// <summary>
/// Extension methods for service collection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds core agent system services to the service collection
    /// </summary>
    public static IServiceCollection AddAgentSystem(this IServiceCollection services, IConfiguration configuration)
    {
        // Add configuration
        var section = configuration.GetSection("AgentSystem");
        services.Configure<AgentSystemConfiguration>(options => 
        {
            section.Bind(options);
        });
        
        // Add core services
        services.AddSingleton<AgentService>();
        services.AddSingleton<PluginService>();
        
        return services;
    }
}