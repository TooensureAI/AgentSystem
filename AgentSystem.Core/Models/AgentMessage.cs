namespace AgentSystem.Core.Models;

/// <summary>
/// Represents a message sent to or from an agent
/// </summary>
public class AgentMessage
{
    /// <summary>
    /// Gets or sets the unique identifier for this message
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    /// <summary>
    /// Gets or sets the sender identifier
    /// </summary>
    public string SenderId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the recipient identifier
    /// </summary>
    public string RecipientId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the message content
    /// </summary>
    public string Content { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the message type
    /// </summary>
    public string MessageType { get; set; } = "text";
    
    /// <summary>
    /// Gets or sets the timestamp when the message was created
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Gets or sets additional metadata for the message
    /// </summary>
    public Dictionary<string, object> Metadata { get; set; } = new();
}