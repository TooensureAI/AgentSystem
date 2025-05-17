var builder = DistributedApplication.CreateBuilder(args);

// Configure API settings
var api = builder.AddProject<Projects.AgentSystem_Api>("api")
    .WithEndpoints("http", "https");

// Add agent system components
builder.AddProject<Projects.AgentSystem_Core>("core");

// Set dashboard (required as of .NET 9/Aspire 9.0)
builder.AddDashboard(options => {
    options.Port = 18888;
});

builder.Build().Run();
