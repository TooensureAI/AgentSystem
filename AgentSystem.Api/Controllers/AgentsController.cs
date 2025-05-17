using AgentSystem.Core.Interfaces;
using AgentSystem.Core.Models;
using AgentSystem.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AgentSystem.Api.Controllers;

/// <summary>
/// Controller for managing autonomous agents
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class AgentsController : ControllerBase
{
    private readonly AgentService _agentService;
    private readonly ILogger<AgentsController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AgentsController"/> class
    /// </summary>
    public AgentsController(AgentService agentService, ILogger<AgentsController> logger)
    {
        _agentService = agentService;
        _logger = logger;
    }

    /// <summary>
    /// Gets all registered agents
    /// </summary>
    /// <returns>A list of all agents</returns>
    /// <response code="200">Returns the list of agents</response>
    /// <response code="401">If the user is not authenticated</response>
    [HttpGet]
    [Authorize]
    [SwaggerOperation(
        Summary = "Get all agents",
        Description = "Returns a list of all registered agents",
        OperationId = "GetAgents",
        Tags = new[] { "Agents" }
    )]
    [SwaggerResponse(200, "Success", typeof(IEnumerable<AgentDTO>))]
    [SwaggerResponse(401, "Unauthorized")]
    public IActionResult GetAgents()
    {
        var agents = _agentService.GetAllAgents();
        var agentDTOs = agents.Select(a => new AgentDTO
        {
            Id = a.Id,
            Name = a.Name
            // Map other properties
        });

        return Ok(agentDTOs);
    }

    /// <summary>
    /// Gets an agent by its ID
    /// </summary>
    /// <param name="id">The agent ID</param>
    /// <returns>The agent with the specified ID</returns>
    /// <response code="200">Returns the agent</response>
    /// <response code="404">If the agent is not found</response>
    /// <response code="401">If the user is not authenticated</response>
    [HttpGet("{id}")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Get an agent by ID",
        Description = "Returns a specific agent by its ID",
        OperationId = "GetAgentById",
        Tags = new[] { "Agents" }
    )]
    [SwaggerResponse(200, "Success", typeof(AgentDTO))]
    [SwaggerResponse(404, "Not Found")]
    [SwaggerResponse(401, "Unauthorized")]
    public IActionResult GetAgent(string id)
    {
        var agent = _agentService.GetAgent(id);
        if (agent == null)
        {
            return NotFound();
        }

        var agentDTO = new AgentDTO
        {
            Id = agent.Id,
            Name = agent.Name
            // Map other properties
        };

        return Ok(agentDTO);
    }

    /// <summary>
    /// Creates a new agent
    /// </summary>
    /// <param name="agentCreate">The agent to create</param>
    /// <returns>The created agent</returns>
    /// <response code="201">Returns the newly created agent</response>
    /// <response code="400">If the agent is invalid</response>
    /// <response code="401">If the user is not authenticated</response>
    [HttpPost]
    [Authorize]
    [SwaggerOperation(
        Summary = "Create an agent",
        Description = "Creates a new agent with the specified configuration",
        OperationId = "CreateAgent",
        Tags = new[] { "Agents" }
    )]
    [SwaggerResponse(201, "Created", typeof(AgentDTO))]
    [SwaggerResponse(400, "Bad Request")]
    [SwaggerResponse(401, "Unauthorized")]
    public IActionResult CreateAgent([FromBody] AgentCreateDTO agentCreate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // In a real implementation, this would create an actual agent
        var agentDTO = new AgentDTO
        {
            Id = Guid.NewGuid().ToString(),
            Name = agentCreate.Name
            // Map other properties
        };

        return CreatedAtAction(nameof(GetAgent), new { id = agentDTO.Id }, agentDTO);
    }

    /// <summary>
    /// Updates an existing agent
    /// </summary>
    /// <param name="id">The agent ID</param>
    /// <param name="agentUpdate">The updated agent information</param>
    /// <returns>No content</returns>
    /// <response code="204">If the agent was successfully updated</response>
    /// <response code="400">If the agent is invalid</response>
    /// <response code="404">If the agent is not found</response>
    /// <response code="401">If the user is not authenticated</response>
    [HttpPut("{id}")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Update an agent",
        Description = "Updates an existing agent with the specified configuration",
        OperationId = "UpdateAgent",
        Tags = new[] { "Agents" }
    )]
    [SwaggerResponse(204, "No Content")]
    [SwaggerResponse(400, "Bad Request")]
    [SwaggerResponse(404, "Not Found")]
    [SwaggerResponse(401, "Unauthorized")]
    public IActionResult UpdateAgent(string id, [FromBody] AgentUpdateDTO agentUpdate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var agent = _agentService.GetAgent(id);
        if (agent == null)
        {
            return NotFound();
        }

        // In a real implementation, this would update the agent
        
        return NoContent();
    }

    /// <summary>
    /// Deletes an agent
    /// </summary>
    /// <param name="id">The agent ID</param>
    /// <returns>No content</returns>
    /// <response code="204">If the agent was successfully deleted</response>
    /// <response code="404">If the agent is not found</response>
    /// <response code="401">If the user is not authenticated</response>
    [HttpDelete("{id}")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Delete an agent",
        Description = "Deletes a specific agent by its ID",
        OperationId = "DeleteAgent",
        Tags = new[] { "Agents" }
    )]
    [SwaggerResponse(204, "No Content")]
    [SwaggerResponse(404, "Not Found")]
    [SwaggerResponse(401, "Unauthorized")]
    public IActionResult DeleteAgent(string id)
    {
        var agent = _agentService.GetAgent(id);
        if (agent == null)
        {
            return NotFound();
        }

        // In a real implementation, this would delete the agent
        
        return NoContent();
    }

    /// <summary>
    /// Executes an agent with the provided context
    /// </summary>
    /// <param name="id">The agent ID</param>
    /// <param name="context">The execution context</param>
    /// <returns>The execution result</returns>
    /// <response code="200">Returns the execution result</response>
    /// <response code="400">If the context is invalid</response>
    /// <response code="404">If the agent is not found</response>
    /// <response code="401">If the user is not authenticated</response>
    [HttpPost("{id}/execute")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Execute an agent",
        Description = "Executes an agent with the provided context",
        OperationId = "ExecuteAgent",
        Tags = new[] { "Agents" }
    )]
    [SwaggerResponse(200, "Success", typeof(AgentResponseDTO))]
    [SwaggerResponse(400, "Bad Request")]
    [SwaggerResponse(404, "Not Found")]
    [SwaggerResponse(401, "Unauthorized")]
    public async Task<IActionResult> ExecuteAgent(string id, [FromBody] AgentContextDTO context)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var agent = _agentService.GetAgent(id);
        if (agent == null)
        {
            return NotFound();
        }

        // Convert DTO to domain model
        var agentContext = new AgentContext
        {
            ConversationId = context.ConversationId,
            UserId = context.UserId,
            SessionId = context.SessionId,
            // Map other properties
        };

        try
        {
            // Execute the agent
            await agent.ExecuteAsync(agentContext);

            // Create a response DTO
            var responseDTO = new AgentResponseDTO
            {
                Success = true,
                Message = new AgentMessageDTO
                {
                    Content = "Agent executed successfully",
                    MessageType = "text",
                    Timestamp = DateTime.UtcNow
                }
            };

            return Ok(responseDTO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing agent {AgentId}", id);
            return StatusCode(500, new AgentResponseDTO
            {
                Success = false,
                ErrorMessage = "Error executing agent: " + ex.Message
            });
        }
    }
}

/// <summary>
/// DTO for agent information
/// </summary>
public class AgentDTO
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
    public string? Description { get; set; }
    
    /// <summary>
    /// Gets or sets the agent capabilities
    /// </summary>
    public List<string>? Capabilities { get; set; }
    
    /// <summary>
    /// Gets or sets the agent plugins
    /// </summary>
    public List<string>? Plugins { get; set; }
}

/// <summary>
/// DTO for creating an agent
/// </summary>
public class AgentCreateDTO
{
    /// <summary>
    /// Gets or sets the agent name
    /// </summary>
    [SwaggerSchema(Description = "The name of the agent")]
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the agent description
    /// </summary>
    [SwaggerSchema(Description = "The description of the agent")]
    public string? Description { get; set; }
    
    /// <summary>
    /// Gets or sets the agent type
    /// </summary>
    [SwaggerSchema(Description = "The type of agent to create")]
    public string? Type { get; set; }
    
    /// <summary>
    /// Gets or sets the agent capabilities
    /// </summary>
    [SwaggerSchema(Description = "List of capability identifiers to assign to this agent")]
    public List<string>? Capabilities { get; set; }
    
    /// <summary>
    /// Gets or sets the agent plugins
    /// </summary>
    [SwaggerSchema(Description = "List of plugin identifiers to load for this agent")]
    public List<string>? Plugins { get; set; }
}

/// <summary>
/// DTO for updating an agent
/// </summary>
public class AgentUpdateDTO
{
    /// <summary>
    /// Gets or sets the agent name
    /// </summary>
    [SwaggerSchema(Description = "The name of the agent")]
    public string? Name { get; set; }
    
    /// <summary>
    /// Gets or sets the agent description
    /// </summary>
    [SwaggerSchema(Description = "The description of the agent")]
    public string? Description { get; set; }
    
    /// <summary>
    /// Gets or sets the agent capabilities
    /// </summary>
    [SwaggerSchema(Description = "List of capability identifiers to assign to this agent")]
    public List<string>? Capabilities { get; set; }
    
    /// <summary>
    /// Gets or sets the agent plugins
    /// </summary>
    [SwaggerSchema(Description = "List of plugin identifiers to load for this agent")]
    public List<string>? Plugins { get; set; }
}

/// <summary>
/// DTO for agent execution context
/// </summary>
public class AgentContextDTO
{
    /// <summary>
    /// Gets or sets the conversation ID
    /// </summary>
    [SwaggerSchema(Description = "Identifier for the conversation")]
    public string ConversationId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the user ID
    /// </summary>
    [SwaggerSchema(Description = "Identifier for the user")]
    public string UserId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the session ID
    /// </summary>
    [SwaggerSchema(Description = "Identifier for the session")]
    public string SessionId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the input message
    /// </summary>
    [SwaggerSchema(Description = "The input message that triggered execution")]
    public AgentMessageDTO? InputMessage { get; set; }
}

/// <summary>
/// DTO for agent message
/// </summary>
public class AgentMessageDTO
{
    /// <summary>
    /// Gets or sets the message content
    /// </summary>
    [SwaggerSchema(Description = "The content of the message")]
    public string Content { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the message type
    /// </summary>
    [SwaggerSchema(Description = "The type of message (text, image, audio, etc.)")]
    public string MessageType { get; set; } = "text";
    
    /// <summary>
    /// Gets or sets the timestamp
    /// </summary>
    [SwaggerSchema(Description = "The timestamp when the message was created")]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// DTO for agent response
/// </summary>
public class AgentResponseDTO
{
    /// <summary>
    /// Gets or sets a value indicating whether the processing was successful
    /// </summary>
    [SwaggerSchema(Description = "Indicates whether the processing was successful")]
    public bool Success { get; set; }
    
    /// <summary>
    /// Gets or sets the response message
    /// </summary>
    [SwaggerSchema(Description = "The response message from the agent")]
    public AgentMessageDTO? Message { get; set; }
    
    /// <summary>
    /// Gets or sets the error message
    /// </summary>
    [SwaggerSchema(Description = "Error message, if any")]
    public string? ErrorMessage { get; set; }
}