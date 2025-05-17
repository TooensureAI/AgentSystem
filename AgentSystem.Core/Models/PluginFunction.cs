namespace AgentSystem.Core.Models;

/// <summary>
/// Represents a function provided by a plugin
/// </summary>
public class PluginFunction
{
    /// <summary>
    /// Gets or sets the name of the function
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the description of what this function does
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the parameters for this function
    /// </summary>
    public List<PluginFunctionParameter> Parameters { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the return value description
    /// </summary>
    public string ReturnDescription { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets a value indicating whether this function executes asynchronously
    /// </summary>
    public bool IsAsync { get; set; } = true;
}