namespace AgentSystem.Core.Interfaces;

/// <summary>
/// Defines the contract for an agent in the system
/// </summary>
public interface IAgent
{
    /// <summary>
    /// Gets the unique identifier for this agent
    /// </summary>
    string Id { get; }
    
    /// <summary>
    /// Gets the descriptive name of this agent
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Initializes the agent with its configuration
    /// </summary>
    Task InitializeAsync(AgentConfiguration configuration);
    
    /// <summary>
    /// Executes the agent's main processing logic
    /// </summary>
    Task ExecuteAsync(AgentContext context);
    
    /// <summary>
    /// Handles an incoming message
    /// </summary>
    Task<AgentResponse> ProcessMessageAsync(AgentMessage message);
}