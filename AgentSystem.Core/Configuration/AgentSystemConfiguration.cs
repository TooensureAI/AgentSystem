namespace AgentSystem.Core.Configuration;

/// <summary>
/// Configuration for the agent system
/// </summary>
public class AgentSystemConfiguration
{
    /// <summary>
    /// Gets or sets the system name
    /// </summary>
    public string SystemName { get; set; } = "Agent System";
    
    /// <summary>
    /// Gets or sets the system version
    /// </summary>
    public string SystemVersion { get; set; } = "1.0.0";
    
    /// <summary>
    /// Gets or sets the agent configurations
    /// </summary>
    public List<AgentConfig> Agents { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the plugin configurations
    /// </summary>
    public List<PluginConfig> Plugins { get; set; } = new();
    
    /// <summary>
    /// Gets or sets template configurations
    /// </summary>
    public List<TemplateConfig> Templates { get; set; } = new();
    
    /// <summary>
    /// Gets or sets global settings
    /// </summary>
    public Dictionary<string, object> GlobalSettings { get; set; } = new();
}

/// <summary>
/// Configuration for an agent
/// </summary>
public class AgentConfig
{
    /// <summary>
    /// Gets or sets the agent ID
    /// </summary>
    public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the agent name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the agent description
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the agent type
    /// </summary>
    public string Type { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the agent capabilities
    /// </summary>
    public List<string> Capabilities { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the agent plugins
    /// </summary>
    public List<string> Plugins { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the agent templates
    /// </summary>
    public List<string> Templates { get; set; } = new();
    
    /// <summary>
    /// Gets or sets agent-specific settings
    /// </summary>
    public Dictionary<string, object> Settings { get; set; } = new();
}

/// <summary>
/// Configuration for a plugin
/// </summary>
public class PluginConfig
{
    /// <summary>
    /// Gets or sets the plugin ID
    /// </summary>
    public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the plugin name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the plugin description
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the plugin type
    /// </summary>
    public string Type { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets plugin-specific settings
    /// </summary>
    public Dictionary<string, object> Settings { get; set; } = new();
}

/// <summary>
/// Configuration for a template
/// </summary>
public class TemplateConfig
{
    /// <summary>
    /// Gets or sets the template ID
    /// </summary>
    public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the template name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the template description
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the template path
    /// </summary>
    public string Path { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the template content (if not loading from path)
    /// </summary>
    public string Content { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets template-specific settings
    /// </summary>
    public Dictionary<string, object> Settings { get; set; } = new();
}