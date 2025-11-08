# GitHub Issues for Unity Client

**Project**: Beabodocl-Unity  
**Date Created**: November 7, 2025  
**Date Updated**: November 7, 2025 (Added Quest 3 Compatibility Issues)  
**Platform**: Unity 2022.3 LTS  
**Status**: Ready for Issue Creation

---

## ⚠️ URGENT: Quest 3 Compatibility Issues (Phase 0)

**CRITICAL**: The project has compatibility issues that prevent Quest 3 deployment. These must be fixed FIRST before any other development.

**See**: [QUEST3_COMPATIBILITY_REVIEW.md](./QUEST3_COMPATIBILITY_REVIEW.md) for detailed analysis

### Quest 3 Configuration Issues (Create These Issues First)

---

#### Issue #QUEST-1: Downgrade Unity Version to 2022.3 LTS

**Labels:** `critical`, `configuration`, `quest3`, `P0`  
**Priority:** P0 - BLOCKING  
**Effort:** 1-2 hours  
**Milestone:** v0.1.0 - Quest 3 Compatibility

**Problem:**
Project is using Unity 6 (6000.2.10f1) which is too new and may have compatibility issues with Quest 3 SDK and packages.

**Fix Required:**
1. Download Unity 2022.3 LTS from Unity Hub
2. Open project in Unity 2022.3 LTS
3. Allow Unity to upgrade/downgrade project files
4. Resolve any package compatibility issues
5. Verify all XR packages still work

**Acceptance Criteria:**
- [ ] Project opens in Unity 2022.3 LTS without errors
- [ ] All XR packages compatible with 2022.3 LTS
- [ ] Test scene loads and runs in editor
- [ ] No console errors on project load

**Reference:** QUEST3_COMPATIBILITY_REVIEW.md - Issue #1

---

#### Issue #QUEST-2: Fix Package Identifier for Quest 3

**Labels:** `critical`, `android`, `quest3`, `P0`  
**Priority:** P0 - BLOCKING  
**Effort:** 15 minutes  
**Milestone:** v0.1.0 - Quest 3 Compatibility

**Problem:**
Current package identifier is `com.DefaultCompany.VRMultiplayer` which is a template default and doesn't match the beabodocl project.

**Current State:**
```
Android: com.DefaultCompany.VRMultiplayer
```

**Fix Required:**
```
Android: com.beabodocl.unity
```

**Steps:**
1. Unity → File → Build Settings → Player Settings
2. Navigate to Android tab
3. Other Settings → Identification
4. Change Package Name to: `com.beabodocl.unity`
5. Save project

**Acceptance Criteria:**
- [ ] Package name is `com.beabodocl.unity`
- [ ] Build Settings shows correct package name
- [ ] No build errors after change

**Reference:** QUEST3_COMPATIBILITY_REVIEW.md - Issue #2

---

#### Issue #QUEST-3: Change Graphics API to OpenGLES3

**Labels:** `critical`, `graphics`, `quest3`, `P0`  
**Priority:** P0 - BLOCKING  
**Effort:** 15 minutes  
**Milestone:** v0.1.0 - Quest 3 Compatibility

**Problem:**
Project is configured to use Vulkan graphics API. Quest 3 deployment guide recommends OpenGLES3 for initial testing and stability.

**Current State:**
- Graphics API: Vulkan (0x15000000)

**Fix Required:**
- Graphics API: OpenGLES3 only

**Steps:**
1. Unity → Player Settings → Android
2. Other Settings → Rendering
3. Graphics APIs: Remove "Vulkan"
4. Add "OpenGLES3" if not present
5. Uncheck "Auto Graphics API"
6. Move OpenGLES3 to top of list

**Acceptance Criteria:**
- [ ] Graphics APIs shows only "OpenGLES3"
- [ ] Auto Graphics API is disabled
- [ ] Test build completes successfully
- [ ] App runs on Quest 3 without graphics errors

**Reference:** QUEST3_COMPATIBILITY_REVIEW.md - Issue #3

---

#### Issue #QUEST-4: Verify ARM64-Only Configuration

**Labels:** `critical`, `android`, `quest3`, `P0`  
**Priority:** P0 - BLOCKING  
**Effort:** 10 minutes  
**Milestone:** v0.1.0 - Quest 3 Compatibility

**Problem:**
Quest 3 only supports 64-bit (ARM64) architecture. Need to verify ARMv7 is disabled and only ARM64 is selected.

**Verification Needed:**
- [ ] Only ARM64 is checked in Target Architectures
- [ ] ARMv7 is unchecked
- [ ] IL2CPP scripting backend is selected (already correct)

**Steps:**
1. Unity → Player Settings → Android
2. Other Settings → Configuration
3. Scripting Backend: Verify IL2CPP
4. Target Architectures: Check ONLY ARM64
5. Uncheck ARMv7 if present

**Acceptance Criteria:**
- [ ] Scripting Backend is IL2CPP
- [ ] Target Architectures shows only ARM64
- [ ] Build succeeds for ARM64
- [ ] APK runs on Quest 3

**Reference:** QUEST3_COMPATIBILITY_REVIEW.md - Issue #4

---

#### Issue #QUEST-5: Update Android Target SDK to API 33

**Labels:** `high-priority`, `android`, `quest3`, `P1`  
**Priority:** P1 - High  
**Effort:** 10 minutes  
**Milestone:** v0.1.0 - Quest 3 Compatibility

**Problem:**
Current target SDK is API 32 (Android 12). Quest 3 supports Android 13 (API 33) and targeting latest API provides better features and optimization.

**Current State:**
```
AndroidMinSdkVersion: 30
AndroidTargetSdkVersion: 32
```

**Recommended State:**
```
AndroidMinSdkVersion: 29
AndroidTargetSdkVersion: 33
```

**Steps:**
1. Unity → Player Settings → Android
2. Other Settings → Identification
3. Minimum API Level: 29 (Android 10.0)
4. Target API Level: 33 (Android 13.0)

**Acceptance Criteria:**
- [ ] Minimum API Level is 29
- [ ] Target API Level is 33
- [ ] Build completes successfully
- [ ] App installs and runs on Quest 3

**Reference:** QUEST3_COMPATIBILITY_REVIEW.md - Issue #5

---

#### Issue #QUEST-6: Verify Oculus XR Plugin Configuration

**Labels:** `critical`, `xr`, `quest3`, `P0`  
**Priority:** P0 - BLOCKING  
**Effort:** 15 minutes  
**Milestone:** v0.1.0 - Quest 3 Compatibility

**Problem:**
Need to verify that Oculus XR Plugin is properly enabled in XR Plug-in Management for Android platform.

**Verification Needed:**
1. XR Plug-in Management shows Oculus enabled for Android
2. Oculus XR Plugin settings are properly configured
3. Stereo rendering mode is set appropriately

**Steps:**
1. Unity → Edit → Project Settings
2. XR Plug-in Management
3. Select Android tab
4. Verify "Oculus" is checked ✅
5. Click on Oculus settings
6. Verify Stereo Rendering Mode (recommend: Multiview)

**Acceptance Criteria:**
- [ ] XR Plug-in Management shows Oculus enabled for Android
- [ ] Oculus XR Plugin settings accessible
- [ ] Stereo Rendering Mode configured
- [ ] VR mode activates on Quest 3

**Reference:** QUEST3_COMPATIBILITY_REVIEW.md - Issue #7

---

#### Issue #QUEST-7: Add Newtonsoft.Json Package

**Labels:** `critical`, `package`, `api`, `P0`  
**Priority:** P0 - BLOCKING  
**Effort:** 10 minutes  
**Milestone:** v0.2.0 - API Integration

**Problem:**
IMPLEMENTATION_PLAN.md specifies using Newtonsoft.Json for API serialization, but this package is not currently installed.

**Package Required:**
- com.unity.nuget.newtonsoft-json

**Steps:**
1. Unity → Window → Package Manager
2. Click "+" button
3. Select "Add package from git URL"
4. Enter: `com.unity.nuget.newtonsoft-json`
5. Click "Add"
6. Wait for package to install

**Acceptance Criteria:**
- [ ] Newtonsoft.Json package appears in Package Manager
- [ ] Can reference `using Newtonsoft.Json;` in scripts
- [ ] No compilation errors
- [ ] JSON serialization/deserialization works

**Reference:** QUEST3_COMPATIBILITY_REVIEW.md - Package Analysis

---

#### Issue #QUEST-8: Update Company Name

**Labels:** `high-priority`, `configuration`, `P1`  
**Priority:** P1 - High  
**Effort:** 5 minutes  
**Milestone:** v0.1.0 - Quest 3 Compatibility

**Problem:**
Company name is still set to "DefaultCompany" which is Unity's default placeholder.

**Current State:**
```
companyName: DefaultCompany
productName: beabodocl-unity
```

**Fix Required:**
```
companyName: Buddharauer
productName: Beabodocl Research Platform
```

**Steps:**
1. Unity → Player Settings → Company Name
2. Change to: "Buddharauer"
3. Product Name: "Beabodocl Research Platform"

**Acceptance Criteria:**
- [ ] Company Name updated
- [ ] Product Name updated
- [ ] Shows correctly in Quest 3 library

**Reference:** QUEST3_COMPATIBILITY_REVIEW.md - Issue #8

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
