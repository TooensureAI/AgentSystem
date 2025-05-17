namespace AgentSystem.Core.Models;

/// <summary>
/// Context information for agent execution
/// </summary>
public class AgentContext
{
    /// <summary>
    /// Gets or sets the conversation identifier
    /// </summary>
    public string ConversationId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the user identifier
    /// </summary>
    public string UserId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the session identifier
    /// </summary>
    public string SessionId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the input message that triggered execution
    /// </summary>
    public AgentMessage? InputMessage { get; set; }
    
    /// <summary>
    /// Gets or sets the conversation history
    /// </summary>
    public List<AgentMessage> ConversationHistory { get; set; } = new();
    
    /// <summary>
    /// Gets or sets state information that persists across executions
    /// </summary>
    public Dictionary<string, object> StateData { get; set; } = new();
}