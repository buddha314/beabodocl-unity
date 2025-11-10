# GitHub Issues - Complete List

**Project**: beabodocl-unity  
**Date Created**: November 10, 2025  
**Total Issues**: 85+  
**Status**: Ready for GitHub Issue Creation

---

## How to Use This Document

Each section below represents a GitHub issue. To create issues:

1. Copy the markdown for each issue
2. Go to GitHub repository → Issues → New Issue
3. Paste the content
4. Add labels as specified
5. Assign to milestone
6. Create the issue

---

## Quest 3 Configuration Issues (P0 - CRITICAL)

### Issue #QUEST-1: Verify Unity 2022.3 LTS Migration

```markdown
**Priority**: P0 - BLOCKING  
**Labels**: `critical`, `configuration`, `quest3`  
**Milestone**: v0.1.0 - Quest 3 Compatibility  
**Effort**: 30 minutes

**Description**:
Verify that the project has been successfully migrated from Unity 6 to Unity 2022.3 LTS.

**Current State**:
- Project was originally on Unity 6 (6000.2.10f1)
- Migration to Unity 2022.3 LTS documented in HANDOFF_2025-11-10_UNITY_2022_MIGRATION.md

**Tasks**:
- [ ] Open project in Unity 2022.3 LTS
- [ ] Verify no compilation errors in Console
- [ ] Check all packages resolved successfully
- [ ] Test basic scene loads and runs
- [ ] Confirm XR packages compatible with 2022.3 LTS

**Acceptance Criteria**:
- [ ] Project opens in Unity 2022.3 LTS without errors
- [ ] Zero console errors on project load
- [ ] All packages show as resolved in Package Manager
- [ ] Test scene can enter Play mode

**Reference**:
- QUEST3_COMPATIBILITY_REVIEW.md - Issue #1
- HANDOFF_2025-11-10_UNITY_2022_MIGRATION.md
```

### Issue #QUEST-2: Fix Package Identifier for Quest 3

```markdown
**Priority**: P0 - BLOCKING  
**Labels**: `critical`, `android`, `quest3`  
**Milestone**: v0.1.0 - Quest 3 Compatibility  
**Effort**: 5 minutes

**Description**:
Change package identifier from Unity template default to project-specific identifier.

**Current State**:
```
Package Name: com.DefaultCompany.VRMultiplayer
```

**Required State**:
```
Package Name: com.beabodocl.unity
```

**Steps**:
1. Open Unity Editor
2. File → Build Settings → Player Settings
3. Navigate to Android tab
4. Other Settings → Identification section
5. Change Package Name to: `com.beabodocl.unity`
6. Save project

**Acceptance Criteria**:
- [ ] Package name is `com.beabodocl.unity`
- [ ] Build Settings shows correct package name
- [ ] No build errors after change
- [ ] APK builds successfully with new identifier

**Reference**:
- QUEST3_COMPATIBILITY_REVIEW.md - Issue #2
```

### Issue #QUEST-3: Change Graphics API to OpenGLES3

```markdown
**Priority**: P0 - BLOCKING  
**Labels**: `critical`, `graphics`, `quest3`  
**Milestone**: v0.1.0 - Quest 3 Compatibility  
**Effort**: 5 minutes

**Description**:
Change graphics API from Vulkan to OpenGLES3 for Quest 3 stability.

**Current State**:
- Graphics API: Vulkan

**Required State**:
- Graphics API: OpenGLES3 only

**Steps**:
1. Unity → Player Settings → Android
2. Other Settings → Rendering section
3. Graphics APIs: Remove "Vulkan"
4. Add "OpenGLES3" if not present
5. Uncheck "Auto Graphics API"
6. Move OpenGLES3 to top of list

**Acceptance Criteria**:
- [ ] Graphics APIs shows only "OpenGLES3"
- [ ] Auto Graphics API is disabled
- [ ] Test build completes successfully
- [ ] App runs on Quest 3 without graphics errors

**Reference**:
- QUEST3_COMPATIBILITY_REVIEW.md - Issue #3
- Meta Quest deployment guide
```

### Issue #QUEST-4: Verify ARM64-Only Configuration

```markdown
**Priority**: P0 - BLOCKING  
**Labels**: `critical`, `android`, `quest3`  
**Milestone**: v0.1.0 - Quest 3 Compatibility  
**Effort**: 5 minutes

**Description**:
Ensure only ARM64 architecture is selected (Quest 3 is 64-bit only).

**Verification Needed**:
- [ ] Only ARM64 is checked in Target Architectures
- [ ] ARMv7 is unchecked
- [ ] IL2CPP scripting backend is selected

**Steps**:
1. Unity → Player Settings → Android
2. Other Settings → Configuration section
3. Scripting Backend: Verify IL2CPP
4. Target Architectures: Check ONLY ARM64
5. Uncheck ARMv7 if present

**Acceptance Criteria**:
- [ ] Scripting Backend is IL2CPP
- [ ] Target Architectures shows only ARM64
- [ ] Build succeeds for ARM64
- [ ] APK runs on Quest 3

**Reference**:
- QUEST3_COMPATIBILITY_REVIEW.md - Issue #4
```

### Issue #QUEST-5: Update Android Target SDK to API 33

```markdown
**Priority**: P1 - HIGH  
**Labels**: `high-priority`, `android`, `quest3`  
**Milestone**: v0.1.0 - Quest 3 Compatibility  
**Effort**: 5 minutes

**Description**:
Update Android SDK versions to support Quest 3 features and optimization.

**Current State**:
```
Minimum API Level: 30 (Android 10)
Target API Level: 32 (Android 12)
```

**Recommended State**:
```
Minimum API Level: 29 (Android 10.0)
Target API Level: 33 (Android 13.0)
```

**Steps**:
1. Unity → Player Settings → Android
2. Other Settings → Identification section
3. Minimum API Level: 29 (Android 10.0)
4. Target API Level: 33 (Android 13.0)
5. Save project

**Acceptance Criteria**:
- [ ] Minimum API Level is 29
- [ ] Target API Level is 33
- [ ] Build completes successfully
- [ ] App installs and runs on Quest 3

**Reference**:
- QUEST3_COMPATIBILITY_REVIEW.md - Issue #5
```

### Issue #QUEST-6: Verify Oculus XR Plugin Configuration

```markdown
**Priority**: P0 - BLOCKING  
**Labels**: `critical`, `xr`, `quest3`  
**Milestone**: v0.1.0 - Quest 3 Compatibility  
**Effort**: 5 minutes

**Description**:
Verify Oculus XR Plugin is properly enabled for Android platform.

**Verification Needed**:
1. XR Plug-in Management shows Oculus enabled for Android
2. Oculus XR Plugin settings are configured
3. Stereo rendering mode set appropriately

**Steps**:
1. Unity → Edit → Project Settings
2. XR Plug-in Management
3. Select Android tab
4. Verify "Oculus" is checked ✅
5. Click on Oculus settings
6. Verify Stereo Rendering Mode (recommend: Multiview)

**Acceptance Criteria**:
- [ ] XR Plug-in Management shows Oculus enabled for Android
- [ ] Oculus XR Plugin settings accessible
- [ ] Stereo Rendering Mode configured
- [ ] VR mode activates on Quest 3

**Reference**:
- QUEST3_COMPATIBILITY_REVIEW.md - Issue #7
```

### Issue #QUEST-7: Update Company Name

```markdown
**Priority**: P2 - MEDIUM  
**Labels**: `configuration`, `metadata`  
**Milestone**: v0.1.0 - Quest 3 Compatibility  
**Effort**: 2 minutes

**Description**:
Change company name from Unity default to actual organization.

**Current State**:
```
Company Name: DefaultCompany
Product Name: beabodocl-unity
```

**Required State**:
```
Company Name: Buddharauer
Product Name: Beabodocl Research Platform
```

**Steps**:
1. Unity → Player Settings → Company Name
2. Change to: "Buddharauer"
3. Product Name: "Beabodocl Research Platform"
4. Save project

**Acceptance Criteria**:
- [ ] Company Name is "Buddharauer"
- [ ] Product Name is "Beabodocl Research Platform"
- [ ] Shows correctly in Quest 3 library
```

---

## Phase 1: Environment & Room Assets

### Issue #ENV-001: Design and Create Hexagonal Room Geometry

```markdown
**Priority**: P1 - HIGH  
**Labels**: `environment`, `3d-asset`, `room`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 2-3 hours

**Description**:
Create the hexagonal room geometry that serves as the primary VR workspace.

**Specifications** (from UNITY_INTERFACE_DESIGN.md):
- Room Type: Hexagonal (6 walls)
- Radius: 5.5 meters from center to wall
- Height: 4 meters
- Floor: Hexagonal mesh or large plane

**Approach Options**:
1. **ProBuilder** (Unity tool) - Quick, in-engine modeling
2. **Blender** - Professional 3D modeling, export as FBX
3. **Procedural** - Generate via C# script

**Tasks**:
- [ ] Choose approach (ProBuilder recommended for iteration)
- [ ] Model hexagonal walls (6 separate or single mesh)
- [ ] Create hexagonal floor plane
- [ ] Optional: Create ceiling with skylight opening
- [ ] Position geometry at world origin
- [ ] Verify scale (5.5m radius, 4m height)

**Acceptance Criteria**:
- [ ] Hexagonal room geometry exists in scene
- [ ] Correct dimensions verified
- [ ] Clean topology for UV unwrapping
- [ ] All faces have correct normals (facing inward)
- [ ] Ready for UV unwrapping

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Section "Hexagonal Room Geometry"
- PROJECT_TASKS.md - TASK-101
```

### Issue #ENV-002: UV Unwrap Room Geometry

```markdown
**Priority**: P1 - HIGH  
**Labels**: `environment`, `3d-asset`, `texturing`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 1-2 hours

**Description**:
UV unwrap the hexagonal room geometry for seamless texture tiling.

**Requirements**:
- Seamless texture tiling on walls and floor
- Optimized UV layout for texture resolution
- Consistent texel density across surfaces
- No stretching or distortion

**Tasks**:
- [ ] UV unwrap walls for seamless horizontal tiling
- [ ] UV unwrap floor (hexagonal pattern or radial)
- [ ] UV unwrap ceiling (if present)
- [ ] Optimize UV islands for minimal waste
- [ ] Test with checker texture to verify no stretching

**Acceptance Criteria**:
- [ ] All surfaces have clean UV unwrapping
- [ ] Checker texture shows no distortion
- [ ] Seams are hidden or minimized
- [ ] Ready for texture application

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Asset Generation section
- PROJECT_TASKS.md - TASK-102
```

### Issue #ENV-003: Configure Scene Lighting

```markdown
**Priority**: P1 - HIGH  
**Labels**: `environment`, `lighting`, `vr`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 1-2 hours

**Description**:
Set up warm, optimistic lighting scheme for the VR environment.

**Lighting Setup** (from UNITY_INTERFACE_DESIGN.md):

**Directional Light (Sun)**:
- Color: Warm white (#FFF4E6)
- Intensity: 0.8-1.0
- Rotation: Low angle (morning/evening light)
- Shadows: Soft shadows enabled

**Ambient Lighting**:
- Source: Skybox
- Intensity: 0.8
- Ambient Mode: Realtime or Baked

**Optional Enhancements**:
- Corner fill lights (Point Lights, warm, low intensity)
- Bioluminescent accent lights (cyan-green, emission only)
- Ceiling skylight effect (Area Light)

**Tasks**:
- [ ] Create Directional Light with warm color
- [ ] Configure shadow settings
- [ ] Set ambient lighting from skybox
- [ ] Add reflection probe at room center
- [ ] Add corner lights (optional)
- [ ] Test lighting in VR headset

**Acceptance Criteria**:
- [ ] Warm, inviting atmosphere achieved
- [ ] Soft shadows without harsh contrast
- [ ] Bioluminescent accents (if added) provide subtle glow
- [ ] Lighting optimized for VR performance

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Section "Lighting & Environment"
- PROJECT_TASKS.md - TASK-107
```

### Issue #ENV-004: Create Procedural Skybox

```markdown
**Priority**: P2 - MEDIUM  
**Labels**: `environment`, `skybox`, `vr`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 1 hour

**Description**:
Create or configure skybox with warm, optimistic atmosphere.

**Options**:
1. Unity Procedural Sky
2. HDRI from Poly Haven
3. Custom gradient skybox

**Specifications**:
- Warm atmosphere (sunrise/sunset feel)
- Soft blue-purple gradient
- Sun with golden tone
- Not too bright (VR comfort)

**Tasks**:
- [ ] Choose skybox approach
- [ ] Configure or import skybox
- [ ] Set sun color and intensity
- [ ] Adjust atmosphere thickness/tint
- [ ] Test appearance in VR

**Acceptance Criteria**:
- [ ] Skybox provides pleasant background
- [ ] Colors match cyberpunk-solarpunk aesthetic
- [ ] Not distracting in VR
- [ ] Supports ambient lighting

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Environment Setup
- PROJECT_TASKS.md - TASK-108
```

### Issue #ENV-005: Implement Post-Processing Effects

```markdown
**Priority**: P2 - MEDIUM  
**Labels**: `environment`, `graphics`, `vr`, `post-processing`  
**Milestone**: v0.3.0 - Visual Polish  
**Effort**: 3-4 hours

**Description**:
Add post-processing effects for holographic appearance and VR comfort.

**Effects** (from UNITY_INTERFACE_DESIGN.md):

**1. Bloom** (Holographic Glow):
- Intensity: 0.3
- Threshold: 0.8 (only bright elements glow)
- Scatter: 0.7

**2. Color Grading** (Cyberpunk Tint):
- Temperature: +10 (slight warm tint)
- Tint: -5 (slight cyan-purple)

**3. Vignette** (VR Comfort):
- Intensity: 0.2 (subtle edge darkening)
- Smoothness: 0.4

**Tasks**:
- [ ] Add Post Process Volume to camera
- [ ] Create Post Process Profile
- [ ] Configure Bloom effect
- [ ] Configure Color Grading
- [ ] Add Vignette effect
- [ ] Test in VR for comfort
- [ ] Optimize for Quest performance

**Acceptance Criteria**:
- [ ] Holographic UI elements have subtle glow
- [ ] Color grading adds cyberpunk atmosphere
- [ ] Vignette aids VR comfort
- [ ] No performance impact (<5 FPS drop)

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Holographic Effects section
- PROJECT_TASKS.md - TASK-1002
```

### Issue #ENV-006: Bake Lighting for Performance

```markdown
**Priority**: P2 - MEDIUM  
**Labels**: `environment`, `optimization`, `performance`  
**Milestone**: v0.4.0 - Optimization  
**Effort**: 3-4 hours

**Description**:
Bake static lighting to improve VR performance.

**Benefits**:
- Reduced runtime lighting calculations
- Better frame rates on Quest
- Realistic shadows without performance cost

**Tasks**:
- [ ] Mark room geometry as Static
- [ ] Mark panel backgrounds as Static
- [ ] Configure Lighting Settings
- [ ] Set lightmap resolution
- [ ] Bake lightmaps (Window → Rendering → Lighting)
- [ ] Review lightmap quality
- [ ] Optimize lightmap size if needed
- [ ] Test performance improvement

**Acceptance Criteria**:
- [ ] Lightmaps baked successfully
- [ ] Static objects use baked lighting
- [ ] Frame rate improved (measure before/after)
- [ ] Visual quality maintained or improved
- [ ] Lightmap size reasonable (<50 MB)

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Performance Optimization
- PROJECT_TASKS.md - TASK-1103
```

---

## Phase 1: Art & Materials

### Issue #ART-001: Generate/Source Background Panel Textures

```markdown
**Priority**: P1 - HIGH  
**Labels**: `art`, `materials`, `textures`, `ai-generation`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 3-4 hours

**Description**:
Create or source PBR textures for panel backgrounds with hybrid tech-organic aesthetic.

**Options**:
1. **AI Generation** - Use Stable Diffusion with prompts from UNITY_INTERFACE_DESIGN.md
2. **Free Libraries** - Poly Haven, ambientCG, CC0 Textures
3. **Hybrid** - AI base + manual editing

**Textures Needed**:
- Chat panel background
- Document panel background
- Search panel background
- Optional: Room wall texture

**AI Prompts** (from UNITY_INTERFACE_DESIGN.md):

**Hybrid Tech-Organic** (Recommended):
```
Positive: "industrial metal panel with organic moss growing in crevices, sustainable 
solarpunk cyberpunk fusion, reclaimed materials, nature reclaiming technology, green 
living plants on dark metal, seamless tileable PBR texture, 4K resolution, photorealistic, 
hopeful futurism"

Negative: "people, faces, text, watermark, pure synthetic, dystopian dark, death decay"

Settings: 1024x1024, CFG 7-9, Steps 35-45
```

**Tasks**:
- [ ] Choose texture generation method
- [ ] Generate/download base albedo textures (3-4 variants)
- [ ] Generate/download normal maps
- [ ] Generate/download roughness maps
- [ ] Generate/download metallic maps
- [ ] Generate/download AO maps (if needed)
- [ ] Ensure seamless tiling
- [ ] Test textures on plane in Unity

**Acceptance Criteria**:
- [ ] At least 3 high-quality PBR texture sets (1024x1024 or 2048x2048)
- [ ] All textures seamlessly tileable
- [ ] Matches cyberpunk-solarpunk aesthetic
- [ ] Albedo, Normal, Roughness, Metallic maps present
- [ ] Tested in Unity and looks good

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Asset Generation & Materials
- PROJECT_TASKS.md - TASK-103
```

### Issue #ART-002: Create PBR Materials for Room

```markdown
**Priority**: P1 - HIGH  
**Labels**: `art`, `materials`, `pbr`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 2-3 hours

**Description**:
Create PBR materials for room geometry using URP Lit Shader.

**Materials Needed**:
1. Room wall material
2. Floor material
3. Ceiling material (if present)

**PBR Setup**:
- Shader: Universal Render Pipeline/Lit
- Albedo map
- Normal map
- Metallic map
- Smoothness/Roughness
- Ambient Occlusion

**Tasks**:
- [ ] Import textures to Unity
- [ ] Create Material assets
- [ ] Assign URP Lit Shader
- [ ] Configure texture maps
- [ ] Adjust tiling and offset
- [ ] Set metallic/smoothness values
- [ ] Enable GPU instancing
- [ ] Apply to room geometry
- [ ] Test lighting response

**Acceptance Criteria**:
- [ ] Materials respond realistically to lighting
- [ ] Textures tile seamlessly
- [ ] No visible seams or artifacts
- [ ] Performance acceptable in VR

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Material Strategy
- PROJECT_TASKS.md - TASK-104
```

### Issue #ART-003: Create Chat Panel Background Material

```markdown
**Priority**: P1 - HIGH  
**Labels**: `art`, `materials`, `ui`, `chat`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 2-3 hours

**Description**:
Create textured PBR material for chat panel background mesh.

**Requirements**:
- Opaque material (100% alpha)
- Textured surface (metal/wood hybrid)
- PBR workflow with full texture maps
- Matches cyberpunk-solarpunk aesthetic

**Tasks**:
- [ ] Select texture from ART-001 or generate new
- [ ] Import texture maps to Unity
- [ ] Create Material asset
- [ ] Assign URP Lit Shader
- [ ] Configure all PBR maps
- [ ] Adjust material properties (metallic, smoothness)
- [ ] Test on chat panel background mesh
- [ ] Verify appearance in VR

**Acceptance Criteria**:
- [ ] Material looks good on chat background plane
- [ ] Matches design aesthetic
- [ ] Provides good contrast for transparent screen
- [ ] Performance acceptable

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Panel Background Materials
- PROJECT_TASKS.md - TASK-202
```

### Issue #ART-004: Create Document Panel Materials

```markdown
**Priority**: P1 - HIGH  
**Labels**: `art`, `materials`, `ui`, `document`  
**Milestone**: v0.3.0 - Core Features  
**Effort**: 2-3 hours

**Description**:
Create materials for document panel (background + screen).

**Materials Needed**:
1. Document background (opaque, textured)
2. Document screen (transparent, glass-like)

**Tasks**:
- [ ] Create document background material
- [ ] Use texture from ART-001 or generate variant
- [ ] Configure PBR properties
- [ ] Create transparent screen material
- [ ] Set alpha to 20% opacity
- [ ] Configure glass-like smoothness
- [ ] Apply to document panel meshes
- [ ] Test visual consistency with chat panel

**Acceptance Criteria**:
- [ ] Background material matches chat panel aesthetic
- [ ] Screen material is transparent and readable
- [ ] Visual hierarchy clear (screen in front of background)
- [ ] Maintains design consistency

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Visual Design Principles
- PROJECT_TASKS.md - TASK-602
```

### Issue #ART-005: Create Search Panel Materials

```markdown
**Priority**: P1 - HIGH  
**Labels**: `art`, `materials`, `ui`, `search`  
**Milestone**: v0.3.0 - Core Features  
**Effort**: 2-3 hours

**Description**:
Create materials for search panel (background + screen).

**Requirements**:
- Same layered design as chat and document panels
- Visual consistency across all three panels
- May use different texture variant for variety

**Tasks**:
- [ ] Create search background material
- [ ] Create search screen material (transparent)
- [ ] Apply to search panel meshes
- [ ] Verify consistency with other panels
- [ ] Test in VR

**Acceptance Criteria**:
- [ ] Consistent with chat and document panel design
- [ ] Maintains cyberpunk-solarpunk aesthetic
- [ ] Good contrast and readability
- [ ] All three panels visually cohesive

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Three-Panel System
- PROJECT_TASKS.md - TASK-802
```

### Issue #ART-006: Create Living Wall Assets (Optional)

```markdown
**Priority**: P3 - LOW  
**Labels**: `art`, `environment`, `solarpunk`, `optional`  
**Milestone**: v0.4.0 - Visual Polish  
**Effort**: 6-8 hours

**Description**:
Create vertical garden/living wall assets to enhance solarpunk aesthetic.

**Concept**:
- Vertical gardens between panels
- Moss, ferns, small plants
- Bioluminescent elements with emission
- Adds warmth and organic feel

**Tasks**:
- [ ] Model or find 3D plant assets
- [ ] Create vertical garden composition
- [ ] Create PBR materials for plants
- [ ] Add emissive materials for bioluminescence
- [ ] Position between panels in room
- [ ] Add subtle point lights for glow
- [ ] Optimize for VR performance

**Acceptance Criteria**:
- [ ] Living walls add to atmosphere without distraction
- [ ] Bioluminescent elements provide subtle glow
- [ ] Performance impact minimal
- [ ] Enhances solarpunk aspect of design

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Future Enhancements
- PROJECT_TASKS.md - TASK-1001
```

### Issue #ART-007: Add Particle Systems

```markdown
**Priority**: P3 - LOW  
**Labels**: `art`, `particles`, `effects`, `optional`  
**Milestone**: v0.4.0 - Visual Polish  
**Effort**: 4-6 hours

**Description**:
Add ambient particle systems for atmosphere (floating pollen, light motes).

**Particle Systems**:

**1. Floating Organic Particles** (Pollen):
- Soft yellow-white color
- Slow movement
- Sparse emission (5 particles/second)
- 10 second lifetime

**2. Bioluminescent Light Motes**:
- Cyan-green color
- Gentle floating motion
- Very sparse
- Subtle glow

**Tasks**:
- [ ] Create pollen particle system
- [ ] Configure emission, movement, color
- [ ] Create bioluminescent particle system
- [ ] Add particle lighting module
- [ ] Position in room
- [ ] Test performance impact
- [ ] Adjust density if needed

**Acceptance Criteria**:
- [ ] Particles add subtle animation to environment
- [ ] Not distracting or obstructive
- [ ] Performance impact negligible
- [ ] Enhances atmosphere

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Particle Systems
- PROJECT_TASKS.md - TASK-1003
```

---

## Phase 1: VR Setup

### Issue #VR-001: Set Up XR Rig

```markdown
**Priority**: P0 - CRITICAL  
**Labels**: `vr`, `xr`, `setup`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 1-2 hours

**Description**:
Create XR Rig with camera and controllers using XR Interaction Toolkit.

**XR Rig Structure**:
```
XR Origin
├── Camera Offset
│   └── Main Camera (Y: 1.6m)
├── Left Controller
│   ├── XR Controller (Action-based)
│   ├── XR Ray Interactor
│   ├── XR Interactor Line Visual
│   └── Controller Model
└── Right Controller
    ├── XR Controller (Action-based)
    ├── XR Ray Interactor
    ├── XR Interactor Line Visual
    └── Controller Model
```

**Tasks**:
- [ ] Add XR Origin to scene
- [ ] Position Main Camera at 1.6m height (standing eye level)
- [ ] Add XR Controllers (left and right)
- [ ] Configure XR Ray Interactors
- [ ] Add controller models (Oculus Touch)
- [ ] Configure Input Actions
- [ ] Add XR Interaction Manager to scene
- [ ] Test in Play mode with XR Device Simulator

**Acceptance Criteria**:
- [ ] XR Rig present in scene at world origin
- [ ] Camera at correct height (1.6m)
- [ ] Controllers visible and functional
- [ ] Ray interactors working (visible rays)
- [ ] Can test in editor with simulator

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Physics & Interaction
- IMPLEMENTATION_PLAN.md - Sprint 1.1
- PROJECT_TASKS.md - TASK-105
```

### Issue #VR-002: Implement Locomotion System

```markdown
**Priority**: P0 - CRITICAL  
**Labels**: `vr`, `locomotion`, `movement`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 2-3 hours

**Description**:
Set up VR locomotion with teleportation and optional continuous movement.

**Components Needed**:
1. Teleportation Provider
2. Teleportation Interactor (on controllers)
3. Teleportation Area (on floor)
4. Continuous Move Provider (optional)
5. Snap Turn Provider

**Tasks**:
- [ ] Add Locomotion System to XR Origin
- [ ] Add Teleportation Provider
- [ ] Add Teleportation Interactors to controllers
- [ ] Create Teleportation Area on floor
- [ ] Configure teleportation arc and reticle
- [ ] Add Snap Turn Provider (45° turns)
- [ ] Optional: Add Continuous Move Provider
- [ ] Configure comfort settings (vignette, etc.)
- [ ] Test in VR headset

**Acceptance Criteria**:
- [ ] Can teleport around room using controllers
- [ ] Teleportation arc shows valid/invalid areas
- [ ] Snap turning works (45° increments)
- [ ] Movement feels comfortable in VR
- [ ] No nausea-inducing motion

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Locomotion System
- IMPLEMENTATION_PLAN.md - Sprint 2.2
- PROJECT_TASKS.md - TASK-106
```

### Issue #VR-003: Integrate VR Keyboard

```markdown
**Priority**: P1 - HIGH  
**Labels**: `vr`, `input`, `keyboard`  
**Milestone**: v0.3.0 - Core Features  
**Effort**: 2-3 hours

**Description**:
Add virtual keyboard for text input in VR.

**Options**:
1. Unity's built-in XR keyboard overlay
2. Oculus keyboard integration
3. Third-party VR keyboard asset

**Tasks**:
- [ ] Choose VR keyboard solution
- [ ] Install/import keyboard package
- [ ] Connect keyboard to TMP Input Fields
- [ ] Configure keyboard appearance
- [ ] Test text input in VR
- [ ] Ensure keyboard appears when field focused

**Acceptance Criteria**:
- [ ] Virtual keyboard appears when input field selected
- [ ] Can type messages in VR
- [ ] Keyboard dismisses after submission
- [ ] Readable and usable in VR

**Reference**:
- IMPLEMENTATION_PLAN.md - Sprint 2.1
- PROJECT_TASKS.md - TASK-502
```

### Issue #VR-004: Enable GPU Instancing

```markdown
**Priority**: P2 - MEDIUM  
**Labels**: `vr`, `optimization`, `performance`  
**Milestone**: v0.4.0 - Optimization  
**Effort**: 2-3 hours

**Description**:
Enable GPU instancing on materials to reduce draw calls.

**Benefits**:
- Batch similar objects with one draw call
- Significant performance improvement for repeated elements
- Especially useful for document cards

**Tasks**:
- [ ] Enable GPU instancing on all repeated materials
- [ ] Verify instancing is working (Frame Debugger)
- [ ] Test with many document cards
- [ ] Measure draw call reduction
- [ ] Verify no visual artifacts

**Acceptance Criteria**:
- [ ] GPU instancing enabled where applicable
- [ ] Draw calls reduced (measure with Profiler)
- [ ] No visual quality loss
- [ ] Performance improvement measurable

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Performance Optimization
- PROJECT_TASKS.md - TASK-1102
```

### Issue #VR-005: Implement Object Pooling

```markdown
**Priority**: P2 - MEDIUM  
**Labels**: `vr`, `optimization`, `performance`, `memory`  
**Milestone**: v0.4.0 - Optimization  
**Effort**: 3-5 hours

**Description**:
Implement object pooling for frequently instantiated objects.

**Objects to Pool**:
- Message bubbles (chat messages)
- Document cards
- Any other UI elements created/destroyed frequently

**Benefits**:
- Reduce garbage collection
- Eliminate instantiation overhead
- Smoother performance in VR

**Tasks**:
- [ ] Create ObjectPool utility class
- [ ] Pool message bubble prefabs
- [ ] Pool document card prefabs
- [ ] Update spawning code to use pools
- [ ] Test pool size limits
- [ ] Measure performance improvement

**Acceptance Criteria**:
- [ ] No instantiate/destroy calls for pooled objects
- [ ] Objects reused from pool
- [ ] Garbage collection reduced
- [ ] Smoother frame times

**Reference**:
- PROJECT_TASKS.md - TASK-1104
```

### Issue #VR-006: Profile and Optimize Performance

```markdown
**Priority**: P1 - HIGH  
**Labels**: `vr`, `optimization`, `performance`, `profiling`  
**Milestone**: v0.4.0 - Optimization  
**Effort**: 2-2 hours

**Description**:
Use Unity Profiler to analyze and optimize performance for VR targets.

**Target Metrics**:
- **Quest 2**: 90 FPS minimum
- **Quest 3**: 120 FPS target
- **Draw Calls**: <100
- **Memory**: <1GB

**Tasks**:
- [ ] Profile in Unity Editor
- [ ] Profile on Quest 2 device
- [ ] Profile on Quest 3 device
- [ ] Identify performance bottlenecks
- [ ] Optimize CPU-heavy scripts
- [ ] Optimize GPU rendering
- [ ] Reduce memory allocations
- [ ] Test final performance

**Acceptance Criteria**:
- [ ] Quest 2: Stable 90 FPS
- [ ] Quest 3: 120 FPS achieved
- [ ] Draw calls under target
- [ ] Memory usage acceptable
- [ ] No frame drops during typical usage

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Performance Optimization
- PROJECT_TASKS.md - TASK-1105
```

---

## Phase 1: UI Development

### Issue #UI-001: Create Chat Panel Background Mesh

```markdown
**Priority**: P1 - HIGH  
**Labels**: `ui`, `chat`, `mesh`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 1 hour

**Description**:
Create the background mesh for the chat panel.

**Specifications**:
- Type: Plane primitive
- Scale: [5, 3.5, 1] (width x height x depth)
- Position: Front wall (0° rotation, 1.6m Y, ~4.25m Z from origin)
- Purpose: Provides frame and depth for chat interface

**Tasks**:
- [ ] Create Plane GameObject
- [ ] Name it "ChatPanelBackground"
- [ ] Scale to [5, 3.5, 1]
- [ ] Position at front of room (0°, 1.6m height, 4.25m distance)
- [ ] Parent under ChatPanel GameObject
- [ ] Add mesh collider (optional, for debugging)

**Acceptance Criteria**:
- [ ] Plane visible in scene
- [ ] Correct size and position
- [ ] Faces camera (inward to room)
- [ ] Ready for material application

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Chat Interface Design
- IMPLEMENTATION_PLAN.md - Sprint 2.1
- PROJECT_TASKS.md - TASK-201
```

### Issue #UI-002: Create Chat Screen Mesh and Material

```markdown
**Priority**: P1 - HIGH  
**Labels**: `ui`, `chat`, `mesh`, `material`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 1-2 hours

**Description**:
Create the transparent screen mesh for chat UI overlay.

**Specifications**:
- Type: Plane primitive
- Scale: [4, 3, 1] (slightly smaller than background)
- Position: 50cm (0.5m) in front of background (Z: ~3.75m)
- Material: Transparent (20% opacity), glass-like

**Tasks**:
- [ ] Create Plane GameObject
- [ ] Name it "ChatPanelScreen"
- [ ] Scale to [4, 3, 1]
- [ ] Position 0.5m in front of background
- [ ] Create transparent material
- [ ] Set alpha to 0.2 (20% opacity)
- [ ] Configure glass-like smoothness
- [ ] Apply material to plane
- [ ] Parent under ChatPanel GameObject

**Acceptance Criteria**:
- [ ] Plane positioned in front of background
- [ ] Material is transparent (see background through it)
- [ ] Glass-like appearance achieved
- [ ] Ready for Canvas attachment

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Chat Interface Design
- PROJECT_TASKS.md - TASK-203
```

### Issue #UI-003: Create World Space Canvas on Chat Screen

```markdown
**Priority**: P0 - CRITICAL  
**Labels**: `ui`, `chat`, `canvas`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 1 hour

**Description**:
Add World Space Canvas to chat screen for UI elements.

**Canvas Configuration**:
- Render Mode: World Space
- Event Camera: Main Camera (XR)
- Sorting Layer: Default
- Size Delta: [400, 300] (match plane scale)

**Tasks**:
- [ ] Add Canvas component to ChatPanelScreen
- [ ] Set Render Mode to World Space
- [ ] Set Event Camera to Main Camera
- [ ] Add CanvasScaler component
- [ ] Set Reference Resolution to match canvas size
- [ ] Add GraphicRaycaster component
- [ ] Add TrackedDeviceGraphicRaycaster for VR
- [ ] Test ray interaction from controllers

**Acceptance Criteria**:
- [ ] Canvas renders in world space
- [ ] Size matches screen plane
- [ ] VR controllers can interact with canvas
- [ ] Ready for UI elements

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Unity Implementation
- IMPLEMENTATION_PLAN.md - Sprint 2.1
- PROJECT_TASKS.md - TASK-204
```

### Issue #UI-004: Design Message Bubble Prefab

```markdown
**Priority**: P1 - HIGH  
**Labels**: `ui`, `chat`, `prefab`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 2-3 hours

**Description**:
Create prefab for chat message bubbles with sender, content, and timestamp.

**Components**:
- Background Image (rounded corners)
- TextMeshPro - Sender label (bold)
- TextMeshPro - Message content
- TextMeshPro - Timestamp (small, gray)
- Layout Group for arrangement

**Color Variants**:
- User messages: Light blue (#6A9FFF)
- Agent messages: Light green (#6FFF8F)
- Error messages: Light red (#FF6A6A)
- Citations: Cyan (#6AFFFF)

**Tasks**:
- [ ] Create MessageBubble GameObject
- [ ] Add VerticalLayoutGroup
- [ ] Add Background Image with rounded corners
- [ ] Add sender TextMeshPro
- [ ] Add content TextMeshPro
- [ ] Add timestamp TextMeshPro
- [ ] Configure layout and padding
- [ ] Create prefab variants for user/agent/error
- [ ] Test readability in VR

**Acceptance Criteria**:
- [ ] Bubble displays sender, message, timestamp
- [ ] Rounded corners achieved (solarpunk aesthetic)
- [ ] Color variants for different message types
- [ ] Text is readable in VR (24-26pt)
- [ ] Layout adjusts to message length

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Chat Interface Design
- PROJECT_TASKS.md - TASK-205
```

### Issue #UI-005: Create Chat Input UI

```markdown
**Priority**: P1 - HIGH  
**Labels**: `ui`, `chat`, `input`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 2-3 hours

**Description**:
Create text input field and send button for chat interface.

**Components**:
- TMP_InputField for message text
- Button for sending message
- Placeholder text styling
- Layout at bottom of canvas

**Tasks**:
- [ ] Create InputField GameObject (TMP)
- [ ] Configure placeholder text
- [ ] Set font size for VR (24pt)
- [ ] Create Send Button
- [ ] Style button for VR interaction
- [ ] Add button label "Send"
- [ ] Position at bottom of canvas
- [ ] Add HorizontalLayoutGroup (optional)
- [ ] Connect to VR keyboard (see VR-003)

**Acceptance Criteria**:
- [ ] Input field visible and functional
- [ ] Send button clickable with VR controllers
- [ ] Placeholder text shows when empty
- [ ] Readable in VR
- [ ] Positioned at bottom of chat panel

**Reference**:
- UNITY_INTERFACE_DESIGN.md - Chat Interface Design
- IMPLEMENTATION_PLAN.md - Sprint 2.1
- PROJECT_TASKS.md - TASK-206
```

### Issue #UI-006: Create ErrorPanel UI

```markdown
**Priority**: P1 - HIGH  
**Labels**: `ui`, `error`, `feedback`  
**Milestone**: v0.2.0 - Foundation  
**Effort**: 2-3 hours

**Description**:
Create error panel for displaying errors to user in VR.

**Components**:
- World Space Canvas
- Panel background
- Error icon
- Error message text (TMP)
- Retry button
- Close button

**Tasks**:
- [ ] Create ErrorPanel GameObject with Canvas
- [ ] Set Canvas to World Space
- [ ] Add Panel background (semi-transparent red tint)
- [ ] Add error icon
- [ ] Add error message TextMeshPro
- [ ] Add Retry button
- [ ] Add Close button
- [ ] Position in VR space (front of user, slightly lower)
- [ ] Connect to ErrorManager (see API-006)

**Acceptance Criteria**:
- [ ] Panel displays error messages clearly
- [ ] Retry and Close buttons functional
- [ ] Positioned comfortably in VR
- [ ] Can be triggered by ErrorManager
- [ ] Dismisses when closed

**Reference**:
- IMPLEMENTATION_PLAN.md - Sprint 1.3
- PROJECT_TASKS.md - TASK-402
```

### Issue #UI-007: Create Toast Notification System

```markdown
**Priority**: P2 - MEDIUM  
**Labels**: `ui`, `feedback`, `notifications`  
**Milestone**: v0.3.0 - Core Features  
**Effort**: 2-4 hours

**Description**:
Create toast notification system for brief, non-critical feedback.

**Features**:
- Small notification panel
- Auto-dismiss after 3-5 seconds
- Queue multiple toasts
- Fade in/out animation

**Tasks**:
- [ ] Create ToastNotification prefab
- [ ] Add background panel
- [ ] Add message text (TMP)
- [ ] Create ToastManager singleton
- [ ] Implement show/hide animation
- [ ] Add auto-dismiss timer
- [ ] Implement toast queue
- [ ] Position in VR space (lower corner of view)

**Acceptance Criteria**:
- [ ] Toasts appear and auto-dismiss
- [ ] Multiple toasts queue properly
- [ ] Smooth fade animations
- [ ] Non-intrusive positioning
- [ ] Can be triggered from any script

**Reference**:
- PROJECT_TASKS.md - TASK-405
```

---

_Due to character limits, continuing in next response..._
