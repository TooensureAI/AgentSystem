namespace AgentSystem.Core.Models;

/// <summary>
/// Configuration settings for an agent
/// </summary>
public class AgentConfiguration
{
    /// <summary>
    /// Gets or sets the unique identifier for this agent
    /// </summary>
    public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the descriptive name of this agent
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the description of this agent
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the capability identifiers available to this agent
    /// </summary>
    public List<string> Capabilities { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the plugin identifiers to be loaded for this agent
    /// </summary>
    public List<string> Plugins { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the template identifiers to be used by this agent
    /// </summary>
    public List<string> Templates { get; set; } = new();
    
    /// <summary>
    /// Gets or sets custom configuration values
    /// </summary>
    public Dictionary<string, object> Settings { get; set; } = new();
}