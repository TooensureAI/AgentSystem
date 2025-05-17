/**
 * Custom JavaScript for AgentSystem Swagger UI
 */
(function () {
  window.addEventListener('load', function() {
    setTimeout(function() {
      // Add API version selector
      addApiVersionSelector();
      
      // Add theme toggle
      addThemeToggle();
      
      // Add custom info panel
      addCustomInfoPanel();
      
      // Add response example toggle
      addResponseExampleToggle();
      
      // Add copy buttons to code blocks
      addCopyButtons();
      
      // Add keyboard shortcuts
      addKeyboardShortcuts();
      
      // Add experimental features warning
      addExperimentalWarnings();
      
      // Add OAuth2 token manager
      if (window.ui && window.ui.getConfigs().oauth2RedirectUrl) {
        addOAuth2TokenManager();
      }
      
      // Check for saved theme preference
      applyThemePreference();
      
      console.log('AgentSystem custom UI extensions loaded');
    }, 100);
  });
  
  /**
   * Adds API version selector above the Swagger UI
   */
  function addApiVersionSelector() {
    var header = document.querySelector('.swagger-ui .information-container');
    if (!header) return;
    
    var selectorDiv = document.createElement('div');
    selectorDiv.id = 'api-version-selector';
    
    // Create version dropdown
    var versionLabel = document.createElement('label');
    versionLabel.textContent = 'API Version: ';
    versionLabel.setAttribute('for', 'version-select');
    
    var versionSelect = document.createElement('select');
    versionSelect.id = 'version-select';
    
    // Add version options
    var v1Option = document.createElement('option');
    v1Option.value = '/swagger/v1/swagger.json';
    v1Option.textContent = 'v1 - Stable';
    v1Option.selected = window.ui.getConfigs().url.includes('v1');
    
    var v2Option = document.createElement('option');
    v2Option.value = '/swagger/v2/swagger.json';
    v2Option.textContent = 'v2 - Beta';
    v2Option.selected = window.ui.getConfigs().url.includes('v2');
    
    versionSelect.appendChild(v1Option);
    versionSelect.appendChild(v2Option);
    
    versionSelect.addEventListener('change', function() {
      window.ui.specActions.updateUrl(this.value);
      window.ui.specActions.download();
    });
    
    var versionContainer = document.createElement('div');
    versionContainer.className = 'version-container';
    versionContainer.appendChild(versionLabel);
    versionContainer.appendChild(versionSelect);
    
    // Create theme toggle
    var themeToggle = document.createElement('button');
    themeToggle.id = 'theme-toggle';
    themeToggle.textContent = 'Toggle Dark Mode';
    themeToggle.addEventListener('click', toggleTheme);
    
    selectorDiv.appendChild(versionContainer);
    selectorDiv.appendChild(themeToggle);
    
    header.insertAdjacentElement('afterend', selectorDiv);
  }
  
  /**
   * Adds theme toggle functionality
   */
  function addThemeToggle() {
    var themeToggle = document.getElementById('theme-toggle');
    if (!themeToggle) return;
    
    // Already added in the version selector
  }
  
  /**
   * Toggles between light and dark theme
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
   * Adds a custom information panel below the API info
   */
  function addCustomInfoPanel() {
    var header = document.querySelector('.swagger-ui .information-container');
    if (!header) return;
    
    var infoPanel = document.createElement('div');
    infoPanel.className = 'custom-info-panel';
    infoPanel.innerHTML = `
      <h3>Welcome to AgentSystem API</h3>
      <p>This interactive documentation provides a comprehensive guide to the AgentSystem REST API.</p>
      <p>Key features of this API:</p>
      <ul>
        <li>Manage autonomous agents and their configurations</li>
        <li>Access plugin functionality for agent capabilities</li>
        <li>Evaluate agent performance across multiple dimensions</li>
        <li>JWT authentication for secure access</li>
      </ul>
      <p><strong>Tip:</strong> Use the "Try it out" feature to test API calls directly from the browser.</p>
    `;
    
    var selectorDiv = document.getElementById('api-version-selector');
    if (selectorDiv) {
      selectorDiv.insertAdjacentElement('afterend', infoPanel);
    } else {
      header.insertAdjacentElement('afterend', infoPanel);
    }
  }
  
  /**
   * Adds a toggle button for response examples
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
          toggleButton.style.backgroundColor = '#f0f0f0';
          toggleButton.style.border = '1px solid #ddd';
          toggleButton.style.borderRadius = '4px';
          toggleButton.style.padding = '5px 10px';
          
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
   * Adds copy buttons to code blocks
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
        copyButton.style.backgroundColor = 'rgba(255, 255, 255, 0.7)';
        copyButton.style.border = '1px solid #ddd';
        copyButton.style.borderRadius = '3px';
        copyButton.style.cursor = 'pointer';
        
        copyButton.addEventListener('click', function(e) {
          e.preventDefault();
          e.stopPropagation();
          
          const code = codeBlock.querySelector('code');
          if (!code) return;
          
          const text = code.textContent;
          
          navigator.clipboard.writeText(text).then(function() {
            copyButton.textContent = 'Copied!';
            setTimeout(function() {
              copyButton.textContent = 'Copy';
            }, 2000);
          }, function() {
            copyButton.textContent = 'Failed to copy';
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
      }
    });
  }
  
  /**
   * Adds warnings for experimental features
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
              warning.textContent = '⚠️ Experimental: This API may change or be removed in future versions.';
              warning.style.backgroundColor = 'rgba(255, 193, 7, 0.2)';
              warning.style.color = '#856404';
              warning.style.padding = '10px';
              warning.style.borderRadius = '4px';
              warning.style.marginBottom = '10px';
              warning.style.marginTop = '10px';
              warning.style.fontSize = '14px';
              
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
   * Adds a simple OAuth2 token manager
   */
  function addOAuth2TokenManager() {
    const authWrapper = document.querySelector('.swagger-ui .auth-wrapper');
    if (!authWrapper) return;
    
    const tokenManager = document.createElement('div');
    tokenManager.className = 'token-manager';
    tokenManager.style.margin = '10px 0';
    tokenManager.style.padding = '10px';
    tokenManager.style.backgroundColor = 'rgba(106, 17, 203, 0.05)';
    tokenManager.style.borderRadius = '4px';
    
    tokenManager.innerHTML = `
      <h3 style="margin-top: 0;">JWT Token Manager</h3>
      <div style="display: flex; margin-bottom: 10px;">
        <input type="text" id="manual-token" placeholder="Paste your JWT token here" style="flex: 1; margin-right: 10px; padding: 8px; border-radius: 4px; border: 1px solid #ddd;">
        <button id="set-token-btn" style="white-space: nowrap; padding: 8px 16px; background-color: #6a11cb; color: white; border: none; border-radius: 4px; cursor: pointer;">Set Token</button>
      </div>
      <div style="display: flex; justify-content: space-between;">
        <button id="clear-token-btn" style="padding: 5px 10px; background-color: #dc3545; color: white; border: none; border-radius: 4px; cursor: pointer;">Clear Token</button>
        <span id="token-status" style="font-size: 14px;"></span>
      </div>
    `;
    
    authWrapper.insertAdjacentElement('afterend', tokenManager);
    
    document.getElementById('set-token-btn').addEventListener('click', function() {
      const token = document.getElementById('manual-token').value.trim();
      if (!token) return;
      
      // Set auth in Swagger UI
      window.ui.preauthorizeApiKey('Bearer', token);
      
      // Update status
      document.getElementById('token-status').textContent = 'Token set successfully!';
      document.getElementById('token-status').style.color = 'green';
      
      setTimeout(function() {
        document.getElementById('token-status').textContent = '';
      }, 3000);
    });
    
    document.getElementById('clear-token-btn').addEventListener('click', function() {
      // Clear auth in Swagger UI
      window.ui.getSystem().authActions.logout(['Bearer']);
      
      // Clear input
      document.getElementById('manual-token').value = '';
      
      // Update status
      document.getElementById('token-status').textContent = 'Token cleared!';
      document.getElementById('token-status').style.color = 'orange';
      
      setTimeout(function() {
        document.getElementById('token-status').textContent = '';
      }, 3000);
    });
  }
})();