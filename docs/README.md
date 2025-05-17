# AgentSystem GitHub Pages

This directory contains the source files for the AgentSystem GitHub Pages site.

## Structure

- `index.html` - Main landing page with Telerik UI components
- `swagger/` - Swagger UI documentation
  - `index.html` - Swagger UI interface
  - `openapi.json` - OpenAPI specification for the AgentSystem API
- `styles.css` - Shared styles for the site

## Development

To test the GitHub Pages site locally:

1. Install Jekyll and its dependencies (Ruby, Bundler)
2. Run the following command from the root directory:

```bash
cd docs
bundle exec jekyll serve
```

3. Open your browser to `http://localhost:4000`

## Deployment

The GitHub Pages site is automatically deployed when changes are pushed to the `main` branch in the `docs/` directory. This is handled by the GitHub workflow in `.github/workflows/github-pages.yml`.

## Updating the OpenAPI Specification

To update the API documentation:

1. Edit the `docs/swagger/openapi.json` file
2. Commit and push your changes
3. The GitHub Pages site will be automatically updated

## Adding New Pages

To add a new page to the site:

1. Create a new HTML file in the `docs/` directory
2. Link to it from the existing pages
3. Ensure it includes the proper CSS and JS imports