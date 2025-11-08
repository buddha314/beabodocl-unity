# beabodocl-unity

Unity VR Client for Babocument Research Platform

## Overview

This Unity project provides an immersive VR interface for the Babocument research assistance platform. It allows researchers to interact with academic papers and AI research assistants in a 3D virtual environment.

## Project Context

**Backend Service**: [Babocument](https://github.com/buddha314/babocument)
- **Repository**: https://github.com/buddha314/babocument
- **Local Path**: `C:\Users\b\src\babocument`
- **Tech Stack**: FastAPI, Python, Multi-Agent AI System
- **Database**: ChromaDB (vector database for semantic search)
- **LLM**: Ollama integration with 4 models
- **API Base URL**: http://localhost:8000

## Architecture

```
Unity VR Client (this repo)
    ↕
REST API / WebSocket
    ↕
Babocument Backend Server
    ↕
Multi-Agent AI System
ChromaDB Vector Database
LLM (Ollama)
Research Papers Database
```

## Backend API Endpoints

### Agent Chat
- `POST /api/v1/agent/chat` - Chat with research assistant
- `GET /api/v1/agent/conversations/{id}` - Get conversation history
- `DELETE /api/v1/agent/conversations/{id}` - Delete conversation

### Documents
- `GET /api/v1/documents` - List all documents
- `POST /api/v1/documents` - Upload new document
- `GET /api/v1/documents/{id}` - Get document details
- `DELETE /api/v1/documents/{id}` - Delete document

### Search
- `POST /api/v1/documents/search` - Semantic search
- `GET /api/v1/stats` - Database statistics

## Unity Project Details

- **Unity Version**: (Check ProjectSettings/ProjectVersion.txt)
- **XR Platform**: Unity XR Interaction Toolkit
- **Target Platforms**: VR headsets (Quest, PCVR, etc.)

## Features (Planned)

- [ ] VR environment for paper browsing
- [ ] 3D visualization of research papers
- [ ] Voice/text interaction with AI research assistant
- [ ] Immersive document reading experience
- [ ] Spatial organization of research materials
- [ ] Real-time collaboration features

## Development Setup

### Prerequisites
1. Unity Editor (version TBD)
2. VR headset (optional for testing)
3. Babocument backend server running locally

### Starting the Backend Server

```powershell
cd C:\Users\b\src\babocument
.\start.ps1
```

Backend will be available at:
- API Server: http://localhost:8000
- API Documentation: http://localhost:8000/docs
- Health Check: http://localhost:8000/health

### Unity Project Setup

1. Open this project in Unity Hub
2. Install required packages (XR Interaction Toolkit, etc.)
3. Configure API endpoint in project settings
4. Build and deploy to target platform

## Related Documentation

- Backend API Docs: http://localhost:8000/docs (when server running)
- Backend Repository: https://github.com/buddha314/babocument
- Related Client: [beabodocl-babylon](https://github.com/buddha314/beabodocl-babylon) (WebXR/Babylon.js client)

## Current Status

**Status**: Initial setup and planning phase
**Date**: November 7, 2025

### Recent Changes
- Repository structure reorganized
- Unity project files moved to root level
- .gitignore configured for Unity development
- Ready for initial VR development

### Next Steps
1. Configure Unity XR Interaction Toolkit
2. Create basic VR scene and interaction system
3. Implement API client for backend communication
4. Design UI/UX for VR paper browsing
5. Integrate agent chat functionality

## Backend Features Available

- Multi-Agent AI System with specialized research agents
- Semantic search across 4 indexed bioprinting research papers
- Document analysis and metadata extraction
- Conversational AI interface
- RESTful API with full documentation

## License

(To be determined - coordinate with backend repository license: CC0-1.0)

## Contributors

- Brian Dolan (@buddha314)

## Notes

This is a companion client to the Babocument backend system. The backend provides a multi-agent AI research assistant with semantic search capabilities. This Unity VR client aims to provide an immersive 3D interface for interacting with that research platform.

For backend development and API details, refer to the Babocument repository.
