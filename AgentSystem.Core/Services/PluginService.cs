using AgentSystem.Core.Interfaces;
using AgentSystem.Core.Models;
using Microsoft.Extensions.Logging;

namespace AgentSystem.Core.Services;

/// <summary>
/// Service for managing and executing plugins
/// </summary>
public class PluginService
{
    private readonly ILogger<PluginService> _logger;
    private readonly Dictionary<string, IPlugin> _plugins = new();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="PluginService"/> class
    /// </summary>
    public PluginService(ILogger<PluginService> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// Registers a plugin with the service
    /// </summary>
    public void RegisterPlugin(IPlugin plugin)
    {
        if (_plugins.ContainsKey(plugin.Id))
        {
            _logger.LogWarning("Plugin with ID {PluginId} is already registered, replacing", plugin.Id);
        }
        
        _plugins[plugin.Id] = plugin;
        _logger.LogInformation("Plugin {PluginName} ({PluginId}) v{Version} registered", plugin.Name, plugin.Id, plugin.Version);
    }
    
    /// <summary>
    /// Gets a plugin by its ID
    /// </summary>
    public IPlugin? GetPlugin(string pluginId)
    {
        if (_plugins.TryGetValue(pluginId, out var plugin))
        {
            return plugin;
        }
        
        _logger.LogWarning("Plugin with ID {PluginId} not found", pluginId);
        return null;
    }
    
    /// <summary>
    /// Gets all registered plugins
    /// </summary>
    public IReadOnlyList<IPlugin> GetAllPlugins()
    {
        return _plugins.Values.ToList();
    }
    
    /// <summary>
    /// Executes a plugin function
    /// </summary>
    public async Task<PluginResult> ExecuteFunctionAsync(string pluginId, string functionName, Dictionary<string, object> parameters)
    {
        var plugin = GetPlugin(pluginId);
        if (plugin == null)
        {
            return PluginResult.CreateError($"Plugin with ID {pluginId} not found");
        }
        
        return await plugin.ExecuteFunctionAsync(functionName, parameters);
    }
    
    /// <summary>
    /// Gets all available functions across all plugins
    /// </summary>
    public Dictionary<string, List<PluginFunction>> GetAllFunctions()
    {
        var result = new Dictionary<string, List<PluginFunction>>();
        
        foreach (var plugin in _plugins.Values)
        {
            result[plugin.Id] = plugin.GetAvailableFunctions().ToList();
        }
        
        return result;
    }
}