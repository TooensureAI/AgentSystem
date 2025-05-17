using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgentSystem.Core.Interfaces;
using AgentSystem.Core.Models;
using Microsoft.Extensions.Logging;

namespace AgentSystem.Core.Agents;

/// <summary>
/// Base implementation of an agent that provides common functionality
/// </summary>
public abstract class BaseAgent : IAgent
{
    private readonly ILogger _logger;
    private AgentConfiguration _configuration = new();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseAgent"/> class
    /// </summary>
    protected BaseAgent(ILogger logger)
    {
        _logger = logger;
    }
    
    /// <inheritdoc/>
    public string Id => _configuration.Id;
    
    /// <inheritdoc/>
    public string Name => _configuration.Name;
    
    /// <summary>
    /// Gets the agent configuration
    /// </summary>
    protected AgentConfiguration Configuration => _configuration;
    
    /// <summary>
    /// Gets the logger
    /// </summary>
    protected ILogger Logger => _logger;
    
    /// <inheritdoc/>
    public virtual async Task InitializeAsync(AgentConfiguration configuration)
    {
        _configuration = configuration;
        _logger.LogInformation("Agent {Name} ({Id}) initialized", Name, Id);
        await Task.CompletedTask;
    }
    
    /// <inheritdoc/>
    public abstract Task ExecuteAsync(AgentContext context);
    
    /// <inheritdoc/>
    public virtual async Task<AgentResponse> ProcessMessageAsync(AgentMessage message)
    {
        try
        {
            _logger.LogInformation("Processing message: {MessageId}", message.Id);
            
            var context = new AgentContext
            {
                InputMessage = message,
                ConversationId = message.Metadata.TryGetValue("conversationId", out var convId) ? convId.ToString() ?? string.Empty : string.Empty
            };
            
            await ExecuteAsync(context);
            
            return AgentResponse.CreateSuccess(
                new AgentMessage
                {
                    SenderId = Id,
                    RecipientId = message.SenderId,
                    Content = $"Message processed by {Name}"
                });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing message {MessageId}", message.Id);
            return AgentResponse.CreateError($"Error processing message: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Creates a response message
    /// </summary>
    protected AgentMessage CreateResponseMessage(AgentMessage originalMessage, string content)
    {
        return new AgentMessage
        {
            SenderId = Id,
            RecipientId = originalMessage.SenderId,
            Content = content,
            Metadata = new Dictionary<string, object>
            {
                { "inResponseTo", originalMessage.Id }
            }
        };
    }
}