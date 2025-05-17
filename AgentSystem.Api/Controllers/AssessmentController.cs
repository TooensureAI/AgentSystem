using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace AgentSystem.Api.Controllers;

/// <summary>
/// Controller for agent assessment and evaluation
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class AssessmentController : ControllerBase
{
    private readonly ILogger<AssessmentController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AssessmentController"/> class
    /// </summary>
    public AssessmentController(ILogger<AssessmentController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Evaluates agent outputs across multiple dimensions
    /// </summary>
    /// <param name="input">The assessment input</param>
    /// <returns>The assessment result</returns>
    /// <response code="200">Returns the assessment result</response>
    /// <response code="400">If the input is invalid</response>
    /// <response code="401">If the user is not authenticated</response>
    [HttpPost]
    [Authorize]
    [SwaggerOperation(
        Summary = "Evaluate agent output",
        Description = "Evaluates agent outputs across multiple dimensions",
        OperationId = "EvaluateAgent",
        Tags = new[] { "Assessment" }
    )]
    [SwaggerResponse(200, "Success", typeof(AssessmentResultDTO))]
    [SwaggerResponse(400, "Bad Request")]
    [SwaggerResponse(401, "Unauthorized")]
    public IActionResult EvaluateAgent([FromBody] AssessmentInputDTO input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // In a real implementation, this would perform actual evaluation
        var result = new AssessmentResultDTO
        {
            Assessment = new AssessmentOutputDTO
            {
                Gaps = new List<string> { "Limited contextual awareness", "Insufficient cross-modal integration" },
                Opportunities = new List<string> { "Enhance visual-textual alignment", "Improve emotion recognition" },
                EthicalScore = 0.92f,
                SemanticCoherenceScore = 0.85f,
                EmotionalCoherenceScore = 0.78f,
                TutorialEffectivenessScore = 0.85f,
                ServerPerformanceScore = 0.89f,
                WorkflowComplianceScore = 0.78f,
                WorkflowComplianceDetails = new WorkflowComplianceDetailsDTO
                {
                    BranchComplianceScore = 0.82f,
                    CommitComplianceScore = 0.75f,
                    PrComplianceScore = 0.77f
                },
                EmotionPredictionAccuracy = 0.88f
            }
        };

        return Ok(result);
    }

    /// <summary>
    /// Gets assessment metrics thresholds
    /// </summary>
    /// <returns>The assessment thresholds</returns>
    /// <response code="200">Returns the assessment thresholds</response>
    /// <response code="401">If the user is not authenticated</response>
    [HttpGet("thresholds")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Get assessment thresholds",
        Description = "Returns the threshold values for assessment metrics",
        OperationId = "GetAssessmentThresholds",
        Tags = new[] { "Assessment" }
    )]
    [SwaggerResponse(200, "Success", typeof(AssessmentThresholdsDTO))]
    [SwaggerResponse(401, "Unauthorized")]
    public IActionResult GetAssessmentThresholds()
    {
        var thresholds = new AssessmentThresholdsDTO
        {
            EthicalScore = 0.8f,
            SemanticCoherenceScore = 0.7f,
            EmotionalCoherenceScore = 0.7f,
            TutorialEffectivenessScore = 0.7f,
            ServerPerformanceScore = 0.7f,
            WorkflowComplianceScore = 0.7f,
            EmotionPredictionAccuracy = 0.7f
        };

        return Ok(thresholds);
    }

    /// <summary>
    /// Beta feature: Advanced assessment with real-time feedback
    /// </summary>
    /// <param name="input">The assessment input</param>
    /// <returns>The detailed assessment result</returns>
    /// <response code="200">Returns the detailed assessment result</response>
    /// <response code="400">If the input is invalid</response>
    /// <response code="401">If the user is not authenticated</response>
    [HttpPost("advanced")]
    [ApiVersion("2.0")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Perform advanced assessment",
        Description = "Beta feature: Evaluates agent outputs with more detailed metrics and real-time feedback",
        OperationId = "AdvancedEvaluateAgent",
        Tags = new[] { "Assessment" }
    )]
    [SwaggerResponse(200, "Success", typeof(DetailedAssessmentResultDTO))]
    [SwaggerResponse(400, "Bad Request")]
    [SwaggerResponse(401, "Unauthorized")]
    public IActionResult AdvancedEvaluateAgent([FromBody] AssessmentInputDTO input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // In a real implementation, this would perform actual evaluation
        var result = new DetailedAssessmentResultDTO
        {
            Assessment = new DetailedAssessmentOutputDTO
            {
                Gaps = new List<string> { "Limited contextual awareness", "Insufficient cross-modal integration" },
                Opportunities = new List<string> { "Enhance visual-textual alignment", "Improve emotion recognition" },
                Metrics = new AssessmentMetricsDTO
                {
                    EthicalScore = 0.92f,
                    SemanticCoherenceScore = 0.85f,
                    EmotionalCoherenceScore = 0.78f,
                    TutorialEffectivenessScore = 0.85f,
                    ServerPerformanceScore = 0.89f,
                    WorkflowComplianceScore = 0.78f,
                    EmotionPredictionAccuracy = 0.88f
                },
                DetailedMetrics = new Dictionary<string, Dictionary<string, float>>
                {
                    ["ethical"] = new Dictionary<string, float>
                    {
                        ["bias"] = 0.95f,
                        ["fairness"] = 0.93f,
                        ["transparency"] = 0.89f,
                        ["safety"] = 0.91f
                    },
                    ["semantic"] = new Dictionary<string, float>
                    {
                        ["consistency"] = 0.86f,
                        ["relevance"] = 0.88f,
                        ["accuracy"] = 0.82f,
                        ["clarity"] = 0.84f
                    }
                },
                Feedback = new List<FeedbackItemDTO>
                {
                    new FeedbackItemDTO
                    {
                        Category = "Ethical",
                        Type = "Improvement",
                        Message = "Excellent bias mitigation in demographic references",
                        Severity = "Low",
                        Score = 0.95f
                    },
                    new FeedbackItemDTO
                    {
                        Category = "Semantic",
                        Type = "Issue",
                        Message = "Minor inconsistency detected in temporal references",
                        Severity = "Medium",
                        Score = 0.82f
                    }
                },
                Recommendations = new List<string>
                {
                    "Implement more robust cross-modal integration",
                    "Enhance context awareness with background knowledge integration",
                    "Improve handling of ambiguous user inputs"
                }
            },
            Timestamp = DateTime.UtcNow,
            ProcessingTimeMs = 354
        };

        return Ok(result);
    }
}

/// <summary>
/// DTO for assessment input
/// </summary>
public class AssessmentInputDTO
{
    /// <summary>
    /// Gets or sets the meta-reflection data
    /// </summary>
    [SwaggerSchema(Description = "Meta-reflection data")]
    public Dictionary<string, object>? MetaReflection { get; set; }
    
    /// <summary>
    /// Gets or sets the multi-modal output data
    /// </summary>
    [SwaggerSchema(Description = "Multi-modal output data")]
    public Dictionary<string, object>? MultiModalOutput { get; set; }
    
    /// <summary>
    /// Gets or sets the embodied cognition output data
    /// </summary>
    [SwaggerSchema(Description = "Embodied cognition output data")]
    public Dictionary<string, object>? EmbodiedCognitionOutput { get; set; }
    
    /// <summary>
    /// Gets or sets the gesture output data
    /// </summary>
    [SwaggerSchema(Description = "Gesture output data")]
    public Dictionary<string, object>? GestureOutput { get; set; }
    
    /// <summary>
    /// Gets or sets the voice output data
    /// </summary>
    [SwaggerSchema(Description = "Voice output data")]
    public Dictionary<string, object>? VoiceOutput { get; set; }
    
    /// <summary>
    /// Gets or sets the cross-modal feedback data
    /// </summary>
    [SwaggerSchema(Description = "Cross-modal feedback data")]
    public Dictionary<string, object>? CrossModalFeedback { get; set; }
    
    /// <summary>
    /// Gets or sets the educational output data
    /// </summary>
    [SwaggerSchema(Description = "Educational output data")]
    public Dictionary<string, object>? EducationalOutput { get; set; }
}

/// <summary>
/// DTO for assessment result
/// </summary>
public class AssessmentResultDTO
{
    /// <summary>
    /// Gets or sets the assessment output
    /// </summary>
    [SwaggerSchema(Description = "Assessment output")]
    public AssessmentOutputDTO Assessment { get; set; } = new();
}

/// <summary>
/// DTO for assessment output
/// </summary>
public class AssessmentOutputDTO
{
    /// <summary>
    /// Gets or sets the identified gaps
    /// </summary>
    [SwaggerSchema(Description = "Identified gaps in agent performance")]
    public List<string> Gaps { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the identified opportunities
    /// </summary>
    [SwaggerSchema(Description = "Identified opportunities for improvement")]
    public List<string> Opportunities { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the ethical score
    /// </summary>
    [SwaggerSchema(Description = "Score for alignment with ethical AI principles")]
    public float EthicalScore { get; set; }
    
    /// <summary>
    /// Gets or sets the semantic coherence score
    /// </summary>
    [SwaggerSchema(Description = "Score for logical consistency across outputs")]
    public float SemanticCoherenceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the emotional coherence score
    /// </summary>
    [SwaggerSchema(Description = "Score for consistency of emotional signals")]
    public float EmotionalCoherenceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the tutorial effectiveness score
    /// </summary>
    [SwaggerSchema(Description = "Score for efficacy of learning content")]
    public float TutorialEffectivenessScore { get; set; }
    
    /// <summary>
    /// Gets or sets the server performance score
    /// </summary>
    [SwaggerSchema(Description = "Score for backend processing efficiency")]
    public float ServerPerformanceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the workflow compliance score
    /// </summary>
    [SwaggerSchema(Description = "Score for adherence to development standards")]
    public float WorkflowComplianceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the workflow compliance details
    /// </summary>
    [SwaggerSchema(Description = "Detailed scores for workflow compliance")]
    public WorkflowComplianceDetailsDTO WorkflowComplianceDetails { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the emotion prediction accuracy
    /// </summary>
    [SwaggerSchema(Description = "Score for accuracy of emotional forecasting")]
    public float EmotionPredictionAccuracy { get; set; }
}

/// <summary>
/// DTO for workflow compliance details
/// </summary>
public class WorkflowComplianceDetailsDTO
{
    /// <summary>
    /// Gets or sets the branch compliance score
    /// </summary>
    [SwaggerSchema(Description = "Score for branch naming compliance")]
    public float BranchComplianceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the commit compliance score
    /// </summary>
    [SwaggerSchema(Description = "Score for commit message compliance")]
    public float CommitComplianceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the PR compliance score
    /// </summary>
    [SwaggerSchema(Description = "Score for pull request compliance")]
    public float PrComplianceScore { get; set; }
}

/// <summary>
/// DTO for assessment thresholds
/// </summary>
public class AssessmentThresholdsDTO
{
    /// <summary>
    /// Gets or sets the ethical score threshold
    /// </summary>
    [SwaggerSchema(Description = "Threshold for ethical score")]
    public float EthicalScore { get; set; }
    
    /// <summary>
    /// Gets or sets the semantic coherence score threshold
    /// </summary>
    [SwaggerSchema(Description = "Threshold for semantic coherence score")]
    public float SemanticCoherenceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the emotional coherence score threshold
    /// </summary>
    [SwaggerSchema(Description = "Threshold for emotional coherence score")]
    public float EmotionalCoherenceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the tutorial effectiveness score threshold
    /// </summary>
    [SwaggerSchema(Description = "Threshold for tutorial effectiveness score")]
    public float TutorialEffectivenessScore { get; set; }
    
    /// <summary>
    /// Gets or sets the server performance score threshold
    /// </summary>
    [SwaggerSchema(Description = "Threshold for server performance score")]
    public float ServerPerformanceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the workflow compliance score threshold
    /// </summary>
    [SwaggerSchema(Description = "Threshold for workflow compliance score")]
    public float WorkflowComplianceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the emotion prediction accuracy threshold
    /// </summary>
    [SwaggerSchema(Description = "Threshold for emotion prediction accuracy")]
    public float EmotionPredictionAccuracy { get; set; }
}

/// <summary>
/// DTO for detailed assessment result (v2)
/// </summary>
public class DetailedAssessmentResultDTO
{
    /// <summary>
    /// Gets or sets the detailed assessment output
    /// </summary>
    [SwaggerSchema(Description = "Detailed assessment output")]
    public DetailedAssessmentOutputDTO Assessment { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the timestamp
    /// </summary>
    [SwaggerSchema(Description = "Timestamp of the assessment")]
    public DateTime Timestamp { get; set; }
    
    /// <summary>
    /// Gets or sets the processing time in milliseconds
    /// </summary>
    [SwaggerSchema(Description = "Processing time in milliseconds")]
    public int ProcessingTimeMs { get; set; }
}

/// <summary>
/// DTO for detailed assessment output (v2)
/// </summary>
public class DetailedAssessmentOutputDTO
{
    /// <summary>
    /// Gets or sets the identified gaps
    /// </summary>
    [SwaggerSchema(Description = "Identified gaps in agent performance")]
    public List<string> Gaps { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the identified opportunities
    /// </summary>
    [SwaggerSchema(Description = "Identified opportunities for improvement")]
    public List<string> Opportunities { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the metrics
    /// </summary>
    [SwaggerSchema(Description = "Overall assessment metrics")]
    public AssessmentMetricsDTO Metrics { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the detailed metrics
    /// </summary>
    [SwaggerSchema(Description = "Detailed assessment metrics by category")]
    public Dictionary<string, Dictionary<string, float>> DetailedMetrics { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the feedback items
    /// </summary>
    [SwaggerSchema(Description = "Specific feedback items")]
    public List<FeedbackItemDTO> Feedback { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the recommendations
    /// </summary>
    [SwaggerSchema(Description = "Recommendations for improvement")]
    public List<string> Recommendations { get; set; } = new();
}

/// <summary>
/// DTO for assessment metrics
/// </summary>
public class AssessmentMetricsDTO
{
    /// <summary>
    /// Gets or sets the ethical score
    /// </summary>
    [SwaggerSchema(Description = "Score for alignment with ethical AI principles")]
    public float EthicalScore { get; set; }
    
    /// <summary>
    /// Gets or sets the semantic coherence score
    /// </summary>
    [SwaggerSchema(Description = "Score for logical consistency across outputs")]
    public float SemanticCoherenceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the emotional coherence score
    /// </summary>
    [SwaggerSchema(Description = "Score for consistency of emotional signals")]
    public float EmotionalCoherenceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the tutorial effectiveness score
    /// </summary>
    [SwaggerSchema(Description = "Score for efficacy of learning content")]
    public float TutorialEffectivenessScore { get; set; }
    
    /// <summary>
    /// Gets or sets the server performance score
    /// </summary>
    [SwaggerSchema(Description = "Score for backend processing efficiency")]
    public float ServerPerformanceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the workflow compliance score
    /// </summary>
    [SwaggerSchema(Description = "Score for adherence to development standards")]
    public float WorkflowComplianceScore { get; set; }
    
    /// <summary>
    /// Gets or sets the emotion prediction accuracy
    /// </summary>
    [SwaggerSchema(Description = "Score for accuracy of emotional forecasting")]
    public float EmotionPredictionAccuracy { get; set; }
}

/// <summary>
/// DTO for feedback item
/// </summary>
public class FeedbackItemDTO
{
    /// <summary>
    /// Gets or sets the category
    /// </summary>
    [SwaggerSchema(Description = "Category of the feedback")]
    public string Category { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the type
    /// </summary>
    [SwaggerSchema(Description = "Type of feedback (Issue, Improvement, etc.)")]
    public string Type { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the message
    /// </summary>
    [SwaggerSchema(Description = "Feedback message")]
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the severity
    /// </summary>
    [SwaggerSchema(Description = "Severity level (Low, Medium, High)")]
    public string Severity { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the score
    /// </summary>
    [SwaggerSchema(Description = "Score associated with this feedback item")]
    public float Score { get; set; }
}