# Beabodocl-Unity - Master Task List

**Date**: November 10, 2025  
**Project**: Unity VR Research Platform  
**Status**: Development Ready

---

## Overview

This document consolidates all tasks from across the project documentation into a single prioritized action list. Tasks are organized by priority, phase, and category.

---

## CRITICAL - Immediate Actions (Do First)

### Configuration Fixes (2-4 hours)

**Must complete before any development work**

- [ ] **TASK-001**: Verify Unity 2022.3 LTS migration complete
  - Priority: P0 - BLOCKING
  - Time: 30 min
  - Verify project opens in Unity 2022.3 LTS without errors
  - Check all packages resolved successfully
  - Issue: #QUEST-1

- [ ] **TASK-002**: Fix package identifier
  - Priority: P0 - BLOCKING
  - Time: 5 min
  - Change from `com.DefaultCompany.VRMultiplayer` to `com.beabodocl.unity`
  - Unity → Player Settings → Android → Package Name
  - Issue: #QUEST-2

- [ ] **TASK-003**: Change graphics API to OpenGLES3
  - Priority: P0 - BLOCKING
  - Time: 5 min
  - Remove Vulkan, add OpenGLES3
  - Unity → Player Settings → Android → Graphics APIs
  - Issue: #QUEST-3

- [ ] **TASK-004**: Verify ARM64-only configuration
  - Priority: P0 - BLOCKING
  - Time: 5 min
  - Ensure only ARM64 is checked (no ARMv7)
  - Unity → Player Settings → Android → Target Architectures
  - Issue: #QUEST-4

- [ ] **TASK-005**: Update Android SDK versions
  - Priority: P1 - HIGH
  - Time: 5 min
  - Minimum API: 29, Target API: 33
  - Unity → Player Settings → Android → Minimum/Target API Level
  - Issue: #QUEST-5

- [ ] **TASK-006**: Verify Oculus XR Plugin enabled
  - Priority: P0 - BLOCKING
  - Time: 5 min
  - Check Oculus enabled in XR Plug-in Management for Android
  - Unity → Edit → Project Settings → XR Plug-in Management
  - Issue: #QUEST-6

- [ ] **TASK-007**: Update company name
  - Priority: P2 - MEDIUM
  - Time: 2 min
  - Change from "DefaultCompany" to "Buddharauer"
  - Unity → Player Settings → Company Name
  - Issue: #QUEST-8

---

## Phase 1: Foundation & Infrastructure (4-6 weeks)

### Sprint 1.1: VR Environment Setup (Week 1, 12-16 hours)

**Room Asset Development**

- [ ] **TASK-101**: Design hexagonal room geometry
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - Choose approach: ProBuilder, Blender, or procedural
  - Create hexagonal floor and walls
  - 5.5m radius, 4m height
  - Issue: #ENV-001

- [ ] **TASK-102**: UV unwrap room geometry
  - Priority: P1 - HIGH
  - Time: 1-2 hours
  - Ensure seamless texture tiling
  - Optimize UV layout for performance
  - Issue: #ENV-002

- [ ] **TASK-103**: Generate/source background panel textures
  - Priority: P1 - HIGH
  - Time: 3-4 hours
  - Option 1: AI generation (Stable Diffusion prompts in UNITY_INTERFACE_DESIGN.md)
  - Option 2: Poly Haven or CC0 Textures
  - Create hybrid tech-organic textures (cyberpunk-solarpunk)
  - Issue: #ART-001

- [ ] **TASK-104**: Create PBR materials for room
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - URP Lit Shader
  - Albedo, Normal, Metallic, Roughness, AO maps
  - Apply to hexagonal room
  - Issue: #ART-002

- [ ] **TASK-105**: Set up XR Rig in scene
  - Priority: P0 - CRITICAL
  - Time: 1-2 hours
  - XR Origin with camera at 1.6m height
  - Left/Right controllers with XR Interaction Toolkit
  - Configure input actions
  - Issue: #VR-001

- [ ] **TASK-106**: Implement locomotion system
  - Priority: P0 - CRITICAL
  - Time: 2-3 hours
  - Teleportation Provider
  - Continuous Move Provider (optional)
  - Snap Turn Provider (45° turns)
  - Test comfort settings
  - Issue: #VR-002

- [ ] **TASK-107**: Configure lighting
  - Priority: P1 - HIGH
  - Time: 1-2 hours
  - Directional light (warm golden sun)
  - Ambient lighting from skybox
  - Corner fill lights (optional)
  - Bioluminescent accent lights (optional)
  - Issue: #ENV-003

- [ ] **TASK-108**: Create procedural skybox
  - Priority: P2 - MEDIUM
  - Time: 1 hour
  - Unity procedural sky or HDRI
  - Warm atmosphere (sunrise/sunset tones)
  - Issue: #ENV-004

### Sprint 1.2: Chat Panel Asset Development (Week 2, 10-14 hours)

**Chat Panel Assets**

- [ ] **TASK-201**: Create chat panel background mesh
  - Priority: P1 - HIGH
  - Time: 1 hour
  - Plane scaled to [5, 3.5, 1]
  - Position at front wall (0°, 1.6m height, 4.25m distance)
  - Issue: #UI-001

- [ ] **TASK-202**: Create chat panel background material
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - Generate/source textured surface (metal/wood hybrid)
  - PBR material with full texture maps
  - Apply cyberpunk-solarpunk aesthetic
  - Issue: #ART-003

- [ ] **TASK-203**: Create chat screen mesh and material
  - Priority: P1 - HIGH
  - Time: 1-2 hours
  - Plane scaled to [4, 3, 1], positioned 50cm in front of background
  - Transparent material (20% opacity)
  - Glass-like appearance with slight smoothness
  - Issue: #UI-002

- [ ] **TASK-204**: Create World Space Canvas on chat screen
  - Priority: P0 - CRITICAL
  - Time: 1 hour
  - Canvas render mode: World Space
  - Size: 400x300 units
  - Add CanvasScaler and GraphicRaycaster
  - Issue: #UI-003

- [ ] **TASK-205**: Design message bubble prefab
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - TextMeshPro with background
  - Rounded corners (solarpunk aesthetic)
  - User (blue) vs Agent (green) color variants
  - Timestamp and sender label
  - Issue: #UI-004

- [ ] **TASK-206**: Create chat input UI
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - TMP Input Field at bottom of canvas
  - Send button with VR interaction
  - Placeholder text styling
  - Issue: #UI-005

### Sprint 1.3: API Client Implementation (Week 3-4, 16-24 hours)

- [ ] **TASK-301**: Create API folder structure
  - Priority: P0 - CRITICAL
  - Time: 15 min
  - Assets/Scripts/API/, API/Models/, Config/
  - Issue: #API-001

- [ ] **TASK-302**: Implement ApiClient.cs base class
  - Priority: P0 - CRITICAL
  - Time: 4-6 hours
  - Singleton pattern
  - UnityWebRequest wrapper
  - GET and POST methods with async/await
  - Error handling with try-catch
  - See IMPLEMENTATION_PLAN.md Sprint 1.2
  - Issue: #1 (from GITHUB_ISSUES.md)

- [ ] **TASK-303**: Create data models
  - Priority: P0 - CRITICAL
  - Time: 2-3 hours
  - ChatMessage, ChatRequest, ChatResponse
  - Document, SearchResult
  - Serializable classes
  - Issue: #API-002

- [ ] **TASK-304**: Implement AgentApi.cs
  - Priority: P0 - CRITICAL
  - Time: 3-4 hours
  - SendMessage method
  - GetHistory method
  - DeleteConversation method
  - Issue: #API-003

- [ ] **TASK-305**: Create ApiConfig ScriptableObject
  - Priority: P0 - CRITICAL
  - Time: 1-2 hours
  - Base URL, timeout, retry settings
  - Create asset: Assets/Config/ApiConfig.asset
  - Issue: #API-004

- [ ] **TASK-306**: Test API integration
  - Priority: P0 - CRITICAL
  - Time: 3-4 hours
  - Create test scene
  - Test GET /api/v1/documents
  - Test POST /api/v1/agent/chat
  - Verify JSON serialization
  - Issue: #API-005

### Sprint 1.4: Error Handling & Loading (Week 4, 12-18 hours)

- [ ] **TASK-401**: Implement ErrorManager singleton
  - Priority: P0 - CRITICAL
  - Time: 3-4 hours
  - Centralized error logging and display
  - ShowError, ShowNetworkError methods
  - Issue: #3 (from GITHUB_ISSUES.md)

- [ ] **TASK-402**: Create ErrorPanel UI
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - World Space canvas for VR
  - Error message display
  - Retry button
  - Close button
  - Issue: #UI-006

- [ ] **TASK-403**: Implement LoadingOverlay
  - Priority: P1 - HIGH
  - Time: 3-4 hours
  - World Space overlay canvas
  - Spinner animation or progress bar
  - Status text (TMP)
  - Show/Hide methods
  - Issue: #5 (from GITHUB_ISSUES.md)

- [ ] **TASK-404**: Add try-catch to all API calls
  - Priority: P0 - CRITICAL
  - Time: 2-3 hours
  - Wrap ApiClient methods
  - Display errors via ErrorManager
  - Show loading states
  - Issue: #API-006

- [ ] **TASK-405**: Create toast notification system
  - Priority: P2 - MEDIUM
  - Time: 2-4 hours
  - Brief messages for non-critical feedback
  - Auto-dismiss after 3-5 seconds
  - Issue: #UI-007

---

## Phase 2: Core VR Features (6-8 weeks)

### Sprint 2.1: Chat Interface Implementation (Week 5-6, 14-20 hours)

- [ ] **TASK-501**: Implement ChatPanel3D.cs
  - Priority: P0 - CRITICAL
  - Time: 6-8 hours
  - Message container with vertical layout
  - Add/remove message bubbles
  - Send message to AgentApi
  - Display agent responses
  - See IMPLEMENTATION_PLAN.md Sprint 2.1
  - Issue: #UI-008

- [ ] **TASK-502**: Integrate VR keyboard
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - Unity's XR keyboard overlay
  - Or third-party VR keyboard
  - Connect to input field
  - Issue: #VR-003

- [ ] **TASK-503**: Add chat history scrolling
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - Scroll view with scrollbar
  - Auto-scroll to newest message
  - Issue: #UI-009

- [ ] **TASK-504**: Implement source citations display
  - Priority: P2 - MEDIUM
  - Time: 2-3 hours
  - Parse ChatResponse.sources
  - Display as separate message or inline
  - Clickable to open document
  - Issue: #UI-010

- [ ] **TASK-505**: Add voice input (optional)
  - Priority: P3 - LOW
  - Time: 8-10 hours
  - Windows Speech Recognition or Azure
  - Speech-to-text
  - Microphone button on chat panel
  - Issue: #15 (from GITHUB_ISSUES.md)

### Sprint 2.2: Document Panel Assets (Week 7, 10-12 hours)

- [ ] **TASK-601**: Create document panel background
  - Priority: P1 - HIGH
  - Time: 1 hour
  - Position at 120° from chat panel
  - Same layered design (background + screen)
  - Issue: #UI-011

- [ ] **TASK-602**: Create document panel materials
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - Generate/source textures for background
  - Transparent screen material
  - Maintain visual consistency with chat panel
  - Issue: #ART-004

- [ ] **TASK-603**: Design document card prefab
  - Priority: P1 - HIGH
  - Time: 3-4 hours
  - Title, authors, year, abstract display
  - Hover highlight effect
  - Select to open full document
  - Issue: #UI-012

- [ ] **TASK-604**: Create document viewer UI
  - Priority: P1 - HIGH
  - Time: 4-5 hours
  - Full-screen document reader
  - Page navigation
  - Zoom/pan controls (optional)
  - Close button
  - Issue: #6 (from GITHUB_ISSUES.md)

### Sprint 2.3: Document Visualization (Week 8-9, 14-18 hours)

- [ ] **TASK-701**: Implement DocumentCard3D.cs
  - Priority: P1 - HIGH
  - Time: 4-6 hours
  - Initialize with Document data
  - XRSimpleInteractable for VR interaction
  - Hover and select events
  - See IMPLEMENTATION_PLAN.md Sprint 2.3
  - Issue: #UI-013

- [ ] **TASK-702**: Implement DocumentGrid.cs
  - Priority: P1 - HIGH
  - Time: 6-8 hours
  - Grid, Arc, and Timeline layouts
  - Position calculation algorithms
  - Switch between layouts
  - Issue: #UI-014

- [ ] **TASK-703**: Implement DocumentViewer.cs
  - Priority: P1 - HIGH
  - Time: 4-4 hours
  - Display full document content
  - Scrolling and navigation
  - Close and back functionality
  - Issue: #UI-015

### Sprint 2.4: Search Panel Assets (Week 10, 8-10 hours)

- [ ] **TASK-801**: Create search panel background and screen
  - Priority: P1 - HIGH
  - Time: 1 hour
  - Position at 240° from chat panel
  - Same layered design
  - Issue: #UI-016

- [ ] **TASK-802**: Create search panel materials
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - Generate/source background textures
  - Transparent screen material
  - Issue: #ART-005

- [ ] **TASK-803**: Design search input UI
  - Priority: P1 - HIGH
  - Time: 2-3 hours
  - Search field with VR keyboard
  - Filter options
  - Search button
  - Issue: #4 (from GITHUB_ISSUES.md)

- [ ] **TASK-804**: Implement search results display
  - Priority: P1 - HIGH
  - Time: 3-4 hours
  - Grid of document cards
  - Sort and filter controls
  - Connect to DocumentApi
  - Issue: #UI-017

---

## Phase 3: Advanced Features (8-12 weeks)

### Data Visualization (Weeks 11-13, 28-38 hours)

- [ ] **TASK-901**: Implement keyword trends visualization
  - Priority: P2 - MEDIUM
  - Time: 12-16 hours
  - Custom mesh generation or Unity UI Toolkit
  - 3D bar chart or line chart
  - Interactive data exploration
  - Issue: #11 (from GITHUB_ISSUES.md)

- [ ] **TASK-902**: Create word cloud visualization
  - Priority: P2 - MEDIUM
  - Time: 8-10 hours
  - Generate word cloud texture from document keywords
  - Display on 3D plane
  - Interactive word selection
  - Issue: #UI-018

- [ ] **TASK-903**: Add data export functionality
  - Priority: P3 - LOW
  - Time: 8-12 hours
  - Export search results to CSV
  - Save visualizations as images
  - Issue: #UI-019

### Materials & Visual Polish (Weeks 14-15, 16-24 hours)

- [ ] **TASK-1001**: Create living wall assets (optional)
  - Priority: P3 - LOW
  - Time: 6-8 hours
  - Vertical garden meshes or textured planes
  - Position between panels
  - Bioluminescent plant materials with emission
  - Issue: #ART-006

- [ ] **TASK-1002**: Implement post-processing effects
  - Priority: P2 - MEDIUM
  - Time: 3-4 hours
  - Bloom for holographic glow
  - Color grading (cyberpunk tint)
  - Vignette for VR comfort
  - Issue: #ENV-005

- [ ] **TASK-1003**: Add particle systems
  - Priority: P3 - LOW
  - Time: 4-6 hours
  - Floating organic particles (pollen)
  - Bioluminescent light motes
  - Subtle ambient animation
  - Issue: #ART-007

- [ ] **TASK-1004**: Create wood/bamboo trim materials
  - Priority: P3 - LOW
  - Time: 3-6 hours
  - Panel frame decorations
  - Solarpunk organic accents
  - Issue: #ART-008

### VR Optimization (Weeks 16-17, 14-20 hours)

- [ ] **TASK-1101**: Implement LOD groups
  - Priority: P2 - MEDIUM
  - Time: 4-6 hours
  - LOD for document cards
  - Automatic detail reduction
  - Issue: #13 (from GITHUB_ISSUES.md)

- [ ] **TASK-1102**: Enable GPU instancing
  - Priority: P2 - MEDIUM
  - Time: 2-3 hours
  - Batch repeated materials
  - Reduce draw calls
  - Issue: #VR-004

- [ ] **TASK-1103**: Bake lighting
  - Priority: P2 - MEDIUM
  - Time: 3-4 hours
  - Mark static objects
  - Bake lightmaps
  - Use baked reflection probes
  - Issue: #ENV-006

- [ ] **TASK-1104**: Implement object pooling
  - Priority: P2 - MEDIUM
  - Time: 3-5 hours
  - Pool message bubbles
  - Pool document cards
  - Reduce instantiation overhead
  - Issue: #VR-005

- [ ] **TASK-1105**: Profile and optimize
  - Priority: P1 - HIGH
  - Time: 2-2 hours
  - Unity Profiler analysis
  - Target 90 FPS Quest 2, 120 FPS Quest 3
  - Reduce draw calls to <100
  - Issue: #VR-006

### DICOM Imaging (Weeks 18-22, 40-60 hours) - Optional

- [ ] **TASK-1201**: Install fo-dicom library
  - Priority: P3 - LOW
  - Time: 2-3 hours
  - NuGet package integration
  - Test DICOM file parsing
  - Issue: #12 (from GITHUB_ISSUES.md)

- [ ] **TASK-1202**: Implement 2D slice viewer
  - Priority: P3 - LOW
  - Time: 12-16 hours
  - Display DICOM slices on screen
  - Windowing/leveling controls
  - Slice navigation
  - Issue: #UI-020

- [ ] **TASK-1203**: Implement 3D volume rendering
  - Priority: P3 - LOW
  - Time: 26-41 hours
  - Compute shader for volume rendering
  - Transfer function editor
  - VR-optimized rendering
  - Issue: #UI-021

---

## Phase 4: Testing & Polish (4-6 weeks)

### Testing (Weeks 23-24, 20-30 hours)

- [ ] **TASK-1301**: Create unit tests
  - Priority: P1 - HIGH
  - Time: 8-12 hours
  - Test data model serialization
  - Test API client methods (mocked)
  - Test utility functions
  - Issue: #TEST-001

- [ ] **TASK-1302**: Create integration tests
  - Priority: P1 - HIGH
  - Time: 8-12 hours
  - Test API integration with live backend
  - Test VR interactions
  - Test scene loading
  - Issue: #TEST-002

- [ ] **TASK-1303**: Performance testing
  - Priority: P1 - HIGH
  - Time: 4-6 hours
  - Quest 2: 90 FPS validation
  - Quest 3: 120 FPS validation
  - Memory profiling (<1GB)
  - Issue: #TEST-003

### Documentation & Polish (Weeks 25-26, 20-30 hours)

- [ ] **TASK-1401**: Write user documentation
  - Priority: P2 - MEDIUM
  - Time: 8-12 hours
  - User guide for VR interface
  - Tutorial for basic workflows
  - Troubleshooting common issues
  - Issue: #DOC-001

- [ ] **TASK-1402**: Create video tutorials
  - Priority: P3 - LOW
  - Time: 8-12 hours
  - Screen recordings of features
  - Voiceover explanations
  - Upload to YouTube or embed
  - Issue: #DOC-002

- [ ] **TASK-1403**: API documentation
  - Priority: P2 - MEDIUM
  - Time: 4-6 hours
  - Document public classes and methods
  - XML comments for IntelliSense
  - Generate API reference
  - Issue: #DOC-003

### Deployment (Weeks 27-28, 12-16 hours)

- [ ] **TASK-1501**: Set up build pipeline
  - Priority: P2 - MEDIUM
  - Time: 4-6 hours
  - Automated builds for Android (Quest)
  - Automated builds for Windows (PC VR)
  - Version management
  - Issue: #BUILD-001

- [ ] **TASK-1502**: Quest store submission preparation
  - Priority: P2 - MEDIUM
  - Time: 4-6 hours
  - Create store listing assets
  - Screenshots and promotional images
  - Privacy policy and terms
  - Issue: #BUILD-002

- [ ] **TASK-1503**: SteamVR distribution setup
  - Priority: P3 - LOW
  - Time: 4-4 hours
  - Steam store page
  - Build packaging
  - Submit for review
  - Issue: #BUILD-003

---

## Summary by Priority

### P0 - CRITICAL (Must Complete)
- All Quest 3 configuration fixes (TASK-001 to TASK-006)
- XR Rig setup (TASK-105)
- Locomotion system (TASK-106)
- API client implementation (TASK-302 to TASK-306)
- Error handling (TASK-401, TASK-404)
- Chat panel implementation (TASK-501)

**Total P0 Tasks**: 16

### P1 - HIGH (Core Features)
- All asset creation tasks (room, panels, materials)
- Document visualization
- Search functionality
- Testing and optimization
- User documentation

**Total P1 Tasks**: 38

### P2 - MEDIUM (Polish & Enhancement)
- Data visualization
- Post-processing effects
- Performance optimization
- Build pipeline
- Advanced UI features

**Total P2 Tasks**: 18

### P3 - LOW (Nice-to-Have)
- Voice input
- DICOM imaging
- Living wall assets
- Particle effects
- Video tutorials
- SteamVR distribution

**Total P3 Tasks**: 13

**TOTAL TASKS**: 85

---

## Estimated Timeline

### Solo Developer
- **Phase 1**: 8-10 weeks
- **Phase 2**: 10-12 weeks
- **Phase 3**: 12-16 weeks (selective features)
- **Phase 4**: 6-8 weeks
- **Total**: 36-46 weeks (~8-11 months)

### Two Developers
- **Phase 1**: 4-5 weeks
- **Phase 2**: 6-8 weeks
- **Phase 3**: 8-12 weeks
- **Phase 4**: 4-6 weeks
- **Total**: 22-31 weeks (~5-7 months)

### Small Team (3+)
- **Phase 1**: 3-4 weeks
- **Phase 2**: 4-6 weeks
- **Phase 3**: 6-8 weeks
- **Phase 4**: 3-4 weeks
- **Total**: 16-22 weeks (~4-5 months)

---

## Next Actions

### This Week
1. Complete all P0 Quest 3 configuration tasks (TASK-001 to TASK-007)
2. Verify project builds and runs on Quest 3
3. Begin room asset creation (TASK-101)

### Month 1 Goal
- Complete Phase 1 (Foundation)
- Working VR scene with chat panel
- API integration functional
- Basic VR navigation tested

---

**Document Status**: Complete  
**Last Updated**: November 10, 2025  
**Total Tasks**: 85  
**See Also**: GITHUB_ISSUES.md, IMPLEMENTATION_PLAN.md, UNITY_INTERFACE_DESIGN.md
