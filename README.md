# Beabodocl-Unity

**3D VR/XR Client for Babocument Research Platform**

This is a Unity-based 3D visualization and VR interface for the Babocument academic paper analysis system. Built with Unity and XR Interaction Toolkit, it provides an immersive research experience in VR headsets and desktop environments.

> **Backend Repository:** [babocument](https://github.com/buddha314/babocument)  
> **Local Development:** Backend is located at `C:\Users\b\src\babocument`

## Project Overview

**Beabodocl-Unity** is a client application for the Babocument platform, providing native VR/XR capabilities through Unity. Additional clients (web app, mobile apps, desktop applications) are available or planned. This client focuses on providing:

- **3D Scene Visualization** - Immersive Unity 3D environment
- **VR/XR Support** - Full support for Meta Quest, SteamVR, and other VR headsets via Unity XR
- **AI Agent Chat** - Conversational interface for research assistance
- **Document Visualization** - 3D representations of papers and research data
- **Real-time Collaboration** - Multi-user features (planned)
- **Native Performance** - High-performance native VR rendering

## Architecture

```
┌─────────────────────────────────────────┐
│   Beabodocl-Unity (This Repo)          │
│   - Unity 3D Engine                     │
│   - Unity XR Interaction Toolkit        │
│   - Native VR/XR Interface              │
│   - Agent Chat UI                       │
└──────────────┬──────────────────────────┘
               │ REST API
               ▼
┌─────────────────────────────────────────┐
│   Babocument Backend                    │
│   - FastAPI Server                      │
│   - Multi-Agent AI System               │
│   - Vector Database (ChromaDB)          │
│   - LLM Integration (Ollama)            │
└─────────────────────────────────────────┘
```

**Other Clients:**
- Web client (beabodocl-babylon) - Babylon.js/WebXR
- Mobile apps (iOS/Android) - planned
- Desktop applications - planned
- CLI tools - planned


## Getting Started

### Prerequisites

- **Unity Editor**: 2022.3 LTS or later
- **Unity XR Plugin Management**
- **XR Interaction Toolkit** 2.5.0+
- **Meta Quest** (optional, for VR testing)
- **Backend Server**: Babocument server running at `http://localhost:8000` or configured endpoint

### Quick Start

**1. Clone the Repository**
```bash
git clone https://github.com/buddha314/beabodocl-unity.git
cd beabodocl-unity
```

**2. Open in Unity**
- Open Unity Hub
- Click "Open" and select the `beabodocl-unity` folder
- Unity will import the project and resolve dependencies

**3. Configure Backend Connection**
- Open `Assets/Config/AppConfig.asset`
- Set `Backend URL` to your Babocument server address (default: `http://192.168.1.200:8000`)
- Save the configuration

**4. Run in Editor**
- Open the main scene: `Assets/Scenes/MainScene.unity`
- Press Play in Unity Editor
- Use mouse/keyboard controls for desktop testing
- For VR testing, connect headset and enable XR device

**5. Build for VR Headset**
```
File > Build Settings
- Select "Android" platform (for Quest)
- Click "Switch Platform"
- Click "Build And Run"
```

### XR Device Setup

**Meta Quest 2/3:**
```
1. Enable Developer Mode on Quest headset
2. Connect headset via USB or Air Link
3. Unity > Edit > Project Settings > XR Plug-in Management
4. Enable "Oculus" (Meta Quest) checkbox
5. Build and Deploy to headset
```

**SteamVR (PC VR):**
```
1. Install SteamVR on PC
2. Unity > Edit > Project Settings > XR Plug-in Management
3. Enable "OpenXR" checkbox
4. Set Interaction Profile to "OpenXR"
5. Run in editor or build for Windows
```

### Configuration

Configuration is managed through Unity ScriptableObjects:

**Backend Configuration** (`Assets/Config/AppConfig.asset`):
```
Backend URL: http://192.168.1.200:8000
API Timeout: 30 seconds
Retry Attempts: 3
```

For detailed setup instructions including network scenarios and VR headset connectivity, see [STARTUP_GUIDE.md](./STARTUP_GUIDE.md) (coming soon).

## Documentation

### 📋 Quick Reference
- **[PROJECT_TASKS.md](./PROJECT_TASKS.md)** - Master task list (85 tasks organized by priority)
- **[UNITY_INTERFACE_DESIGN.md](./UNITY_INTERFACE_DESIGN.md)** - Complete visual/spatial design specification
- **[IMPLEMENTATION_PLAN.md](./IMPLEMENTATION_PLAN.md)** - Detailed implementation guide with code examples
- **[GITHUB_ISSUES_COMPLETE.md](./GITHUB_ISSUES_COMPLETE.md)** - Ready-to-create GitHub issues

### 🚀 Getting Started
1. **[QUEST3_COMPATIBILITY_REVIEW.md](./QUEST3_COMPATIBILITY_REVIEW.md)** - Fix critical Quest 3 configuration issues (DO THIS FIRST)
2. **[HANDOFF_2025-11-10_UNITY_2022_MIGRATION.md](./HANDOFF_2025-11-10_UNITY_2022_MIGRATION.md)** - Unity 2022.3 LTS migration details
3. **[specs/QUEST3_DEPLOYMENT_GUIDE.md](./specs/QUEST3_DEPLOYMENT_GUIDE.md)** - Deploy to Quest 3 headset

### 📚 All Documentation
See **[docs/DOCUMENTATION_INDEX.md](./docs/DOCUMENTATION_INDEX.md)** for complete documentation index organized by role and purpose.

### GitHub Issues
**Total Issues**: 85+ tasks ready for creation  
See [GITHUB_ISSUES_COMPLETE.md](./GITHUB_ISSUES_COMPLETE.md) for copy/paste issue creation  
Track development: https://github.com/buddha314/beabodocl-unity/issues (to be created)

## Unity Project Structure

```
beabodocl-unity/
├── Assets/
│   ├── Scenes/
│   │   ├── MainScene.unity           # Main VR scene
│   │   └── TestScenes/               # Development test scenes
│   ├── Scripts/
│   │   ├── API/                      # Backend API integration
│   │   ├── UI/                       # UI components
│   │   ├── VR/                       # VR-specific scripts
│   │   ├── Chat/                     # Agent chat system
│   │   └── Managers/                 # Game managers
│   ├── Prefabs/
│   │   ├── UI/                       # UI prefabs
│   │   ├── Documents/                # Document visualization
│   │   └── VR/                       # VR interaction prefabs
│   ├── Materials/                    # Materials and shaders
│   ├── Config/                       # Configuration assets
│   └── XR/                           # XR Interaction Toolkit setup
├── Packages/
│   └── manifest.json                 # Package dependencies
└── ProjectSettings/
    └── XRSettings.asset              # XR configuration
```

## Features

### Current Features (v0.1.0)
- ✅ Basic 3D scene with Unity rendering
- ✅ VR support via XR Interaction Toolkit
- ✅ Basic locomotion (teleportation)
- ✅ Desktop and VR input handling

### Planned Features

**Phase 1: Foundation**
- Agent API integration
- Authentication system
- Error handling and recovery
- Loading states and UI feedback

**Phase 2: Core Features**
- Agent-assisted paper discovery
- 3D document search and visualization
- Chat history persistence
- VR voice commands

**Phase 3: Advanced Features**
- Data visualization (keyword trends, word clouds)
- DICOM medical imaging support
- 3D document browser with multiple layouts
- Performance optimization for VR

**Phase 4: Polish**
- Collaborative features
- Knowledge graph visualization
- Export capabilities
- Advanced VR interactions

## Development

### Building for Different Platforms

**Android (Meta Quest):**
```bash
# From Unity Editor
File > Build Settings
Platform: Android
Texture Compression: ASTC
Run Device: [Your Quest headset]
Build And Run
```

**Windows (PC VR):**
```bash
# From Unity Editor
File > Build Settings
Platform: Windows
Architecture: x86_64
Build
```

**Editor Testing:**
```
Play Mode in Unity Editor
Use XR Device Simulator for VR testing without headset
Mouse + Keyboard controls for desktop mode
```

### Scripts and Tools

Development scripts are located in `Assets/Editor/`:
- `BuildTools.cs` - Automated build scripts
- `ConfigValidator.cs` - Validate project configuration
- `TestRunner.cs` - Run automated tests

### Testing

Unity Test Framework is used for testing:
```
Window > General > Test Runner
Run all tests in Edit Mode
Run all tests in Play Mode
```

## Learn More

### Unity Resources
- [Unity XR Interaction Toolkit Documentation](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@latest)
- [Unity Manual](https://docs.unity3d.com/Manual/index.html)
- [Unity Scripting API](https://docs.unity3d.com/ScriptReference/)

### VR Development
- [Meta Quest Development](https://developer.oculus.com/documentation/unity/)
- [OpenXR Documentation](https://www.khronos.org/openxr/)

### Babocument Platform
- [Backend Repository](https://github.com/buddha314/babocument)
- [Web Client (Babylon)](https://github.com/buddha314/beabodocl-babylon)

## System Requirements

### Development
- **OS**: Windows 10/11 or macOS 11+
- **Unity**: 2022.3 LTS or later
- **RAM**: 16GB minimum, 32GB recommended
- **GPU**: NVIDIA GTX 1060 / AMD RX 580 or better
- **Storage**: 10GB for project + Unity installation

### VR Runtime
- **Meta Quest 2/3**: Android build
- **PC VR**: Windows 10/11, NVIDIA GTX 1060 or better, SteamVR compatible headset
- **Network**: WiFi for Air Link or USB-C cable

## Deployment

### Meta Quest Store
1. Build optimized Android APK
2. Submit to Meta Quest Store
3. Follow Meta's app review guidelines

### SteamVR
1. Build Windows executable
2. Package with SteamVR support
3. Submit to Steam

### Enterprise Deployment
1. Build and sign APK/EXE
2. Distribute via MDM or direct download
3. Configure backend URL for production

## Contributing

Contributions are welcome! Please follow these guidelines:
1. Fork the repository
2. Create a feature branch
3. Follow Unity C# coding standards
4. Write tests for new features
5. Submit a pull request

## License

This project is part of the Babocument platform. See [LICENSE](./LICENSE) for details.

## Support

For issues and questions:
- GitHub Issues: https://github.com/buddha314/beabodocl-unity/issues
- Backend Issues: https://github.com/buddha314/babocument/issues
- Documentation: See `/docs` folder

---

**Status**: In Development  
**Current Version**: v0.1.0  
**Unity Version**: 2022.3 LTS  
**Last Updated**: November 7, 2025

