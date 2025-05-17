# AgentSystem

A comprehensive .NET-based framework for building and orchestrating autonomous agents with web and mobile interfaces.

## Overview

AgentSystem is built on .NET Aspire and MAUI to provide a robust platform for creating, configuring, and managing autonomous agents. The framework supports plug-in based extensibility, template-driven agent behaviors, and comprehensive evaluation metrics.

## Project Structure

- **AgentSystem.Core**: Core agent framework, interfaces, and base implementations
- **AgentSystem.Plugins**: Plugin system for extending agent capabilities
- **AgentSystem.Web**: Blazor-based web interface with MAUI integration
- **AgentSystem.Mobile**: MAUI-based mobile application
- **AgentSystem.AppHost**: Aspire host for microservices architecture
- **AgentSystem.ServiceDefaults**: Default service configurations

## Key Features

- **Multi-Modal Analysis**: Evaluates agent outputs across different modalities
- **Plugin Architecture**: Extensible plugin system for adding new capabilities
- **Template-Driven Design**: Uses .prompty files to define agent behaviors
- **Cross-Platform UI**: Web and mobile interfaces built with MAUI
- **Distributed Evaluation**: Comprehensive metrics for assessing agent performance

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or later / VS Code
- Docker Desktop (for local development)

### Building and Running

```bash
# Restore dependencies
dotnet restore AgentSystem.sln

# Build the solution
dotnet build AgentSystem.sln

# Run the web application
dotnet run --project AgentSystem.Web/AgentSystem.Web.csproj

# Run the mobile application (requires emulator/device)
dotnet run --project AgentSystem.Mobile/AgentSystem.Mobile.csproj

# Run the AppHost (for microservices architecture)
dotnet run --project AgentSystem.AppHost/AgentSystem.AppHost.csproj
```

## Development

See CLAUDE.md for detailed information about the development workflow, coding standards, and architecture.

## License

This project is licensed under the MIT License.