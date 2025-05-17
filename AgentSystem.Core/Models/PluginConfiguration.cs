namespace AgentSystem.Core.Models;

/// <summary>
/// Configuration settings for a plugin
/// </summary>
public class PluginConfiguration
{
    /// <summary>
    /// Gets or sets the unique identifier for this plugin
    /// </summary>
    public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the name of the plugin
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the description of what this plugin does
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets plugin-specific configuration values
    /// </summary>
    public Dictionary<string, object> Settings { get; set; } = new();
}