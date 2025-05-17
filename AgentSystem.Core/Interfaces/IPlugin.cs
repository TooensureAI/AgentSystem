namespace AgentSystem.Core.Interfaces;

/// <summary>
/// Defines the contract for a plugin in the system
/// </summary>
public interface IPlugin
{
    /// <summary>
    /// Gets the unique identifier for this plugin
    /// </summary>
    string Id { get; }
    
    /// <summary>
    /// Gets the name of this plugin
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Gets the description of what this plugin does
    /// </summary>
    string Description { get; }
    
    /// <summary>
    /// Gets the version of this plugin
    /// </summary>
    string Version { get; }
    
    /// <summary>
    /// Initializes the plugin with its configuration
    /// </summary>
    Task InitializeAsync(PluginConfiguration configuration);
    
    /// <summary>
    /// Executes a plugin function
    /// </summary>
    Task<PluginResult> ExecuteFunctionAsync(string functionName, Dictionary<string, object> parameters);
    
    /// <summary>
    /// Gets the available functions provided by this plugin
    /// </summary>
    IReadOnlyList<PluginFunction> GetAvailableFunctions();
}