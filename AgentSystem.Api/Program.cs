using System.Reflection;
using System.Text;
using AgentSystem.Api.Filters;
using AgentSystem.Core.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
});

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = ApiVersion.Default;
});

// Configure JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "DefaultSecretKeyThatShouldBeReplaced"))
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger
builder.Services.AddSwaggerGen(options =>
{
    // Main API info
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AgentSystem API",
        Description = "A comprehensive API for the AgentSystem autonomous agent framework",
        Contact = new OpenApiContact
        {
            Name = "TooensureAI",
            Url = new Uri("https://github.com/TooensureAI/AgentSystem")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
    
    // Add a swagger document for v2 (Beta)
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "AgentSystem API (Beta)",
        Description = "Beta version of the AgentSystem API with new features",
        Contact = new OpenApiContact
        {
            Name = "TooensureAI",
            Url = new Uri("https://github.com/TooensureAI/AgentSystem")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    // Add security definition for JWT Bearer
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Add security requirement for JWT Bearer
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    // Use operation filters for additional documentation
    options.OperationFilter<SwaggerDefaultValuesFilter>();
    options.OperationFilter<AuthorizeCheckOperationFilter>();
    
    // Enable annotations for additional documentation
    options.EnableAnnotations();
    
    // Include XML comments if available
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
    
    // Include XML comments from referenced projects
    var coreXmlFilename = "AgentSystem.Core.xml";
    var coreXmlPath = Path.Combine(AppContext.BaseDirectory, coreXmlFilename);
    if (File.Exists(coreXmlPath))
    {
        options.IncludeXmlComments(coreXmlPath);
    }
});

// Add core AgentSystem services
builder.Services.AddAgentSystem(builder.Configuration);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "api-docs/{documentname}/swagger.json";
    });
    
    // Configure custom Swagger UI with Telerik UI integration
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/api-docs/v1/swagger.json", "AgentSystem API v1");
        options.SwaggerEndpoint("/api-docs/v2/swagger.json", "AgentSystem API v2 (Beta)");
        options.RoutePrefix = "swagger";
        
        // Customize Swagger UI
        options.DocumentTitle = "AgentSystem API Documentation";
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        options.EnableDeepLinking();
        options.DisplayRequestDuration();
        options.EnableFilter();
        
        // Load custom CSS and JavaScript
        options.InjectStylesheet("/swagger-ui/custom.css");
        options.InjectStylesheet("/swagger-ui/telerik-theme.css");
        options.InjectJavascript("/swagger-ui/custom.js");
        
        // Configure OAuth
        options.OAuthClientId("swagger-ui");
        options.OAuthAppName("Swagger UI");
        
        // Customize header
        options.HeadContent = @"
            <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
            <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
            <link href=""https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700&display=swap"" rel=""stylesheet"">
            <style>
                body {
                    font-family: 'Roboto', sans-serif;
                }
                .swagger-ui .topbar {
                    background-image: linear-gradient(135deg, #ff6358 0%, #3f51b5 100%);
                }
            </style>
        ";
    });
    
    // Add ReDoc as an alternative documentation UI
    app.UseReDoc(options =>
    {
        options.SpecUrl = "/api-docs/v1/swagger.json";
        options.RoutePrefix = "api-docs";
        options.DocumentTitle = "AgentSystem API Documentation";
        options.ExpandResponses("200,201");
        options.RequiredPropsFirst();
        options.HideHostname();
        options.PathInMiddlePanel();
        options.HideDownloadButton();
        options.HideLoading();
        options.NativeScrollbars();
    });
}

app.UseHttpsRedirection();

// Apply CORS policy
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();