# GitHub Issues for Unity Client

**Project**: Beabodocl-Unity  
**Date Created**: November 7, 2025  
**Platform**: Unity 2022.3 LTS  
**Status**: Ready for Issue Creation

---

## Overview

This document outlines GitHub issues for the Unity VR client implementation. These issues mirror the Babylon.js client issues but are adapted for Unity's architecture and C# development.

For complete implementation details, see **[IMPLEMENTATION_PLAN.md](./IMPLEMENTATION_PLAN.md)**.

---

## Issue Mapping from Babylon to Unity

The Unity client will implement the same features as the Babylon client, with Unity-specific implementations:

| Babylon Issue | Unity Equivalent | Changes for Unity |
|---------------|------------------|-------------------|
| #1 Agent API Integration | #1 Agent API Integration (C#) | Use UnityWebRequest, C# async/await |
| #2 Authentication | #2 Authentication (C#) | Unity PlayerPrefs for tokens |
| #3 Error Boundaries | #3 Unity Error Handling | Try-catch in C#, no React concepts |
| #4 Agent Search | #4 Agent Search (Unity) | Unity UI Toolkit |
| #5 Loading States | #5 Unity Loading System | Scene loading, async operations |
| #6 Document Search 3D | #6 Document Search (XR) | XR Interaction Toolkit |
| #7 Security | #7 Security (Unity) | Build obfuscation, secure storage |
| #8 Chat History | #8 Chat Persistence | Unity serialization |
| #9 NavMesh Movement | #9 Unity NavMesh | Built-in Unity NavMesh |
| #10 VR Strafing | #10 XR Locomotion | XR Interaction Toolkit |

---

## Critical Priority (P0) Issues

### Issue #1: Implement Agent API Integration (C#)

**Labels:** `critical`, `backend`, `unity`, `api`  
**Priority:** P0 - Critical  
**Effort:** 16-24 hours  
**Milestone:** v0.2.0

**Unity-Specific Implementation:**
- Create `ApiClient.cs` using UnityWebRequest
- Implement async/await with Unity coroutines
- Use Newtonsoft.Json for serialization
- Create ScriptableObject for API configuration

**Key Files to Create:**
- `Assets/Scripts/API/ApiClient.cs`
- `Assets/Scripts/API/AgentApi.cs`
- `Assets/Scripts/API/Models/ChatMessage.cs`
- `Assets/Config/ApiConfig.asset`

**See**: IMPLEMENTATION_PLAN.md - Sprint 1.2 for complete code

---

### Issue #2: Add Authentication System (Unity)

**Labels:** `critical`, `security`, `unity`  
**Priority:** P0 - Critical  
**Effort:** 18-26 hours  
**Milestone:** v0.3.0

**Unity-Specific Implementation:**
- Use PlayerPrefs for secure token storage
- Implement AuthManager singleton
- Create login/register Unity UI
- Add authentication headers to all API requests

**Key Classes:**
- `AuthManager.cs` - Handles login/logout
- `TokenStorage.cs` - Secure token persistence
- `LoginPanel.cs` - UI for authentication

---

### Issue #3: Implement Unity Error Handling

**Labels:** `critical`, `unity`, `ux`  
**Priority:** P0 - Critical  
**Effort:** 6-10 hours  
**Milestone:** v0.2.0

**Unity-Specific Implementation:**
- Create ErrorManager singleton
- Implement try-catch in all API calls
- Create error UI panels
- Add Application.logMessageReceived listener for crashes

**Key Classes:**
- `ErrorManager.cs`
- `ErrorPanel.cs`
- `ExceptionHandler.cs`

**See**: IMPLEMENTATION_PLAN.md - Sprint 1.3

---

## High Priority (P1) Issues

### Issue #4: Implement Agent-Assisted Paper Discovery

**Labels:** `high-priority`, `ai`, `unity`  
**Priority:** P1 - High  
**Effort:** 16-22 hours  
**Milestone:** v0.3.0

**Unity-Specific Implementation:**
- Unity UI Toolkit for search interface
- TextMeshPro for rich text display
- XR keyboard for VR text input
- Optional voice recognition integration

---

### Issue #5: Add Unity Loading System

**Labels:** `high-priority`, `ux`, `unity`  
**Priority:** P1 - High  
**Effort:** 6-10 hours  
**Milestone:** v0.2.0

**Unity-Specific Implementation:**
- Scene async loading
- LoadingOverlay canvas
- Progress bars with Unity Slider
- Loading tips rotation

**Key Classes:**
- `LoadingOverlay.cs`
- `SceneLoader.cs`
- `AsyncOperationHandler.cs`

**See**: IMPLEMENTATION_PLAN.md - Sprint 1.3

---

### Issue #6: Implement Document Search in VR (XR)

**Labels:** `high-priority`, `vr`, `xr`, `unity`  
**Priority:** P1 - High  
**Effort:** 18-26 hours  
**Milestone:** v0.3.0

**Unity-Specific Implementation:**
- XR Interaction Toolkit for interactions
- 3D canvas for search UI
- XRSimpleInteractable on cards
- Ray interactors for selection
- Voice commands via Windows Speech API

**Key Classes:**
- `DocumentGrid.cs`
- `DocumentCard3D.cs`
- `XRSearchPanel.cs`

**See**: IMPLEMENTATION_PLAN.md - Sprint 2.3

---

### Issue #7: Security Hardening (Unity Build)

**Labels:** `high-priority`, `security`, `unity`  
**Priority:** P1 - High  
**Effort:** 10-14 hours  
**Milestone:** v0.3.0

**Unity-Specific Security:**
- Code obfuscation for builds
- Secure PlayerPrefs encryption
- Certificate pinning for API
- Build with IL2CPP (not Mono)
- Remove debug logging in release builds

---

### Issue #8: Implement Chat History Persistence

**Labels:** `high-priority`, `unity`, `storage`  
**Priority:** P1 - High  
**Effort:** 10-14 hours  
**Milestone:** v0.3.0

**Unity-Specific Implementation:**
- Unity JsonUtility or Newtonsoft.Json
- Save to Application.persistentDataPath
- Create ConversationData ScriptableObject
- Implement save/load system

**Key Classes:**
- `ConversationManager.cs`
- `ConversationData.cs` (ScriptableObject)
- `SaveSystem.cs`

---

## Medium Priority (P2) Issues

### Issue #9: Unity NavMesh for VR Movement

**Labels:** `medium-priority`, `vr`, `unity`, `navmesh`  
**Priority:** P2 - Medium  
**Effort:** 6-10 hours  
**Milestone:** v0.4.0

**Unity-Specific Implementation:**
- Built-in Unity NavMesh system
- Bake NavMesh from scene geometry
- NavMesh.SamplePosition for height validation
- Integrate with XR locomotion

**Unity Advantages:**
- NavMesh is built-in (no external library needed)
- Visual NavMesh baking in editor
- Runtime NavMesh generation
- Obstacle avoidance built-in

**See**: IMPLEMENTATION_PLAN.md - Sprint 2.2

---

### Issue #10: XR Locomotion System

**Labels:** `medium-priority`, `vr`, `xr`, `unity`  
**Priority:** P2 - Medium  
**Effort:** 8-12 hours  
**Milestone:** v0.4.0

**Unity-Specific Implementation:**
- Use XR Interaction Toolkit locomotion providers
- Teleportation Provider (built-in)
- Continuous Move Provider (built-in)
- Snap/Smooth Turn Provider
- Configure comfort settings

**Unity Advantages:**
- Locomotion components provided by XR Toolkit
- No custom joystick code needed
- Built-in comfort options (vignette, etc.)
- Controller mapping handled automatically

**Key Components:**
- TeleportationProvider
- ContinuousMoveProviderBase
- SnapTurnProvider or ContinuousTurnProvider
- LocomotionSystem

**See**: IMPLEMENTATION_PLAN.md - Sprint 2.2

---

### Issue #11: Data Visualization - Keyword Trends (Unity)

**Labels:** `medium-priority`, `visualization`, `unity`  
**Priority:** P2 - Medium  
**Effort:** 12-16 hours  
**Milestone:** v0.4.0

**Unity Charting Options:**
1. **Unity UI Toolkit** - Built-in charting (Unity 2021.2+)
2. **TextMesh Pro + Custom Meshes** - Generate chart geometry
3. **Third-party**: XCharts, Graph And Chart, etc.

**Recommended**: Custom mesh generation for VR-optimized charts

---

### Issue #12: DICOM Medical Imaging (Unity)

**Labels:** `medium-priority`, `medical`, `unity`  
**Priority:** P2 - Medium  
**Effort:** 40-60 hours  
**Milestone:** v0.5.0

**Unity-Specific Implementation:**
- **fo-dicom** library for C# DICOM parsing
- **Compute shaders** for volume rendering
- **RenderTexture** for slice display
- **Custom shaders** for windowing/leveling

**Unity Advantages:**
- Powerful compute shaders for medical imaging
- GPU acceleration for volume rendering
- VR-optimized rendering
- Better performance than WebGL

**See**: IMPLEMENTATION_PLAN.md - Phase 3

---

### Issue #13: VR Performance Optimization

**Labels:** `medium-priority`, `performance`, `vr`, `unity`  
**Priority:** P2 - Medium  
**Effort:** 14-20 hours  
**Milestone:** v0.4.0

**Unity Optimization Techniques:**
- **LOD Groups** - Automatic detail reduction
- **Occlusion Culling** - Built-in portal culling
- **GPU Instancing** - Draw many objects with one call
- **Texture Atlasing** - Reduce draw calls
- **Static Batching** - Combine static meshes
- **Object Pooling** - Reuse GameObjects
- **Async Scene Loading** - Stream assets

**Unity Profiler:**
- CPU profiling
- GPU profiling  
- Memory profiling
- Physics profiling

**Target Performance:**
- Quest 2: 90 FPS
- Quest 3: 120 FPS
- PC VR: 90-120 FPS

---

## Low Priority (P3) Issues

### Issue #14: Collaborative Features (Unity Netcode)

**Labels:** `low-priority`, `multiplayer`, `unity`  
**Priority:** P3 - Low  
**Effort:** 30-50 hours  
**Milestone:** v0.6.0

**Unity Multiplayer Options:**
1. **Unity Netcode for GameObjects** - Official solution
2. **Photon Unity Networking (PUN)** - Popular third-party
3. **Mirror** - Open-source networking

**Features:**
- Shared VR space
- See other users' avatars
- Shared document annotations
- Voice chat integration

---

### Issue #15: Voice Commands for VR (Unity)

**Labels:** `low-priority`, `vr`, `voice`, `unity`  
**Priority:** P3 - Low  
**Effort:** 12-16 hours  
**Milestone:** v0.6.0

**Unity Voice Recognition:**
- **Windows Speech API** - Built-in C# support
- **Azure Speech Services** - Cloud-based
- **Meta Voice SDK** - Quest-specific

**Commands:**
- "Search for [query]"
- "Open document"
- "Next page"
- "Go home"

---

## Creating GitHub Issues

### Issue Template

For each issue above, create a GitHub issue with:

```markdown
**Title**: [Issue Number]: [Issue Title]

**Labels**: [labels from above]
**Priority**: [P0/P1/P2/P3]
**Milestone**: [version]
**Effort**: [hours]

**Description**:
[Copy from above]

**Unity-Specific Details**:
[Technical implementation notes]

**Files to Create/Modify**:
- [ ] File 1
- [ ] File 2

**Acceptance Criteria**:
- [ ] Criterion 1
- [ ] Criterion 2

**See Also**:
- IMPLEMENTATION_PLAN.md - [Relevant sprint]
```

---

## Unity vs Babylon Comparison

### Advantages of Unity Implementation

| Feature | Unity | Babylon |
|---------|-------|---------|
| **NavMesh** | Built-in, visual editor | Requires Recast.js library |
| **XR Input** | XR Interaction Toolkit (official) | Custom WebXR code |
| **Locomotion** | Pre-built providers | Custom implementation |
| **Performance** | Native 90+ FPS | 60-72 FPS WebGL |
| **3D Assets** | Drag-and-drop prefabs | Code-based creation |
| **UI** | Unity UI/UI Toolkit | Babylon GUI or HTML |
| **Networking** | Netcode/Photon/Mirror | Custom or libraries |
| **Profiling** | Deep Unity Profiler | Browser dev tools |

### Trade-offs

| Aspect | Unity | Babylon |
|--------|-------|---------|
| **Distribution** | App stores, sideload | URL/link |
| **Updates** | App update required | Instant deployment |
| **Platform** | Build per platform | Universal browser |
| **Learning Curve** | C# + Unity editor | TypeScript |
| **Build Time** | Minutes per platform | Seconds (web build) |
| **File Size** | ~100 MB APK | ~10 MB initial load |

---

## Next Steps

1. **Create GitHub Issues**: Use this document to create issues in GitHub repository
2. **Prioritize**: Start with P0 issues (API integration, error handling)
3. **Sprint Planning**: Use IMPLEMENTATION_PLAN.md for detailed sprint tasks
4. **Development**: Follow Unity implementation patterns in IMPLEMENTATION_PLAN.md

---

**Document Status**: Complete  
**Last Updated**: November 7, 2025  
**Ready For**: GitHub issue creation and development planning
