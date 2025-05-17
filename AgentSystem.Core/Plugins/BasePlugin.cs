using AgentSystem.Core.Interfaces;
using AgentSystem.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentSystem.Core.Plugins;

/// <summary>
/// Base implementation of a plugin that provides common functionality
/// </summary>
public abstract class BasePlugin : IPlugin
{
    private readonly ILogger _logger;
    private readonly List<PluginFunction> _functions = new();
    private PluginConfiguration _configuration = new();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="BasePlugin"/> class
    /// </summary>
    protected BasePlugin(ILogger logger)
    {
        _logger = logger;
        RegisterFunctions();
    }
    
    /// <inheritdoc/>
    public abstract string Id { get; }
    
    /// <inheritdoc/>
    public abstract string Name { get; }
    
    /// <inheritdoc/>
    public abstract string Description { get; }
    
    /// <inheritdoc/>
    public abstract string Version { get; }
    
    /// <summary>
    /// Gets the plugin configuration
    /// </summary>
    protected PluginConfiguration Configuration => _configuration;
    
    /// <summary>
    /// Gets the logger
    /// </summary>
    protected ILogger Logger => _logger;
    
    /// <inheritdoc/>
    public virtual async Task InitializeAsync(PluginConfiguration configuration)
    {
        _configuration = configuration;
        _logger.LogInformation("Plugin {Name} ({Id}) v{Version} initialized", Name, Id, Version);
        await Task.CompletedTask;
    }
    
    /// <inheritdoc/>
    public async Task<PluginResult> ExecuteFunctionAsync(string functionName, Dictionary<string, object> parameters)
    {
        var function = _functions.FirstOrDefault(f => f.Name.Equals(functionName, StringComparison.OrdinalIgnoreCase));
        if (function == null)
        {
            _logger.LogWarning("Function {FunctionName} not found in plugin {PluginId}", functionName, Id);
            return PluginResult.CreateError($"Function {functionName} not found in plugin {Id}");
        }
        
        try
        {
            // Validate required parameters
            foreach (var paramDef in function.Parameters.Where(p => p.IsRequired))
            {
                if (!parameters.ContainsKey(paramDef.Name))
                {
                    return PluginResult.CreateError($"Required parameter {paramDef.Name} missing");
                }
            }
            
            _logger.LogInformation("Executing function {FunctionName} in plugin {PluginId}", functionName, Id);
            return await ExecuteFunctionInternalAsync(functionName, parameters);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing function {FunctionName} in plugin {PluginId}", functionName, Id);
            return PluginResult.CreateError($"Error executing function: {ex.Message}");
        }
    }
    
    /// <inheritdoc/>
    public IReadOnlyList<PluginFunction> GetAvailableFunctions()
    {
        return _functions.AsReadOnly();
    }
    
    /// <summary>
    /// Registers a function with the plugin
    /// </summary>
    protected void RegisterFunction(PluginFunction function)
    {
        if (_functions.Any(f => f.Name.Equals(function.Name, StringComparison.OrdinalIgnoreCase)))
        {
            _logger.LogWarning("Function {FunctionName} already registered in plugin {PluginId}, replacing", function.Name, Id);
            _functions.RemoveAll(f => f.Name.Equals(function.Name, StringComparison.OrdinalIgnoreCase));
        }
        
        _functions.Add(function);
        _logger.LogInformation("Function {FunctionName} registered in plugin {PluginId}", function.Name, Id);
    }
    
    /// <summary>
    /// Registers the functions provided by this plugin
    /// </summary>
    protected abstract void RegisterFunctions();
    
    /// <summary>
    /// Executes a function with the given parameters
    /// </summary>
    protected abstract Task<PluginResult> ExecuteFunctionInternalAsync(string functionName, Dictionary<string, object> parameters);
}