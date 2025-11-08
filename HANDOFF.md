# Unity Client Handoff Document

**Project**: Beabodocl-Unity  
**Date**: November 7, 2025  
**Platform**: Unity 2022.3 LTS  
**Target Devices**: Meta Quest 2/3, SteamVR

---

## Executive Summary

This handoff document provides everything needed to begin Unity VR client development for the Babocument research platform. The Unity client complements the existing Babylon.js web client with native VR performance and app store distribution.

### What's Included

1. ✅ **README.md** - Project overview and quick start guide
2. ✅ **IMPLEMENTATION_PLAN.md** - Complete development guide with code examples
3. ✅ **GITHUB_ISSUES.md** - Unity-specific issue descriptions
4. ✅ **PRIORITIZED_TASKS.md** - Phase-based development roadmap
5. ✅ **HANDOFF.md** - This document

---

## Project Overview

### Architecture

```
Unity VR Client (C#)
    ↓ UnityWebRequest
Babocument Backend (Python/FastAPI)
    ↓
Multi-Agent AI System
ChromaDB Vector Database
LLM (Ollama)
```

### Technology Stack

| Component | Technology | Version |
|-----------|-----------|---------|
| Game Engine | Unity | 2022.3 LTS |
| Language | C# | 10.0 |
| VR Framework | XR Interaction Toolkit | 2.5.0+ |
| XR Platforms | Oculus XR Plugin, OpenXR | Latest |
| HTTP Client | UnityWebRequest | Built-in |
| JSON | Newtonsoft.Json | 13.0+ |
| Testing | Unity Test Framework | Built-in |
| Target Devices | Quest 2, Quest 3, SteamVR | - |

### Key Differences from Babylon.js Client

**Unity Advantages:**
- ✅ Native VR: 90-120 FPS vs 60-72 FPS
- ✅ App store distribution (Meta Quest Store, Steam)
- ✅ Offline capability
- ✅ Full GPU access for medical imaging
- ✅ Built-in NavMesh, XR Toolkit

**Unity Trade-offs:**
- ⚠️ Larger builds (~100 MB vs ~10 MB)
- ⚠️ Platform-specific builds (Android/Windows)
- ⚠️ Updates require app update (vs instant web deploy)
- ⚠️ Learning curve: C# + Unity Editor

---

## Documentation Structure

### Primary Documents

**1. IMPLEMENTATION_PLAN.md** (Most Important)
- Complete step-by-step development guide
- Full C# code examples for every component
- Sprint-by-sprint breakdown
- 4 development phases with hour estimates

**2. GITHUB_ISSUES.md**
- Unity-specific issue descriptions
- Comparison with Babylon.js implementations
- Unity advantages for each feature
- Issue creation templates

**3. PRIORITIZED_TASKS.md**
- Quick reference for task order
- Timeline and milestones
- Resource allocation options
- Critical path items

**4. README.md**
- Project overview
- Quick start guide
- System requirements
- Unity project structure

---

## Getting Started

### Prerequisites

**Software:**
- Unity Hub (latest)
- Unity Editor 2022.3 LTS
- Visual Studio 2022 or VS Code
- Git for version control

**Hardware (Development):**
- Windows 10/11 or macOS 11+
- 16GB RAM (32GB recommended)
- NVIDIA GTX 1060 / AMD RX 580 or better
- Meta Quest 2/3 (for VR testing)

**Backend:**
- Babocument server running (C:\Users\b\src\babocument)
- Backend URL: http://192.168.1.200:8000

### First Week Checklist

**Day 1-2: Setup**
- [ ] Install Unity Hub
- [ ] Install Unity 2022.3 LTS
- [ ] Create new Unity project
- [ ] Install XR Interaction Toolkit package
- [ ] Install Oculus XR Plugin
- [ ] Install OpenXR Plugin
- [ ] Configure project for Android (Quest) and Windows (PC VR)

**Day 3-4: Basic Scene**
- [ ] Create MainScene.unity
- [ ] Add XR Origin with camera and controllers
- [ ] Configure Locomotion System
- [ ] Add basic environment (floor, skybox)
- [ ] Test in Unity editor
- [ ] Test on VR headset

**Day 5: API Client Start**
- [ ] Create folder structure (Scripts/API, Scripts/UI, etc.)
- [ ] Create ApiClient.cs base class
- [ ] Create ApiConfig ScriptableObject
- [ ] Test basic GET request to backend

---

## Implementation Roadmap

### Phase 1: Foundation (4-6 weeks)

**Goals:**
- Unity project configured for VR
- API client working
- Error handling in place
- Loading states functional

**Key Deliverables:**
- XR Rig with teleportation and movement
- ApiClient.cs with GET/POST methods
- AgentApi.cs for chat endpoints
- ErrorManager and LoadingOverlay

**Estimated Hours:** 40-58 hours

**See**: IMPLEMENTATION_PLAN.md - Phase 1

---

### Phase 2: Core VR Features (6-8 weeks)

**Goals:**
- VR chat interface complete
- Document visualization working
- VR navigation polished
- Testing framework established

**Key Deliverables:**
- ChatPanel3D.cs for VR chat
- DocumentCard3D.cs for documents
- DocumentGrid.cs with multiple layouts
- VR locomotion with NavMesh

**Estimated Hours:** 72-100 hours

**See**: IMPLEMENTATION_PLAN.md - Phase 2

---

### Phase 3: Advanced Features (8-12 weeks)

**Goals:**
- Data visualization (charts, word clouds)
- VR performance optimized
- DICOM medical imaging (optional)
- Comprehensive testing

**Key Deliverables:**
- Keyword trend visualizations
- 90+ FPS on Quest 2
- fo-dicom integration (if needed)
- Test coverage >70%

**Estimated Hours:** 126-174 hours

**See**: IMPLEMENTATION_PLAN.md - Phase 3

---

### Phase 4: Polish & Launch (4-6 weeks)

**Goals:**
- Documentation complete
- Beta testing done
- Builds for Quest and SteamVR
- Ready for store submission

**Deliverables:**
- User documentation
- Video tutorials
- Quest APK
- SteamVR build
- Store submission materials

**Estimated Hours:** 54-78 hours

**See**: IMPLEMENTATION_PLAN.md - Phase 4

---

## Key Code Examples

### API Client Pattern

```csharp
// Assets/Scripts/API/ApiClient.cs
public class ApiClient : MonoBehaviour
{
    public static ApiClient Instance { get; private set; }
    
    public async Task<T> Post<T>(string endpoint, object data)
    {
        string url = $"{config.BaseUrl}{endpoint}";
        string json = JsonConvert.SerializeObject(data);
        
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            
            await SendRequest(request);
            return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);
        }
    }
}
```

### Agent Chat Integration

```csharp
// Assets/Scripts/API/AgentApi.cs
public async Task<ChatResponse> SendMessage(string message, string conversationId = null)
{
    var request = new ChatRequest
    {
        message = message,
        conversation_id = conversationId
    };
    
    return await ApiClient.Instance.Post<ChatResponse>("/api/v1/agent/chat", request);
}
```

### VR Chat Panel

```csharp
// Assets/Scripts/Chat/ChatPanel3D.cs
private async void OnSendMessage()
{
    string message = inputField.text;
    AddMessage("You", message, Color.blue);
    
    try
    {
        ChatResponse response = await AgentApi.Instance.SendMessage(message, conversationId);
        AddMessage("Agent", response.message, Color.green);
    }
    catch (Exception ex)
    {
        AddMessage("Error", ex.Message, Color.red);
    }
}
```

**See**: IMPLEMENTATION_PLAN.md for complete code examples

---

## Unity-Specific Implementation Notes

### XR Interaction Toolkit

Unity's XR Interaction Toolkit provides:
- **Pre-built locomotion** (teleport, continuous move)
- **Controller input mapping** (automatic)
- **Interaction system** (grab, select, hover)
- **Comfort settings** (vignette, snap turn)

**Advantage**: Saves ~20 hours vs custom implementation

### NavMesh System

Unity's built-in NavMesh:
- Visual baking in editor
- Runtime queries for height
- Obstacle avoidance
- Multi-level support

**Advantage**: Saves ~10 hours vs Recast.js integration

### Performance Tools

Unity Profiler provides:
- CPU profiling (script performance)
- GPU profiling (rendering)
- Memory profiling (allocations)
- Physics profiling

**Advantage**: Better than browser dev tools for VR

---

## Backend Integration

### API Endpoints Used

The Unity client will consume the same Babocument backend as the Babylon client:

**Agent Chat:**
```
POST /api/v1/agent/chat
GET /api/v1/agent/conversations/{id}
DELETE /api/v1/agent/conversations/{id}
```

**Documents:**
```
GET /api/v1/documents
POST /api/v1/documents
GET /api/v1/documents/{id}
POST /api/v1/documents/search
```

**Note**: Backend implementation is identical for both clients.

### Configuration

Create `Assets/Config/ApiConfig.asset`:
```
Backend URL: http://192.168.1.200:8000
Timeout: 30 seconds
Max Retries: 3
```

---

## Testing Strategy

### Unity Test Framework

**Edit Mode Tests:**
- Data model serialization
- Utility function logic
- No Play mode required

**Play Mode Tests:**
- API integration
- Scene functionality
- VR interactions
- Async operations

**Example Test:**
```csharp
[UnityTest]
public IEnumerator TestAgentChat()
{
    var task = AgentApi.Instance.SendMessage("Hello");
    yield return new WaitUntil(() => task.IsCompleted);
    Assert.IsNotNull(task.Result);
}
```

### Performance Testing

**Target Metrics:**
- Quest 2: 90 FPS
- Quest 3: 120 FPS  
- PC VR: 90-120 FPS
- Draw calls: <100
- Memory: <1GB

**Tools:**
- Unity Profiler
- Quest Performance HUD
- SteamVR frame timing

---

## Build & Deployment

### Quest Build

```
File > Build Settings
Platform: Android
Texture Compression: ASTC
Graphics API: Vulkan
IL2CPP, ARM64
Build And Run
```

### PC VR Build

```
File > Build Settings
Platform: Windows
Architecture: x86_64
Graphics API: DirectX 11
Build
```

### CI/CD

Options:
- Unity Cloud Build
- GitHub Actions with Unity Builder
- Custom Jenkins pipeline

---

## Risk Assessment

### High Risk: VR Performance

**Risk**: May not achieve 90 FPS on Quest 2

**Mitigation**:
- Early profiling (Week 2)
- LOD groups from start
- Occlusion culling
- GPU instancing
- Target Quest 3 if needed

**Likelihood**: Medium  
**Impact**: High

### Medium Risk: DICOM Complexity

**Risk**: 3D medical imaging may be complex

**Mitigation**:
- Use proven fo-dicom library
- Start with 2D slices only
- Scale to 3D later
- Partner with experts if needed

**Likelihood**: Medium  
**Impact**: Medium (feature can be deferred)

### Low Risk: API Integration

**Risk**: C# API client issues

**Mitigation**:
- Pattern proven in Babylon client
- UnityWebRequest well-documented
- Backend already exists and tested

**Likelihood**: Low  
**Impact**: Medium

---

## Resource Requirements

### Solo Developer

**Timeline**: 8-12 months  
**Scope**: Phases 1-2 complete, selective Phase 3  
**Skills Needed**:
- Unity C# development
- XR Interaction Toolkit
- REST API integration

### Two Developers

**Timeline**: 6-8 months  
**Scope**: All phases  
**Split**:
- Developer A: API, Backend, Data
- Developer B: VR, UI, 3D Assets

### Three+ Developers

**Timeline**: 4-6 months  
**Scope**: All phases + polish  
**Team**:
- Unity VR Developer
- C# Backend Integration
- QA/DevOps Engineer

---

## Success Metrics

### Technical
- [ ] 90+ FPS on Quest 2
- [ ] <2 second scene load
- [ ] <1 second API response
- [ ] >70% test coverage
- [ ] Zero critical bugs

### User Experience
- [ ] Chat with agent in VR
- [ ] Browse documents in 3D
- [ ] Comfortable VR navigation
- [ ] Intuitive interactions
- [ ] Search and discovery working

### Business
- [ ] Meta Quest Store ready
- [ ] SteamVR distribution ready
- [ ] Documentation complete
- [ ] Beta users satisfied (4/5+)

---

## Next Steps

### Immediate Actions (This Week)

1. **Review Documentation**
   - [ ] Read IMPLEMENTATION_PLAN.md fully
   - [ ] Review PRIORITIZED_TASKS.md
   - [ ] Scan GITHUB_ISSUES.md

2. **Setup Unity**
   - [ ] Install Unity 2022.3 LTS
   - [ ] Create new project
   - [ ] Install XR packages
   - [ ] Test basic VR scene

3. **Verify Backend**
   - [ ] Confirm Babocument server running
   - [ ] Test API endpoints with Postman/curl
   - [ ] Document backend URL

### Next Week

4. **API Client Development**
   - [ ] Create ApiClient.cs
   - [ ] Create data models
   - [ ] Test GET /api/v1/documents
   - [ ] Test POST /api/v1/agent/chat

5. **Error Handling**
   - [ ] Create ErrorManager
   - [ ] Create LoadingOverlay
   - [ ] Test error scenarios

### Month 1 Goal

Complete **Phase 1** (Foundation):
- ✅ Unity project configured
- ✅ XR Rig functional
- ✅ API client working
- ✅ Error handling in place
- ✅ Basic VR navigation

---

## Support & Resources

### Documentation
- IMPLEMENTATION_PLAN.md - Complete development guide
- GITHUB_ISSUES.md - Issue tracker
- PRIORITIZED_TASKS.md - Task roadmap
- README.md - Project overview

### External Resources
- Unity XR Interaction Toolkit: https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@latest
- Unity Manual: https://docs.unity3d.com/Manual/
- Meta Quest Development: https://developer.oculus.com/documentation/unity/
- Backend Repository: https://github.com/buddha314/babocument

### Issues & Questions
- GitHub Issues: https://github.com/buddha314/beabodocl-unity/issues (to be created)
- Backend Issues: https://github.com/buddha314/babocument/issues

---

## Comparison with Babylon Client

### Feature Parity

Both clients will implement:
- ✅ Agent chat interface
- ✅ Document visualization
- ✅ VR navigation
- ✅ Search functionality
- ✅ Data visualization
- ✅ DICOM support (optional)

### Unity-Specific Advantages

- **Performance**: 90+ FPS vs 60-72 FPS
- **Distribution**: App stores vs web link
- **Offline**: Full offline vs limited PWA
- **NavMesh**: Built-in vs external library
- **XR Input**: Official toolkit vs custom
- **Medical Imaging**: Compute shaders vs WebGL

### When to Use Each Client

**Unity (Native):**
- Quest store distribution
- Maximum VR performance
- Offline capability
- Medical imaging features
- Enterprise deployment

**Babylon (Web):**
- Quick prototypes
- Easy updates (hot reload)
- Broader device reach
- No installation required
- Easier to share

---

## Project Status

**Current State**: Planning Complete ✅

**Deliverables Created:**
- ✅ README.md
- ✅ IMPLEMENTATION_PLAN.md (complete with code)
- ✅ GITHUB_ISSUES.md
- ✅ PRIORITIZED_TASKS.md
- ✅ HANDOFF.md (this document)

**Ready for**: Unity development to begin

**Next Milestone**: Phase 1 complete (4-6 weeks)

---

## Handoff Checklist

### Documentation Complete
- [x] README.md created
- [x] IMPLEMENTATION_PLAN.md with full code examples
- [x] GITHUB_ISSUES.md with Unity-specific issues
- [x] PRIORITIZED_TASKS.md with timeline
- [x] HANDOFF.md (this document)

### Ready for Developer
- [x] Clear architecture defined
- [x] Technology stack specified
- [x] Code examples provided
- [x] Timeline estimated
- [x] Risks identified
- [x] Success metrics defined

### Next Steps Defined
- [x] Week 1 tasks clear
- [x] Month 1 goal set
- [x] Phase-by-phase breakdown
- [x] Resource requirements identified

---

**Handoff Date**: November 7, 2025  
**Status**: ✅ Complete - Ready for Development  
**Prepared By**: AI Development Assistant  
**Contact**: See GitHub issues

**Ready to begin Unity VR development! 🚀**
