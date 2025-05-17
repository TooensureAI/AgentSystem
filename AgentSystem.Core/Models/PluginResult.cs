namespace AgentSystem.Core.Models;

/// <summary>
/// Represents the result of a plugin function execution
/// </summary>
public class PluginResult
{
    /// <summary>
    /// Gets or sets a value indicating whether the execution was successful
    /// </summary>
    public bool Success { get; set; }
    
    /// <summary>
    /// Gets or sets any error message
    /// </summary>
    public string ErrorMessage { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the result data
    /// </summary>
    public object? Data { get; set; }
    
    /// <summary>
    /// Creates a successful result
    /// </summary>
    public static PluginResult CreateSuccess(object? data) => new()
    {
        Success = true,
        Data = data
    };
    
    /// <summary>
    /// Creates an error result
    /// </summary>
    public static PluginResult CreateError(string errorMessage) => new()
    {
        Success = false,
        ErrorMessage = errorMessage
    };
}