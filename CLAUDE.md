# CLAUDE: Comprehensive Learning and Understanding Distributed Evaluation Framework

## Overview

CLAUDE (Comprehensive Learning and Understanding Distributed Evaluation) is an advanced thought processing framework built on .NET 9 and Aspire 9.2 that analyzes multi-modal AI outputs across various dimensions. It provides a comprehensive assessment of AI system performance through distributed microservices architecture.

## Key Features

- **Multi-Modal Analysis**: Evaluates outputs across text, visual, and audio modalities
- **Embodied Cognition**: Assesses gesture and movement understanding capabilities
- **Cross-Modal Integration**: Measures coherence across different input/output channels
- **Educational Effectiveness**: Quantifies tutorial and learning facilitation
- **Workflow Compliance**: Verifies development processes adherence
- **Predictive Analytics**: Evaluates emotional prediction accuracy
- **Ethical Alignment**: Ensures outputs meet ethical standards

## Architecture

CLAUDE is built using a modern microservices architecture with .NET 9 and Aspire 9.2:

```
┌─────────────────────────────────────────────────────────────────┐
│                           API Gateway                           │
└───────────────────────────────┬─────────────────────────────────┘
                                │
        ┌─────────────────────────────────────────────┐
        │                                             │
┌───────┴────────┐     ┌──────────────────┐     ┌────┴────────┐
│ Core Services  │     │ Analysis Services│     │Infrastructure│
├────────────────┤     ├──────────────────┤     ├─────────────┤
│MultiModalProc  │     │SemanticAnchor    │     │Redis Cache  │
│EmbodiedCognit  │     │PredictiveSentim  │     │SQL Server   │
│CrossModalFeedb │     │Ethics            │     │Service Bus  │
│TutorialEngine  │     │                  │     │             │
│MCPProcessor    │     │                  │     │             │
│WorkflowValidat │     │                  │     │             │
└────────────────┘     └──────────────────┘     └─────────────┘
```

Each service references the shared ServiceDefaults project directly, which provides common configuration for:
- Service discovery
- Health checks
- Resilience policies
- OpenTelemetry integration
- Standardized HTTP client behavior

## Assessment Metrics

CLAUDE evaluates systems across multiple dimensions:

| Metric | Description | Threshold |
|--------|-------------|-----------|
| Ethical Score | Alignment with ethical AI principles | ≥ 0.8 |
| Semantic Coherence | Logical consistency across outputs | ≥ 0.7 |
| Emotional Coherence | Consistency of emotional signals | ≥ 0.7 |
| Tutorial Effectiveness | Efficacy of learning content | ≥ 0.7 |
| Server Performance | Backend processing efficiency | ≥ 0.7 |
| Workflow Compliance | Adherence to development standards | ≥ 0.7 |
| Emotion Prediction | Accuracy of emotional forecasting | ≥ 0.7 |

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Aspire 9.2 workload
- Docker Desktop (for local development)
- SQL Server (local or remote)
- Visual Studio 2022 (17.10+) or VS Code with C# extensions

### Installation

1. Install .NET 9 SDK and Aspire 9.2 workload:
   ```bash
   dotnet workload install aspire
   ```

2. Clone the repository:
   ```bash
   git clone https://github.com/your-org/claude-framework.git
   cd claude-framework
   ```

3. Build the solution:
   ```bash
   dotnet build
   ```

4. Run with Aspire:
   ```bash
   dotnet run --project ThoughtProcessor.AppHost
   ```

5. Access the dashboard and API documentation:
   ```
   Dashboard: https://localhost:18888
   API Documentation: https://localhost:5000
   ```

### Configuration

Edit `appsettings.json` in the AppHost project to configure:

```json
{
  "Aspire": {
    "Dashboard": {
      "Enabled": true,
      "Port": 18888
    },
    "HealthChecks": {
      "Enabled": true,
      "DetailedOutput": true
    },
    "Telemetry": {
      "Exporters": {
        "Console": true,
        "OTLP": true
      }
    }
  },
  "Assessment": {
    "ValidationThresholds": {
      "EthicalScore": 0.8,
      "SemanticCoherenceScore": 0.7,
      "EmotionalCoherenceScore": 0.7,
      "TutorialEffectivenessScore": 0.7,
      "ServerPerformanceScore": 0.7,
      "WorkflowComplianceScore": 0.7,
      "EmotionPredictionAccuracy": 0.7
    }
  }
}
```

## Usage

### API Endpoints

The main assessment endpoint accepts JSON input matching the template schema:

```http
POST /api/assessment
Content-Type: application/json

{
  "metaReflection": { ... },
  "multiModalOutput": { ... },
  "embodiedCognitionOutput": { ... },
  "gestureOutput": { ... },
  "voiceOutput": { ... },
  "crossModalFeedback": { ... },
  "educationalOutput": { ... },
  "mcpServerOutput": { ... },
  "workflowComplianceOutput": { ... },
  "thoughtChain": { ... },
  "systemState": { ... }
}
```

### Response Format

```json
{
  "assessment": {
    "gaps": [
      "Limited contextual awareness",
      "Insufficient cross-modal integration"
    ],
    "opportunities": [
      "Enhance visual-textual alignment",
      "Improve emotion recognition"
    ],
    "ethical_score": 0.92,
    "semantic_coherence_score": 0.85,
    "emotional_coherence_score": 0.78,
    "tutorial_effectiveness_score": 0.85,
    "server_performance_score": 0.89,
    "workflow_compliance_score": 0.78,
    "workflow_compliance_details": {
      "branch_compliance_score": 0.82,
      "commit_compliance_score": 0.75,
      "pr_compliance_score": 0.77
    },
    "emotion_prediction_accuracy": 0.88
  }
}
```

## Extending CLAUDE

### Adding New Analyzers

1. Create a new project for your analyzer:
   ```bash
   dotnet new webapi -n ThoughtProcessor.NewAnalyzer
   ```

2. Implement the analyzer interface:
   ```csharp
   public interface INewAnalyzer
   {
       Task<NewAnalyzerResult> AnalyzeAsync(NewAnalyzerInput input);
   }
   ```

3. Add the analyzer to AppHost:
   ```csharp
   var newAnalyzer = builder.AddProject<Projects.ThoughtProcessor_NewAnalyzer>("newanalyzer")
       .WithReference(serviceDefaults);
   ```

4. Reference it in the API Gateway.

### Custom Validation Rules

Add new validation rules by editing the `ValidationRules` in the template:

```json
{
  "rule": "output.assessment.new_metric_score >= 0.7",
  "errorMessage": "New metric below threshold"
}
```

## Integration with AI Systems

CLAUDE can be used to evaluate large language models, multimodal AI systems, and other cognitive architectures. It provides standardized metrics and identifies improvement opportunities.

### Integration Example

```csharp
// Client-side integration
using var client = new HttpClient();
client.BaseAddress = new Uri("https://claude-api.example.com/");

var assessmentRequest = new AssessmentInput
{
    MultiModalOutput = captureMultiModalOutput(),
    EmbodiedCognitionOutput = captureEmbodiedOutput(),
    // ... other outputs
};

var response = await client.PostAsJsonAsync("api/assessment", assessmentRequest);
var result = await response.Content.ReadFromJsonAsync<AssessmentResult>();

// Process assessment results
if (result.Assessment.EthicalScore < 0.8)
{
    // Take corrective action
}
```

## Contributing

We welcome contributions to the CLAUDE framework:

1. Fork the repository
2. Create a feature branch
## GitHub Integration

CLAUDE includes a robust GitHub integration service that monitors Semantic Kernel updates:

### Features

- **Automated Repository Monitoring**: Tracks specified GitHub repositories (like Microsoft's Semantic Kernel) for changes
- **Release Detection**: Identifies new releases and extracts key information from release notes
- **Commit Analysis**: Monitors commits for breaking changes, API modifications, and security updates
- **Version Comparison**: Automatically detects if current Semantic Kernel version is outdated
- **Performance Metrics**: Evaluates server performance against latest available features
- **Update Notifications**: Provides actionable insights when updates are available

### Configuration

Set up GitHub monitoring in your `appsettings.json`:

```json
{
  "GitHub": {
    "Token": "your-github-token",
    "ClientName": "CLAUDE-Framework",
    "Repositories": [
      {
        "Owner": "microsoft",
        "Name": "semantic-kernel",
        "Branch": "main",
        "TagPrefix": "v"
      }
    ]
  }
}
```