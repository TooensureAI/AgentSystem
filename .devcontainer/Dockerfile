FROM mcr.microsoft.com/dotnet/sdk:9.0

# Install necessary packages
RUN apt-get update && apt-get install -y \
    git \
    curl \
    unzip \
    nodejs \
    npm \
    python3 \
    python3-venv \
    python3-pip \
    && rm -rf /var/lib/apt/lists/*

# Install .NET workloads for Aspire
RUN dotnet workload install aspire

# Create Python virtual environment for Anthropic SDK
RUN python3 -m venv /opt/anthropic-venv
ENV PATH="/opt/anthropic-venv/bin:${PATH}"

# Install Anthropic Python SDK in the virtual environment
RUN /opt/anthropic-venv/bin/pip install anthropic

# Set up .NET tools directory in PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Install .NET tools individually to better handle failures
RUN dotnet tool install -g Microsoft.dotnet-interactive || echo "Failed to install dotnet-interactive, continuing..."
RUN dotnet tool install -g Microsoft.dotnet-httprepl || echo "Failed to install httprepl, continuing..."
RUN dotnet tool install -g dotnet-dev-certs || echo "Failed to install dev-certs, continuing..."
RUN dotnet tool install -g dotnet-grpc || echo "Failed to install grpc, continuing..."

# Install Anthropic Node.js SDK for Claude Code
RUN npm install -g @anthropic-ai/sdk

# Set up environment variables for Claude SDK
ENV CLAUDE_SDK_HOME=/usr/local/claude-sdk
ENV PATH="${CLAUDE_SDK_HOME}/bin:${PATH}"

# Create Claude SDK directory and placeholder
RUN mkdir -p ${CLAUDE_SDK_HOME}/bin

# Create a proper placeholder script for claude-code command as a bash script
RUN echo '#!/bin/bash\necho "Claude Code SDK is not fully installed."\necho "Please install the official Claude Code SDK from Anthropic if you have access to it."\necho "You can use the Anthropic SDK via Python with the \"anthropic\" package."' > ${CLAUDE_SDK_HOME}/bin/claude-code && \
    chmod +x ${CLAUDE_SDK_HOME}/bin/claude-code

# Set working directory
WORKDIR /workspace 