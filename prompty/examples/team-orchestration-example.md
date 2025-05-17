# Team Orchestration Example

This example demonstrates how to use the NoCodeAI Prompty architecture for orchestrating a team of AI personas to collaborate on a complex project.

## Project Overview

In this example, we'll create a data visualization dashboard with AI-driven insights for business metrics.

## Step 1: Configure the Team Composition

Create a team configuration file named `data-dashboard-team.json`:

```json
{
  "orchestratorName": "Morgan",
  "orchestratorSpecialty": "Data Product Development",
  "orchestratorCommunicationStyle": "Analytical and collaborative",
  "orchestratorDecisionFramework": "Data-driven with user focus",
  "teamMembers": [
    {
      "role": "Data Scientist",
      "name": "Dana",
      "specialty": "Predictive Analytics",
      "strengths": "Statistical modeling, ML algorithms, trend analysis",
      "approach": "Hypothesis-driven data exploration",
      "bestUsedFor": "Extracting insights and building prediction models"
    },
    {
      "role": "Developer",
      "name": "Derek",
      "specialty": "Full-stack Development",
      "strengths": "React, TypeScript, C#, API development",
      "approach": "Component-based architecture with reusable parts",
      "bestUsedFor": "Building interactive visualizations and dashboards"
    },
    {
      "role": "Product Manager",
      "name": "Priya",
      "specialty": "Data Products",
      "strengths": "User research, product strategy, metrics definition",
      "approach": "User-centered design with business outcomes focus",
      "bestUsedFor": "Ensuring the dashboard delivers business value"
    },
    {
      "role": "Architect",
      "name": "Anna",
      "specialty": "Data System Architecture",
      "strengths": "Data pipelines, real-time processing, scalable systems",
      "approach": "Modular architecture with separation of concerns",
      "bestUsedFor": "Designing the overall system architecture"
    }
  ],
  "task": "Create a business metrics dashboard with AI-driven insights and predictive analytics",
  "projectContext": {
    "domain": "Retail E-commerce",
    "dataAvailable": ["sales", "inventory", "customer", "marketing", "website analytics"],
    "keyMetrics": ["revenue", "conversion rate", "customer acquisition cost", "inventory turnover"],
    "targetUsers": ["executives", "department managers", "data analysts"],
    "integrations": ["ERP system", "CRM", "Marketing platform"]
  }
}
```

## Step 2: Execute the Team Orchestrator

Run the following command to execute the team orchestrator prompty:

```bash
prompty-processor process-file --file "/prompty/personas/team-orchestrator.prompty" --params "data-dashboard-team.json" --output "team-orchestration.json"
```

This will produce a detailed plan with tasks delegated to each team member.

## Step 3: Concurrent Execution of Team Member Prompties

Extract parameters for each team member:

```bash
jq '.delegation_plan.data_scientist' team-orchestration.json > data-scientist-params.json
jq '.delegation_plan.developer' team-orchestration.json > developer-params.json
jq '.delegation_plan.product_manager' team-orchestration.json > product-manager-params.json
jq '.delegation_plan.architect' team-orchestration.json > architect-params.json
```

Execute all team member prompties in parallel:

```bash
prompty-processor process-file --file "/prompty/personas/data-scientist-persona.prompty" --params "data-scientist-params.json" --output "data-scientist-output.json" &
prompty-processor process-file --file "/prompty/personas/developer-persona.prompty" --params "developer-params.json" --output "developer-output.json" &
prompty-processor process-file --file "/prompty/personas/product-manager-persona.prompty" --params "product-manager-params.json" --output "product-manager-output.json" &
prompty-processor process-file --file "/prompty/personas/architect-persona.prompty" --params "architect-params.json" --output "architect-output.json" &
wait
```

## Step 4: Integration Phase

Create a team integration input file:

```json
{
  "orchestratorName": "Morgan",
  "orchestratorSpecialty": "Data Product Development",
  "teamOutputs": {
    "data_scientist": "data-scientist-output.json",
    "developer": "developer-output.json",
    "product_manager": "product-manager-output.json",
    "architect": "architect-output.json"
  },
  "integrationObjectives": [
    "Combine all team contributions into a cohesive solution",
    "Resolve any conflicts or inconsistencies between components",
    "Ensure all requirements are satisfied",
    "Create an implementation plan with clear dependencies"
  ],
  "outputFormat": "detailed"
}
```

Execute the team integration prompty:

```bash
prompty-processor process-file --file "/prompty/personas/team-integration.prompty" --params "team-integration-input.json" --output "integrated-solution.json"
```

## Step 5: Generate Implementation Files

Create an implementation input file:

```json
{
  "projectName": "RetailMetricsDashboard",
  "integratedSolution": "integrated-solution.json",
  "implementationDetails": {
    "frontendFramework": "React with TypeScript",
    "backendFramework": ".NET 9.0",
    "dataProcessing": "Azure Data Factory",
    "analytics": "ML.NET",
    "deployment": "Azure App Service"
  },
  "outputDirectory": "./RetailMetricsDashboard"
}
```

Execute the implementation generator:

```bash
prompty-processor process-file --file "/prompty/tasks/generation/generate-implementation.prompty" --params "implementation-input.json" --output "implementation-details.json"
```

## The Team Orchestration Process

The orchestration happens in several stages:

1. **Planning Stage**: The team orchestrator reviews the task and project context, determining the optimal approach and division of work.

2. **Delegation Stage**: Work is assigned to team members based on their specialties and strengths.

3. **Execution Stage**: Each team member works independently on their assigned tasks.

4. **Integration Stage**: All outputs are combined into a cohesive solution.

5. **Implementation Stage**: The integrated solution is converted into actual implementation files.

Throughout the process, the team orchestrator maintains consistency by ensuring that each team member has the context they need and that their outputs align with the overall objectives.

## Benefits of Team Orchestration

This approach offers several advantages:

1. **Specialized Expertise**: Each persona contributes their specialized knowledge.
2. **Parallel Work**: Team members can work simultaneously on different aspects.
3. **Comprehensive Coverage**: All aspects of the project are addressed.
4. **Consistent Vision**: The orchestrator ensures alignment.
5. **Faster Development**: The parallel processing accelerates delivery.

The end result is a complete solution that combines data science insights, high-quality implementation, user-centered design, and robust architecture - all working together seamlessly.