/**
 * Custom JavaScript for AgentSystem Swagger UI with Telerik UI integration
 */
(function () {
  // Load Telerik UI theme
  function loadTelerikTheme() {
    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = '/swagger-ui/telerik-theme.css';
    document.head.appendChild(link);
  }

  window.addEventListener('load', function() {
    // Load Telerik UI theme
    loadTelerikTheme();
    
    setTimeout(function() {
      // Add API version selector with Telerik UI styling
      addApiVersionSelector();
      
      // Add theme toggle with Telerik UI styling
      addThemeToggle();
      
      // Add custom info panel with Telerik UI styling
      addCustomInfoPanel();
      
      // Add response example toggle with Telerik UI styling
      addResponseExampleToggle();
      
      // Add copy buttons to code blocks
      addCopyButtons();
      
      // Add keyboard shortcuts
      addKeyboardShortcuts();
      
      // Add experimental features warning
      addExperimentalWarnings();
      
      // Add OAuth2 token manager with Telerik UI styling
      if (window.ui && window.ui.getConfigs().oauth2RedirectUrl) {
        addOAuth2TokenManager();
      }
      
      // Add Telerik UI specific components
      addTelerikComponents();
      
      // Check for saved theme preference
      applyThemePreference();
      
      // Create Telerik notification system
      createNotificationSystem();
      
      // Create Telerik dialog system
      createDialogSystem();
      
      // Show welcome notification
      showNotification('Welcome', 'AgentSystem API Documentation loaded successfully', 'info');
      
      console.log('AgentSystem custom UI with Telerik integration loaded');
    }, 100);
  });
  
  /**
   * Creates the Telerik notification system
   */
  function createNotificationSystem() {
    const notificationContainer = document.createElement('div');
    notificationContainer.id = 'telerik-notifications';
    document.body.appendChild(notificationContainer);
  }
  
  /**
   * Shows a Telerik-styled notification
   * @param {string} title - The notification title
   * @param {string} message - The notification message
   * @param {string} type - The notification type (success, info, warning, error)
   */
  function showNotification(title, message, type = 'info') {
    const container = document.getElementById('telerik-notifications');
    if (!container) return;
    
    const notification = document.createElement('div');
    notification.className = `telerik-notification ${type}`;
    
    // Set icon based on type
    let icon = '';
    switch(type) {
      case 'success': icon = '✓'; break;
      case 'info': icon = 'ℹ'; break;
      case 'warning': icon = '⚠'; break;
      case 'error': icon = '✗'; break;
    }
    
    notification.innerHTML = `
      <div class="telerik-notification-icon">${icon}</div>
      <div class="telerik-notification-content">
        <div class="telerik-notification-title">${title}</div>
        <div class="telerik-notification-message">${message}</div>
      </div>
      <button class="telerik-notification-close">×</button>
    `;
    
    container.appendChild(notification);
    
    // Add event listener to close button
    const closeButton = notification.querySelector('.telerik-notification-close');
    closeButton.addEventListener('click', function() {
      notification.style.transform = 'translateX(120%)';
      setTimeout(function() {
        if (notification.parentNode) {
          notification.parentNode.removeChild(notification);
        }
      }, 300);
    });
    
    // Show notification
    setTimeout(function() {
      notification.classList.add('show');
    }, 10);
    
    // Auto-hide after 5 seconds
    setTimeout(function() {
      if (notification.parentNode) {
        notification.style.transform = 'translateX(120%)';
        setTimeout(function() {
          if (notification.parentNode) {
            notification.parentNode.removeChild(notification);
          }
        }, 300);
      }
    }, 5000);
  }
  
  /**
   * Creates the Telerik dialog system
   */
  function createDialogSystem() {
    const dialogContainer = document.createElement('div');
    dialogContainer.id = 'telerik-dialog-container';
    document.body.appendChild(dialogContainer);
  }
  
  /**
   * Shows a Telerik-styled dialog
   * @param {string} title - The dialog title
   * @param {string} content - The dialog content (can include HTML)
   * @param {Function} onConfirm - The callback function when confirmed
   * @param {Function} onCancel - The callback function when cancelled
   */
  function showDialog(title, content, onConfirm, onCancel) {
    const container = document.getElementById('telerik-dialog-container');
    if (!container) return;
    
    // Create dialog
    const dialog = document.createElement('div');
    dialog.className = 'telerik-dialog';
    
    dialog.innerHTML = `
      <div class="telerik-dialog-content">
        <div class="telerik-dialog-header">
          <div class="telerik-dialog-title">${title}</div>
          <button class="telerik-dialog-close">×</button>
        </div>
        <div class="telerik-dialog-body">
          ${content}
        </div>
        <div class="telerik-dialog-footer">
          <button class="telerik-dialog-button secondary" id="dialog-cancel">Cancel</button>
          <button class="telerik-dialog-button primary" id="dialog-confirm">Confirm</button>
        </div>
      </div>
    `;
    
    container.appendChild(dialog);
    
    // Add event listeners
    const closeButton = dialog.querySelector('.telerik-dialog-close');
    const cancelButton = dialog.querySelector('#dialog-cancel');
    const confirmButton = dialog.querySelector('#dialog-confirm');
    
    function closeDialog() {
      dialog.classList.remove('show');
      setTimeout(function() {
        if (dialog.parentNode) {
          dialog.parentNode.removeChild(dialog);
        }
      }, 300);
    }
    
    closeButton.addEventListener('click', function() {
      if (typeof onCancel === 'function') {
        onCancel();
      }
      closeDialog();
    });
    
    cancelButton.addEventListener('click', function() {
      if (typeof onCancel === 'function') {
        onCancel();
      }
      closeDialog();
    });
    
    confirmButton.addEventListener('click', function() {
      if (typeof onConfirm === 'function') {
        onConfirm();
      }
      closeDialog();
    });
    
    // Show dialog
    setTimeout(function() {
      dialog.classList.add('show');
    }, 10);
  }
  
  /**
   * Adds Telerik UI specific components
   */
  function addTelerikComponents() {
    // Add API Documentation button
    addApiDocButton();
    
    // Add Schema visualization button
    addSchemaVisualizationButton();
    
    // Add quick filter dropdown
    addQuickFilterDropdown();
    
    // Add endpoint comparison tool
    addEndpointComparisonTool();
  }
  
  /**
   * Adds API Documentation button
   */
  function addApiDocButton() {
    const header = document.querySelector('.swagger-ui .topbar .wrapper');
    if (!header) return;
    
    const docButton = document.createElement('a');
    docButton.className = 'telerik-button';
    docButton.href = '/api-docs';
    docButton.target = '_blank';
    docButton.textContent = 'API Documentation';
    docButton.style.marginLeft = '20px';
    docButton.style.padding = '8px 16px';
    docButton.style.backgroundColor = 'white';
    docButton.style.color = '#3f51b5';
    docButton.style.borderRadius = '4px';
    docButton.style.textDecoration = 'none';
    docButton.style.fontWeight = '500';
    docButton.style.border = '1px solid white';
    docButton.style.transition = 'all 0.2s ease';
    
    docButton.addEventListener('mouseover', function() {
      docButton.style.backgroundColor = 'rgba(255, 255, 255, 0.9)';
    });
    
    docButton.addEventListener('mouseout', function() {
      docButton.style.backgroundColor = 'white';
    });
    
    header.appendChild(docButton);
  }
  
  /**
   * Adds schema visualization button
   */
  function addSchemaVisualizationButton() {
    // Wait for Swagger UI to render completely
    setTimeout(function() {
      const modelContainers = document.querySelectorAll('.swagger-ui .model-container');
      
      modelContainers.forEach(function(container) {
        if (container.querySelector('.telerik-schema-viz-btn')) return;
        
        const vizButton = document.createElement('button');
        vizButton.className = 'telerik-schema-viz-btn';
        vizButton.textContent = 'Visualize Schema';
        vizButton.style.marginLeft = '10px';
        vizButton.style.padding = '5px 10px';
        vizButton.style.backgroundColor = '#ff6358';
        vizButton.style.color = 'white';
        vizButton.style.border = 'none';
        vizButton.style.borderRadius = '4px';
        vizButton.style.cursor = 'pointer';
        vizButton.style.transition = 'all 0.2s ease';
        
        vizButton.addEventListener('mouseover', function() {
          vizButton.style.backgroundColor = '#3f51b5';
        });
        
        vizButton.addEventListener('mouseout', function() {
          vizButton.style.backgroundColor = '#ff6358';
        });
        
        vizButton.addEventListener('click', function() {
          const modelName = container.querySelector('.model-title').textContent.trim();
          const properties = Array.from(container.querySelectorAll('.property')).map(prop => {
            const nameEl = prop.querySelector('.property-name');
            const typeEl = prop.querySelector('.property-type');
            const requiredBadge = prop.querySelector('.property-required');
            
            return {
              name: nameEl ? nameEl.textContent.trim() : '',
              type: typeEl ? typeEl.textContent.trim() : '',
              required: !!requiredBadge
            };
          });
          
          showSchemaVisualization(modelName, properties);
        });
        
        const modelTitle = container.querySelector('.model-title');
        if (modelTitle) {
          modelTitle.parentNode.insertBefore(vizButton, modelTitle.nextSibling);
        }
      });
    }, 1500);
  }
  
  /**
   * Shows schema visualization in a Telerik dialog
   */
  function showSchemaVisualization(modelName, properties) {
    let content = `
      <div style="margin-bottom: 15px;">
        <h3 style="margin-top: 0; color: #ff6358;">Schema: ${modelName}</h3>
        <p>Interactive visualization of the schema structure</p>
      </div>
      <div style="border: 1px solid #ddd; border-radius: 4px; max-height: 300px; overflow-y: auto;">
        <table style="width: 100%; border-collapse: collapse;">
          <thead>
            <tr style="background-color: #f5f5f5;">
              <th style="padding: 10px; text-align: left; border-bottom: 1px solid #ddd;">Property</th>
              <th style="padding: 10px; text-align: left; border-bottom: 1px solid #ddd;">Type</th>
              <th style="padding: 10px; text-align: center; border-bottom: 1px solid #ddd;">Required</th>
            </tr>
          </thead>
          <tbody>
    `;
    
    properties.forEach(prop => {
      content += `
        <tr>
          <td style="padding: 8px 10px; border-bottom: 1px solid #eee;">${prop.name}</td>
          <td style="padding: 8px 10px; border-bottom: 1px solid #eee;"><code style="background-color: #f5f5f5; padding: 2px 4px; border-radius: 3px;">${prop.type}</code></td>
          <td style="padding: 8px 10px; border-bottom: 1px solid #eee; text-align: center;">
            ${prop.required ? '<span style="color: #ff6358;">✓</span>' : ''}
          </td>
        </tr>
      `;
    });
    
    content += `
          </tbody>
        </table>
      </div>
      <div style="margin-top: 15px; font-style: italic; color: #666;">
        This visualization is interactive and can be used to understand the schema structure.
      </div>
    `;
    
    showDialog(`${modelName} Schema Visualization`, content, null, null);
  }
  
  /**
   * Adds quick filter dropdown
   */
  function addQuickFilterDropdown() {
    const header = document.querySelector('.swagger-ui .information-container');
    if (!header) return;
    
    const selectorDiv = document.getElementById('api-version-selector');
    if (!selectorDiv) return;
    
    // Create quick filter dropdown
    const filterContainer = document.createElement('div');
    filterContainer.className = 'telerik-quick-filter';
    filterContainer.style.display = 'flex';
    filterContainer.style.alignItems = 'center';
    filterContainer.style.marginLeft = '15px';
    
    const filterLabel = document.createElement('label');
    filterLabel.textContent = 'Quick Filter: ';
    filterLabel.setAttribute('for', 'quick-filter-select');
    filterLabel.style.marginRight = '5px';
    
    const filterSelect = document.createElement('select');
    filterSelect.id = 'quick-filter-select';
    filterSelect.style.padding = '8px 12px';
    filterSelect.style.borderRadius = '4px';
    filterSelect.style.border = '1px solid #e0e0e0';
    filterSelect.style.backgroundColor = 'white';
    filterSelect.style.transition = 'all 0.2s ease';
    
    // Add filter options
    const options = [
      { value: '', label: 'All Endpoints' },
      { value: 'get', label: 'GET (Read)' },
      { value: 'post', label: 'POST (Create)' },
      { value: 'put', label: 'PUT (Update)' },
      { value: 'delete', label: 'DELETE (Remove)' },
      { value: 'auth', label: 'Requires Auth' }
    ];
    
    options.forEach(opt => {
      const option = document.createElement('option');
      option.value = opt.value;
      option.textContent = opt.label;
      filterSelect.appendChild(option);
    });
    
    filterSelect.addEventListener('change', function() {
      const value = this.value;
      
      // Reset all operations
      document.querySelectorAll('.swagger-ui .opblock').forEach(block => {
        block.style.display = '';
      });
      
      // Apply filter
      if (value) {
        if (value === 'auth') {
          // Hide operations that don't require auth
          document.querySelectorAll('.swagger-ui .opblock').forEach(block => {
            const hasAuth = block.querySelector('.authorization__btn');
            if (!hasAuth) {
              block.style.display = 'none';
            }
          });
        } else {
          // Hide operations that don't match the HTTP method
          document.querySelectorAll('.swagger-ui .opblock').forEach(block => {
            if (!block.classList.contains(`opblock-${value}`)) {
              block.style.display = 'none';
            }
          });
        }
      }
      
      showNotification('Filter Applied', `Showing ${value ? options.find(o => o.value === value).label : 'All Endpoints'}`, 'info');
    });
    
    filterContainer.appendChild(filterLabel);
    filterContainer.appendChild(filterSelect);
    
    // Add to the version selector
    selectorDiv.appendChild(filterContainer);
  }
  
  /**
   * Adds endpoint comparison tool
   */
  function addEndpointComparisonTool() {
    const header = document.querySelector('.swagger-ui .information-container');
    if (!header) return;
    
    const customInfoPanel = document.querySelector('.custom-info-panel');
    if (!customInfoPanel) return;
    
    // Create comparison button
    const compareButton = document.createElement('button');
    compareButton.className = 'telerik-compare-btn';
    compareButton.textContent = 'Compare Endpoints';
    compareButton.style.display = 'block';
    compareButton.style.margin = '15px 0 0 0';
    compareButton.style.padding = '8px 16px';
    compareButton.style.backgroundColor = '#ff6358';
    compareButton.style.color = 'white';
    compareButton.style.border = 'none';
    compareButton.style.borderRadius = '4px';
    compareButton.style.cursor = 'pointer';
    compareButton.style.transition = 'all 0.2s ease';
    
    compareButton.addEventListener('mouseover', function() {
      compareButton.style.backgroundColor = '#3f51b5';
    });
    
    compareButton.addEventListener('mouseout', function() {
      compareButton.style.backgroundColor = '#ff6358';
    });
    
    compareButton.addEventListener('click', function() {
      showEndpointComparisonDialog();
    });
    
    customInfoPanel.appendChild(compareButton);
  }
  
  /**
   * Shows endpoint comparison dialog
   */
  function showEndpointComparisonDialog() {
    // Get all operations
    const operations = Array.from(document.querySelectorAll('.swagger-ui .opblock')).map(block => {
      const method = block.className.match(/opblock-(\w+)/)[1].toUpperCase();
      const pathElement = block.querySelector('.opblock-summary-path');
      const path = pathElement ? pathElement.dataset.path : '';
      const summary = block.querySelector('.opblock-summary-description')?.textContent.trim() || '';
      
      return { method, path, summary };
    });
    
    let content = `
      <div style="margin-bottom: 15px;">
        <p>Select two endpoints to compare:</p>
      </div>
      <div style="display: flex; gap: 15px; margin-bottom: 15px;">
        <div style="flex: 1;">
          <label for="endpoint1">Endpoint 1:</label>
          <select id="endpoint1" style="width: 100%; padding: 8px; margin-top: 5px; border-radius: 4px; border: 1px solid #ddd;">
            ${operations.map((op, index) => `<option value="${index}">${op.method} ${op.path}</option>`).join('')}
          </select>
        </div>
        <div style="flex: 1;">
          <label for="endpoint2">Endpoint 2:</label>
          <select id="endpoint2" style="width: 100%; padding: 8px; margin-top: 5px; border-radius: 4px; border: 1px solid #ddd;">
            ${operations.map((op, index) => `<option value="${index}">${op.method} ${op.path}</option>`).join('')}
          </select>
        </div>
      </div>
      <div id="comparison-result" style="margin-top: 15px;">
        <p>Select endpoints to see comparison</p>
      </div>
    `;
    
    const dialog = showDialog('Endpoint Comparison Tool', content, null, null);
    
    // Add event listeners to selects after dialog is shown
    setTimeout(function() {
      const endpoint1 = document.getElementById('endpoint1');
      const endpoint2 = document.getElementById('endpoint2');
      const resultDiv = document.getElementById('comparison-result');
      
      function updateComparison() {
        const op1 = operations[endpoint1.value];
        const op2 = operations[endpoint2.value];
        
        if (!op1 || !op2) return;
        
        resultDiv.innerHTML = `
          <table style="width: 100%; border-collapse: collapse; border: 1px solid #ddd; border-radius: 4px; overflow: hidden;">
            <thead>
              <tr style="background-color: #f5f5f5;">
                <th style="padding: 10px; text-align: left; border-bottom: 1px solid #ddd;">Feature</th>
                <th style="padding: 10px; text-align: left; border-bottom: 1px solid #ddd;">Endpoint 1</th>
                <th style="padding: 10px; text-align: left; border-bottom: 1px solid #ddd;">Endpoint 2</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td style="padding: 8px 10px; border-bottom: 1px solid #eee; font-weight: 500;">HTTP Method</td>
                <td style="padding: 8px 10px; border-bottom: 1px solid #eee;">
                  <span style="padding: 3px 6px; border-radius: 3px; background-color: ${getMethodColor(op1.method)}; color: white;">${op1.method}</span>
                </td>
                <td style="padding: 8px 10px; border-bottom: 1px solid #eee;">
                  <span style="padding: 3px 6px; border-radius: 3px; background-color: ${getMethodColor(op2.method)}; color: white;">${op2.method}</span>
                </td>
              </tr>
              <tr>
                <td style="padding: 8px 10px; border-bottom: 1px solid #eee; font-weight: 500;">Path</td>
                <td style="padding: 8px 10px; border-bottom: 1px solid #eee;"><code style="background-color: #f5f5f5; padding: 2px 4px; border-radius: 3px;">${op1.path}</code></td>
                <td style="padding: 8px 10px; border-bottom: 1px solid #eee;"><code style="background-color: #f5f5f5; padding: 2px 4px; border-radius: 3px;">${op2.path}</code></td>
              </tr>
              <tr>
                <td style="padding: 8px 10px; border-bottom: 1px solid #eee; font-weight: 500;">Description</td>
                <td style="padding: 8px 10px; border-bottom: 1px solid #eee;">${op1.summary}</td>
                <td style="padding: 8px 10px; border-bottom: 1px solid #eee;">${op2.summary}</td>
              </tr>
              <tr>
                <td style="padding: 8px 10px; font-weight: 500;">Similarity</td>
                <td colspan="2" style="padding: 8px 10px; text-align: center;">
                  ${calculateSimilarity(op1, op2)}
                </td>
              </tr>
            </tbody>
          </table>
        `;
      }
      
      function getMethodColor(method) {
        switch(method) {
          case 'GET': return '#0288d1';
          case 'POST': return '#2e7d32';
          case 'PUT': return '#ffc107';
          case 'DELETE': return '#d50000';
          case 'PATCH': return '#9966cc';
          default: return '#9e9e9e';
        }
      }
      
      function calculateSimilarity(op1, op2) {
        // Simple similarity calculation based on path and method
        let similarity = 0;
        
        if (op1.method === op2.method) {
          similarity += 50;
        }
        
        // Compare path components
        const path1Parts = op1.path.split('/').filter(Boolean);
        const path2Parts = op2.path.split('/').filter(Boolean);
        let pathSimilarity = 0;
        
        if (path1Parts.length === path2Parts.length) {
          pathSimilarity += 25;
          
          // Compare each path component
          let matchingParts = 0;
          for (let i = 0; i < path1Parts.length; i++) {
            // If both are parameters (start with {)
            const is1Param = path1Parts[i].startsWith('{');
            const is2Param = path2Parts[i].startsWith('{');
            
            if (is1Param && is2Param) {
              matchingParts += 0.75; // Parameters match but not exactly
            } else if (path1Parts[i] === path2Parts[i]) {
              matchingParts += 1; // Exact match
            }
          }
          
          pathSimilarity += (matchingParts / path1Parts.length) * 25;
        }
        
        similarity += pathSimilarity;
        
        // Format the result
        let result = '';
        if (similarity >= 90) {
          result = `<span style="color: #2e7d32; font-weight: 500;">${similarity.toFixed(0)}% - Very Similar</span>`;
        } else if (similarity >= 60) {
          result = `<span style="color: #ff6358; font-weight: 500;">${similarity.toFixed(0)}% - Somewhat Similar</span>`;
        } else {
          result = `<span style="color: #9e9e9e; font-weight: 500;">${similarity.toFixed(0)}% - Not Similar</span>`;
        }
        
        return result;
      }
      
      endpoint1.addEventListener('change', updateComparison);
      endpoint2.addEventListener('change', updateComparison);
      
      // Initial comparison
      if (endpoint1 && endpoint2) {
        updateComparison();
      }
    }, 100);
  }
  
  /**
   * Adds API version selector above the Swagger UI with Telerik styling
   */
  function addApiVersionSelector() {
    var header = document.querySelector('.swagger-ui .information-container');
    if (!header) return;
    
    var selectorDiv = document.createElement('div');
    selectorDiv.id = 'api-version-selector';
    selectorDiv.style.display = 'flex';
    selectorDiv.style.flexWrap = 'wrap';
    selectorDiv.style.gap = '10px';
    selectorDiv.style.alignItems = 'center';
    selectorDiv.style.margin = '15px 0';
    selectorDiv.style.padding = '15px';
    selectorDiv.style.backgroundColor = 'white';
    selectorDiv.style.borderRadius = '4px';
    selectorDiv.style.boxShadow = '0 2px 10px rgba(0, 0, 0, 0.1)';
    
    // Create version dropdown
    var versionContainer = document.createElement('div');
    versionContainer.className = 'version-container';
    versionContainer.style.display = 'flex';
    versionContainer.style.alignItems = 'center';
    
    var versionLabel = document.createElement('label');
    versionLabel.textContent = 'API Version: ';
    versionLabel.setAttribute('for', 'version-select');
    versionLabel.style.marginRight = '10px';
    versionLabel.style.fontWeight = '500';
    
    var versionSelect = document.createElement('select');
    versionSelect.id = 'version-select';
    versionSelect.style.padding = '8px 12px';
    versionSelect.style.borderRadius = '4px';
    versionSelect.style.border = '1px solid #e0e0e0';
    versionSelect.style.backgroundColor = 'white';
    versionSelect.style.cursor = 'pointer';
    versionSelect.style.transition = 'all 0.2s ease';
    
    // Add version options
    var v1Option = document.createElement('option');
    v1Option.value = '/api-docs/v1/swagger.json';
    v1Option.textContent = 'v1 - Stable';
    v1Option.selected = window.ui.getConfigs().url.includes('v1');
    
    var v2Option = document.createElement('option');
    v2Option.value = '/api-docs/v2/swagger.json';
    v2Option.textContent = 'v2 - Beta';
    v2Option.selected = window.ui.getConfigs().url.includes('v2');
    
    versionSelect.appendChild(v1Option);
    versionSelect.appendChild(v2Option);
    
    versionSelect.addEventListener('change', function() {
      window.ui.specActions.updateUrl(this.value);
      window.ui.specActions.download();
      showNotification('API Version Changed', `Switched to ${this.options[this.selectedIndex].textContent}`, 'info');
    });
    
    versionContainer.appendChild(versionLabel);
    versionContainer.appendChild(versionSelect);
    
    // Create theme toggle with Telerik styling
    var themeToggle = document.createElement('button');
    themeToggle.id = 'theme-toggle';
    themeToggle.textContent = 'Toggle Dark Mode';
    
    selectorDiv.appendChild(versionContainer);
    selectorDiv.appendChild(themeToggle);
    
    header.insertAdjacentElement('afterend', selectorDiv);
  }
  
  /**
   * Adds theme toggle functionality with Telerik styling
   */
  function addThemeToggle() {
    var themeToggle = document.getElementById('theme-toggle');
    if (!themeToggle) return;
    
    themeToggle.addEventListener('click', toggleTheme);
  }
  
  /**
   * Toggles between light and dark theme with Telerik styling
   */
  function toggleTheme() {
    const body = document.body;
    const isDarkMode = body.classList.toggle('dark-theme');
    
    // Save preference
    localStorage.setItem('swagger_theme_preference', isDarkMode ? 'dark' : 'light');
    
    // Update button text
    const themeToggle = document.getElementById('theme-toggle');
    if (themeToggle) {
      themeToggle.textContent = isDarkMode ? 'Toggle Light Mode' : 'Toggle Dark Mode';
    }
    
    // Show notification
    showNotification('Theme Changed', isDarkMode ? 'Dark theme activated' : 'Light theme activated', 'info');
  }
  
  /**
   * Applies saved theme preference
   */
  function applyThemePreference() {
    const savedTheme = localStorage.getItem('swagger_theme_preference');
    if (savedTheme === 'dark') {
      document.body.classList.add('dark-theme');
      
      const themeToggle = document.getElementById('theme-toggle');
      if (themeToggle) {
        themeToggle.textContent = 'Toggle Light Mode';
      }
    }
  }
  
  /**
   * Adds a custom information panel below the API info with Telerik styling
   */
  function addCustomInfoPanel() {
    var header = document.querySelector('.swagger-ui .information-container');
    if (!header) return;
    
    var infoPanel = document.createElement('div');
    infoPanel.className = 'custom-info-panel';
    infoPanel.style.margin = '0 0 20px 0';
    infoPanel.style.padding = '20px';
    infoPanel.style.backgroundColor = 'white';
    infoPanel.style.borderRadius = '4px';
    infoPanel.style.boxShadow = '0 2px 10px rgba(0, 0, 0, 0.1)';
    infoPanel.style.border = '1px solid #f0f0f0';
    
    infoPanel.innerHTML = `
      <h3 style="margin-top: 0; color: #ff6358; font-weight: 500;">Welcome to AgentSystem API</h3>
      <p>This interactive documentation provides a comprehensive guide to the AgentSystem REST API.</p>
      <div style="display: flex; flex-wrap: wrap; gap: 15px; margin: 15px 0;">
        <div style="flex: 1; min-width: 200px; padding: 15px; background-color: #f9f9f9; border-radius: 4px; border-left: 3px solid #ff6358;">
          <h4 style="margin-top: 0; color: #ff6358;">Agent Management</h4>
          <p>Create, configure, and manage autonomous agents with various capabilities.</p>
        </div>
        <div style="flex: 1; min-width: 200px; padding: 15px; background-color: #f9f9f9; border-radius: 4px; border-left: 3px solid #03a9f4;">
          <h4 style="margin-top: 0; color: #03a9f4;">Plugin System</h4>
          <p>Access plugin functionality to extend agent capabilities with custom features.</p>
        </div>
        <div style="flex: 1; min-width: 200px; padding: 15px; background-color: #f9f9f9; border-radius: 4px; border-left: 3px solid #3f51b5;">
          <h4 style="margin-top: 0; color: #3f51b5;">Assessment</h4>
          <p>Evaluate agent performance across multiple dimensions with detailed metrics.</p>
        </div>
      </div>
      <div style="background-color: #f5f5f5; padding: 10px 15px; border-radius: 4px; margin-top: 15px; display: flex; align-items: center;">
        <span style="margin-right: 10px; font-size: 18px; color: #ff6358;">💡</span>
        <span><strong>Tip:</strong> Use the "Try it out" feature to test API calls directly from the browser.</span>
      </div>
    `;
    
    var selectorDiv = document.getElementById('api-version-selector');
    if (selectorDiv) {
      selectorDiv.insertAdjacentElement('afterend', infoPanel);
    } else {
      header.insertAdjacentElement('afterend', infoPanel);
    }
  }
  
  /**
   * Adds a toggle button for response examples with Telerik styling
   */
  function addResponseExampleToggle() {
    // Wait for Swagger UI to render completely
    setTimeout(function() {
      const responses = document.querySelectorAll('.swagger-ui .responses-inner');
      
      responses.forEach(function(response) {
        const examples = response.querySelectorAll('.response-col_description__inner .example');
        
        if (examples.length > 0) {
          const toggleButton = document.createElement('button');
          toggleButton.className = 'btn response-example-toggle';
          toggleButton.textContent = 'Toggle Examples';
          toggleButton.style.marginBottom = '10px';
          toggleButton.style.backgroundColor = '#ff6358';
          toggleButton.style.color = 'white';
          toggleButton.style.border = 'none';
          toggleButton.style.borderRadius = '4px';
          toggleButton.style.padding = '5px 10px';
          toggleButton.style.cursor = 'pointer';
          toggleButton.style.transition = 'all 0.2s ease';
          
          toggleButton.addEventListener('mouseover', function() {
            toggleButton.style.backgroundColor = '#3f51b5';
          });
          
          toggleButton.addEventListener('mouseout', function() {
            toggleButton.style.backgroundColor = '#ff6358';
          });
          
          toggleButton.addEventListener('click', function() {
            examples.forEach(function(example) {
              example.style.display = example.style.display === 'none' ? 'block' : 'none';
            });
          });
          
          const firstTitle = response.querySelector('.response-col_description__inner .responses-header');
          if (firstTitle) {
            firstTitle.insertAdjacentElement('afterend', toggleButton);
          }
        }
      });
    }, 1000);
  }
  
  /**
   * Adds copy buttons to code blocks with Telerik styling
   */
  function addCopyButtons() {
    // Wait for Swagger UI to render completely
    setTimeout(function() {
      const codeBlocks = document.querySelectorAll('.swagger-ui .highlight-code');
      
      codeBlocks.forEach(function(codeBlock) {
        if (codeBlock.querySelector('.copy-button')) return;
        
        const copyButton = document.createElement('button');
        copyButton.className = 'copy-button';
        copyButton.textContent = 'Copy';
        copyButton.style.position = 'absolute';
        copyButton.style.top = '5px';
        copyButton.style.right = '5px';
        copyButton.style.padding = '3px 8px';
        copyButton.style.fontSize = '12px';
        copyButton.style.backgroundColor = 'rgba(255, 255, 255, 0.8)';
        copyButton.style.color = '#3f51b5';
        copyButton.style.border = '1px solid #ddd';
        copyButton.style.borderRadius = '3px';
        copyButton.style.cursor = 'pointer';
        copyButton.style.transition = 'all 0.2s ease';
        
        copyButton.addEventListener('mouseover', function() {
          copyButton.style.backgroundColor = '#ff6358';
          copyButton.style.color = 'white';
          copyButton.style.borderColor = '#ff6358';
        });
        
        copyButton.addEventListener('mouseout', function() {
          copyButton.style.backgroundColor = 'rgba(255, 255, 255, 0.8)';
          copyButton.style.color = '#3f51b5';
          copyButton.style.borderColor = '#ddd';
        });
        
        copyButton.addEventListener('click', function(e) {
          e.preventDefault();
          e.stopPropagation();
          
          const code = codeBlock.querySelector('code');
          if (!code) return;
          
          const text = code.textContent;
          
          navigator.clipboard.writeText(text).then(function() {
            showNotification('Copied!', 'Code copied to clipboard', 'success');
            copyButton.textContent = 'Copied!';
            setTimeout(function() {
              copyButton.textContent = 'Copy';
            }, 2000);
          }, function() {
            showNotification('Error', 'Failed to copy to clipboard', 'error');
            copyButton.textContent = 'Failed';
            setTimeout(function() {
              copyButton.textContent = 'Copy';
            }, 2000);
          });
        });
        
        codeBlock.style.position = 'relative';
        codeBlock.appendChild(copyButton);
      });
    }, 1000);
  }
  
  /**
   * Adds keyboard shortcuts
   */
  function addKeyboardShortcuts() {
    document.addEventListener('keydown', function(e) {
      // Alt+T to toggle theme
      if (e.altKey && e.key === 't') {
        toggleTheme();
      }
      
      // Alt+F to focus search
      if (e.altKey && e.key === 'f') {
        const searchBox = document.querySelector('.swagger-ui .operation-filter-input');
        if (searchBox) {
          searchBox.focus();
          e.preventDefault();
          showNotification('Keyboard Shortcut', 'Search box focused', 'info');
        }
      }
      
      // Alt+C to collapse all operations
      if (e.altKey && e.key === 'c') {
        const collapseButtons = document.querySelectorAll('.swagger-ui .opblock-summary');
        collapseButtons.forEach(function(button) {
          const isExpanded = !button.parentElement.classList.contains('is-open');
          if (isExpanded) {
            button.click();
          }
        });
        showNotification('Keyboard Shortcut', 'All operations collapsed', 'info');
      }
      
      // Alt+E to expand all operations
      if (e.altKey && e.key === 'e') {
        const expandButtons = document.querySelectorAll('.swagger-ui .opblock-summary');
        expandButtons.forEach(function(button) {
          const isCollapsed = button.parentElement.classList.contains('is-open');
          if (!isCollapsed) {
            button.click();
          }
        });
        showNotification('Keyboard Shortcut', 'All operations expanded', 'info');
      }
      
      // Alt+H to show keyboard shortcuts help
      if (e.altKey && e.key === 'h') {
        showKeyboardShortcutsHelp();
      }
    });
  }
  
  /**
   * Shows keyboard shortcuts help in a Telerik dialog
   */
  function showKeyboardShortcutsHelp() {
    const content = `
      <table style="width: 100%; border-collapse: collapse; border: 1px solid #ddd; border-radius: 4px; overflow: hidden;">
        <thead>
          <tr style="background-color: #f5f5f5;">
            <th style="padding: 10px; text-align: left; border-bottom: 1px solid #ddd;">Shortcut</th>
            <th style="padding: 10px; text-align: left; border-bottom: 1px solid #ddd;">Action</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td style="padding: 8px 10px; border-bottom: 1px solid #eee;"><kbd>Alt</kbd> + <kbd>T</kbd></td>
            <td style="padding: 8px 10px; border-bottom: 1px solid #eee;">Toggle between light and dark theme</td>
          </tr>
          <tr>
            <td style="padding: 8px 10px; border-bottom: 1px solid #eee;"><kbd>Alt</kbd> + <kbd>F</kbd></td>
            <td style="padding: 8px 10px; border-bottom: 1px solid #eee;">Focus search box</td>
          </tr>
          <tr>
            <td style="padding: 8px 10px; border-bottom: 1px solid #eee;"><kbd>Alt</kbd> + <kbd>C</kbd></td>
            <td style="padding: 8px 10px; border-bottom: 1px solid #eee;">Collapse all operations</td>
          </tr>
          <tr>
            <td style="padding: 8px 10px; border-bottom: 1px solid #eee;"><kbd>Alt</kbd> + <kbd>E</kbd></td>
            <td style="padding: 8px 10px; border-bottom: 1px solid #eee;">Expand all operations</td>
          </tr>
          <tr>
            <td style="padding: 8px 10px;"><kbd>Alt</kbd> + <kbd>H</kbd></td>
            <td style="padding: 8px 10px;">Show this help dialog</td>
          </tr>
        </tbody>
      </table>
    `;
    
    showDialog('Keyboard Shortcuts', content, null, null);
  }
  
  /**
   * Adds warnings for experimental features with Telerik styling
   */
  function addExperimentalWarnings() {
    setTimeout(function() {
      if (!window.ui) return;
      
      const paths = window.ui.getSystem().specSelectors.paths();
      if (!paths) return;
      
      paths.forEach(function(pathObj, path) {
        pathObj.forEach(function(operation, method) {
          if (operation.get('x-experimental') === true) {
            const operationId = operation.get('operationId');
            const opblockId = `operations-${operation.get('tags').first()}-${operationId}`;
            const opblock = document.getElementById(opblockId);
            
            if (opblock) {
              const warning = document.createElement('div');
              warning.className = 'experimental-warning';
              warning.innerHTML = `
                <div style="display: flex; align-items: center; background-color: rgba(255, 193, 7, 0.2); color: #856404; padding: 10px; border-radius: 4px; margin: 10px 0;">
                  <span style="font-size: 18px; margin-right: 10px;">⚠️</span>
                  <span>Experimental: This API may change or be removed in future versions.</span>
                </div>
              `;
              
              const opblockBody = opblock.querySelector('.opblock-body');
              if (opblockBody) {
                opblockBody.insertAdjacentElement('afterbegin', warning);
              }
            }
          }
        });
      });
    }, 1000);
  }
  
  /**
   * Adds a simple OAuth2 token manager with Telerik styling
   */
  function addOAuth2TokenManager() {
    const authWrapper = document.querySelector('.swagger-ui .auth-wrapper');
    if (!authWrapper) return;
    
    const tokenManager = document.createElement('div');
    tokenManager.className = 'token-manager';
    tokenManager.style.margin = '15px 0';
    tokenManager.style.padding = '20px';
    tokenManager.style.backgroundColor = 'white';
    tokenManager.style.borderRadius = '4px';
    tokenManager.style.boxShadow = '0 2px 10px rgba(0, 0, 0, 0.1)';
    tokenManager.style.border = '1px solid #f0f0f0';
    
    tokenManager.innerHTML = `
      <h3 style="margin-top: 0; color: #ff6358; font-weight: 500;">JWT Token Manager</h3>
      <div style="display: flex; margin-bottom: 10px;">
        <input type="text" id="manual-token" placeholder="Paste your JWT token here" style="flex: 1; margin-right: 10px; padding: 10px; border-radius: 4px; border: 1px solid #ddd;">
        <button id="set-token-btn" style="white-space: nowrap; padding: 0 20px; background-color: #ff6358; color: white; border: none; border-radius: 4px; cursor: pointer; transition: all 0.2s ease;">Set Token</button>
      </div>
      <div style="display: flex; justify-content: space-between; align-items: center;">
        <button id="clear-token-btn" style="padding: 8px 16px; background-color: #f5f5f5; color: #333; border: 1px solid #ddd; border-radius: 4px; cursor: pointer; transition: all 0.2s ease;">Clear Token</button>
        <span id="token-status" style="font-size: 14px;"></span>
      </div>
    `;
    
    authWrapper.insertAdjacentElement('afterend', tokenManager);
    
    const setTokenBtn = document.getElementById('set-token-btn');
    const clearTokenBtn = document.getElementById('clear-token-btn');
    
    // Add hover effects
    setTokenBtn.addEventListener('mouseover', function() {
      setTokenBtn.style.backgroundColor = '#3f51b5';
    });
    
    setTokenBtn.addEventListener('mouseout', function() {
      setTokenBtn.style.backgroundColor = '#ff6358';
    });
    
    clearTokenBtn.addEventListener('mouseover', function() {
      clearTokenBtn.style.backgroundColor = '#e0e0e0';
    });
    
    clearTokenBtn.addEventListener('mouseout', function() {
      clearTokenBtn.style.backgroundColor = '#f5f5f5';
    });
    
    setTokenBtn.addEventListener('click', function() {
      const token = document.getElementById('manual-token').value.trim();
      if (!token) return;
      
      // Set auth in Swagger UI
      window.ui.preauthorizeApiKey('Bearer', token);
      
      // Update status
      document.getElementById('token-status').textContent = 'Token set successfully!';
      document.getElementById('token-status').style.color = '#2e7d32';
      
      // Show notification
      showNotification('Authentication', 'JWT token set successfully', 'success');
      
      setTimeout(function() {
        document.getElementById('token-status').textContent = '';
      }, 3000);
    });
    
    clearTokenBtn.addEventListener('click', function() {
      // Clear auth in Swagger UI
      window.ui.getSystem().authActions.logout(['Bearer']);
      
      // Clear input
      document.getElementById('manual-token').value = '';
      
      // Update status
      document.getElementById('token-status').textContent = 'Token cleared!';
      document.getElementById('token-status').style.color = '#ff6358';
      
      // Show notification
      showNotification('Authentication', 'JWT token cleared', 'info');
      
      setTimeout(function() {
        document.getElementById('token-status').textContent = '';
      }, 3000);
    });
  }
})();