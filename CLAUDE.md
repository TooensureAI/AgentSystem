# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

CLAUDE (Comprehensive Learning and Understanding Distributed Evaluation) is an advanced thought processing framework built on .NET Aspire that analyzes multi-modal AI outputs across various dimensions. The framework implements an autonomous agent architecture for distributed evaluation using a modern microservices approach.

## Architecture

The solution is organized into several key projects:

- **AgentSystem.Core**: Core framework, interfaces, and agent implementations
- **AgentSystem.Plugins**: Plugin system for extending agent capabilities
- **AgentSystem.Web**: Blazor-based web interface with MAUI integration
- **AgentSystem.Mobile**: MAUI-based mobile application
- **AgentSystem.AppHost**: Aspire host for microservices architecture
- **AgentSystem.ServiceDefaults**: Default service configurations

The architecture follows a microservices design with these key components:
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

## Development Setup

### Prerequisites

- .NET 9.0 SDK
- Docker Desktop (for local development)
- SQL Server (local or remote)
- Visual Studio 2022 or VS Code with C# extensions

### Building and Running

```bash
# Build the solution
dotnet build AgentSystem.sln

# Run with Aspire
dotnet run --project AgentSystem.AppHost/AgentSystem.AppHost.csproj

# Run the web application
dotnet run --project AgentSystem.Web/AgentSystem.Web.csproj

# Run the mobile application (requires emulator/device)
dotnet run --project AgentSystem.Mobile/AgentSystem.Mobile.csproj
```

## Assessment Metrics

The framework evaluates AI systems across multiple dimensions:

| Metric | Description | Threshold |
|--------|-------------|-----------|
| Ethical Score | Alignment with ethical AI principles | ≥ 0.8 |
| Semantic Coherence | Logical consistency across outputs | ≥ 0.7 |
| Emotional Coherence | Consistency of emotional signals | ≥ 0.7 |
| Tutorial Effectiveness | Efficacy of learning content | ≥ 0.7 |
| Server Performance | Backend processing efficiency | ≥ 0.7 |
| Workflow Compliance | Adherence to development standards | ≥ 0.7 |
| Emotion Prediction | Accuracy of emotional forecasting | ≥ 0.7 |

## Development Practices

### Code Standards

Based on the `.cursor/rules` configurations:

- **Naming Conventions**:
  - Classes, methods, properties: PascalCase
  - Private fields: camelCase
  - Interfaces: IPascalCase

- **Code Structure**:
  - Maximum file length: 1000 lines
  - Maximum method length: 50 lines
  - Maximum class length: 500 lines

- **Best Practices**:
  - Use async/await for asynchronous operations
  - Avoid public fields
  - Prefer readonly fields
  - Use nullable reference types

### Git Workflow

- **Branch Naming**:
  - Features: `feature/`
  - Bug fixes: `bugfix/`
  - Releases: `release/v{major}.{minor}.{patch}`

- **Commit Messages**: Use conventional commits format:
  - feat: A new feature
  - fix: A bug fix
  - docs: Documentation only changes
  - style: Changes that do not affect the meaning of the code
  - refactor: A code change that neither fixes a bug nor adds a feature
  - perf: A code change that improves performance
  - test: Adding missing tests or correcting existing tests
  - build: Changes that affect the build system or external dependencies
  - ci: Changes to our CI configuration files and scripts
  - chore: Other changes that don't modify src or test files
  - revert: Reverts a previous commit

## Agent and Plugin Development

### Agent Template

```csharp
/**
 * @class {className}
 * @description {description}
 * @implements {interfaces}
 */
public class {className} : IAgent
{
    private readonly ILogger<{className}> _logger;

    public {className}(ILogger<{className}> logger)
    {
        _logger = logger;
    }

    public async Task ExecuteAsync()
    {
        // Agent implementation
    }
}
```

### Plugin Template

```csharp
/**
 * @class {className}
 * @description {description}
 * @implements {interfaces}
 */
public class {className} : IPlugin
{
    private readonly ILogger<{className}> _logger;

    public {className}(ILogger<{className}> logger)
    {
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        // Plugin initialization
    }
}
```

## Prompty System

The project uses a template-driven approach with `.prompty` files organized in these categories:

- **bootstrap**: System initialization and capability assessment
- **evolution**: System evolution, plugin generation, and evaluation
- **personas**: Different agent personas (developer, architect, QA, etc.)
- **tasks**: Task-specific templates (analysis, generation, evaluation, etc.)
- **templates**: Core reasoning and operational templates

## API Usage

The main assessment endpoint accepts JSON input:

```http
POST /api/assessment
Content-Type: application/json

{
  "metaReflection": { ... },
  "multiModalOutput": { ... },
  "embodiedCognitionOutput": { ... },
  // other outputs...
}
```

## Configuration

Edit `appsettings.json` in the AppHost project to configure system settings:

```json
{
  "Aspire": {
    "Dashboard": {
      "Enabled": true,
      "Port": 18888
    }
  },
  "Assessment": {
    "ValidationThresholds": {
      "EthicalScore": 0.8,
      // other thresholds...
    }
  }
}
```