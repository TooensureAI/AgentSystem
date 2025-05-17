using AgentSystem.Core.Interfaces;
using AgentSystem.Core.Models;
using Microsoft.Extensions.Logging;

namespace AgentSystem.Core.Services;

/// <summary>
/// Service for managing and executing agents
/// </summary>
public class AgentService
{
    private readonly ILogger<AgentService> _logger;
    private readonly Dictionary<string, IAgent> _agents = new();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="AgentService"/> class
    /// </summary>
    public AgentService(ILogger<AgentService> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// Registers an agent with the service
    /// </summary>
    public void RegisterAgent(IAgent agent)
    {
        if (_agents.ContainsKey(agent.Id))
        {
            _logger.LogWarning("Agent with ID {AgentId} is already registered, replacing", agent.Id);
        }
        
        _agents[agent.Id] = agent;
        _logger.LogInformation("Agent {AgentName} ({AgentId}) registered", agent.Name, agent.Id);
    }
    
    /// <summary>
    /// Gets an agent by its ID
    /// </summary>
    public IAgent? GetAgent(string agentId)
    {
        if (_agents.TryGetValue(agentId, out var agent))
        {
            return agent;
        }
        
        _logger.LogWarning("Agent with ID {AgentId} not found", agentId);
        return null;
    }
    
    /// <summary>
    /// Gets all registered agents
    /// </summary>
    public IReadOnlyList<IAgent> GetAllAgents()
    {
        return _agents.Values.ToList();
    }
    
    /// <summary>
    /// Processes a message with the appropriate agent
    /// </summary>
    public async Task<AgentResponse> ProcessMessageAsync(AgentMessage message)
    {
        if (string.IsNullOrEmpty(message.RecipientId))
        {
            _logger.LogWarning("Message {MessageId} has no recipient ID", message.Id);
            return AgentResponse.CreateError("Message has no recipient ID");
        }
        
        var agent = GetAgent(message.RecipientId);
        if (agent == null)
        {
            return AgentResponse.CreateError($"Agent with ID {message.RecipientId} not found");
        }
        
        return await agent.ProcessMessageAsync(message);
    }
}