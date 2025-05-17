namespace AgentSystem.Core.Models;

/// <summary>
/// Represents a response from an agent
/// </summary>
public class AgentResponse
{
    /// <summary>
    /// Gets or sets the response message
    /// </summary>
    public AgentMessage? Message { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether the processing was successful
    /// </summary>
    public bool Success { get; set; }
    
    /// <summary>
    /// Gets or sets any error message
    /// </summary>
    public string ErrorMessage { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets any additional data returned by the agent
    /// </summary>
    public Dictionary<string, object> Data { get; set; } = new();
    
    /// <summary>
    /// Creates a successful response with a message
    /// </summary>
    public static AgentResponse CreateSuccess(AgentMessage message) => new()
    {
        Success = true,
        Message = message
    };
    
    /// <summary>
    /// Creates a successful response with message content
    /// </summary>
    public static AgentResponse CreateSuccess(string content, string senderId = "", string recipientId = "") => new()
    {
        Success = true,
        Message = new AgentMessage
        {
            Content = content,
            SenderId = senderId,
            RecipientId = recipientId
        }
    };
    
    /// <summary>
    /// Creates an error response
    /// </summary>
    public static AgentResponse CreateError(string errorMessage) => new()
    {
        Success = false,
        ErrorMessage = errorMessage
    };
}