# Simple API Example

This example demonstrates how to use the NoCodeAI Prompty architecture to create a RESTful API for a product catalog system.

## Step 1: Define Input Parameters

Create a file named `api-input-params.json` with the following content:

```json
{
  "orchestratorName": "Alex",
  "orchestratorSpecialty": "API Development",
  "orchestratorCommunicationStyle": "Clear and concise",
  "orchestratorDecisionFramework": "Best practices and team strengths",
  "teamMembers": [
    {
      "role": "Architect",
      "name": "Anna",
      "specialty": "API Design",
      "strengths": "RESTful design, security patterns, scalability",
      "approach": "Security and scalability focused",
      "bestUsedFor": "Creating robust API architectures"
    },
    {
      "role": "Developer",
      "name": "Dave",
      "specialty": "Backend Development",
      "strengths": "C#, Entity Framework, ASP.NET Core",
      "approach": "Clean code with thorough testing",
      "bestUsedFor": "Implementing API endpoints and business logic"
    },
    {
      "role": "QA Tester",
      "name": "Quinn",
      "specialty": "API Testing",
      "strengths": "Postman, automation, edge cases",
      "approach": "Comprehensive test coverage",
      "bestUsedFor": "Ensuring API quality and reliability"
    }
  ],
  "task": "Create a RESTful product catalog API with CRUD operations and search functionality",
  "technicalContext": {
    "language": "C#",
    "framework": ".NET 9.0",
    "architecture": "Clean Architecture",
    "database": "PostgreSQL with EF Core",
    "authentication": "JWT with role-based authorization"
  }
}
```

## Step 2: Execute the Team Orchestrator

Run the following command to execute the team orchestrator prompty:

```bash
prompty-processor process-file --file "/prompty/personas/team-orchestrator.prompty" --params "api-input-params.json" --output "team-output.json"
```

This will produce an output file with the team's plan and task delegation.

## Step 3: Execute the Architect's Prompty

Extract the architect's input parameters from the team output:

```bash
jq '.delegation_plan.architect' team-output.json > architect-params.json
```

Now execute the architect's prompty:

```bash
prompty-processor process-file --file "/prompty/personas/architect-persona.prompty" --params "architect-params.json" --output "architect-output.json"
```

The architect will produce an architecture design for the API.

## Step 4: Execute the Developer's Prompty

Extract the developer's input parameters:

```bash
jq '.delegation_plan.developer' team-output.json > developer-params.json
```

Execute the developer's prompty:

```bash
prompty-processor process-file --file "/prompty/personas/developer-persona.prompty" --params "developer-params.json" --output "developer-output.json"
```

The developer will implement the API based on the architect's design.

## Step 5: Execute the QA Tester's Prompty

Extract the QA tester's input parameters:

```bash
jq '.delegation_plan.qa_tester' team-output.json > qa-params.json
```

Execute the QA tester's prompty:

```bash
prompty-processor process-file --file "/prompty/personas/qa-tester-persona.prompty" --params "qa-params.json" --output "qa-output.json"
```

The QA tester will create tests for the API.

## Step 6: Integrate the Components

Create an integration parameters file:

```json
{
  "projectName": "ProductCatalogAPI",
  "components": {
    "architecture": "architect-output.json",
    "implementation": "developer-output.json",
    "tests": "qa-output.json"
  },
  "integrationStrategy": "Continuous Integration",
  "outputDirectory": "./ProductCatalogAPI"
}
```

Execute the integration prompty:

```bash
prompty-processor process-file --file "/prompty/tasks/integration/integrate-components.prompty" --params "integration-params.json" --output "final-solution.json"
```

The final solution will be generated in the `ProductCatalogAPI` directory, with all components properly integrated.

## Examining the Results

The generated API will include:

1. A clean architecture project structure
2. Model classes for products and categories
3. Repository implementations with CRUD operations
4. Controllers with RESTful endpoints
5. Search functionality with filtering capabilities
6. Authentication and authorization middleware
7. Unit and integration tests for all components
8. Complete API documentation

The team orchestration approach ensures that each persona contributes their expertise to the final solution, resulting in a high-quality API implementation.