namespace AgentSystem.Core.Models;

/// <summary>
/// Represents a parameter for a plugin function
/// </summary>
public class PluginFunctionParameter
{
    /// <summary>
    /// Gets or sets the name of the parameter
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the description of the parameter
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the data type of the parameter
    /// </summary>
    public string Type { get; set; } = "string";
    
    /// <summary>
    /// Gets or sets a value indicating whether this parameter is required
    /// </summary>
    public bool IsRequired { get; set; } = true;
    
    /// <summary>
    /// Gets or sets the default value for the parameter
    /// </summary>
    public object? DefaultValue { get; set; }
}