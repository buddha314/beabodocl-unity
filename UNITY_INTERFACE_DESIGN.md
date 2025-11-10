# Unity Interface Design Specification

**Project**: Beabodocl-Unity  
**Date Created**: November 2025  
**Platform**: Unity 2022.3 LTS  
**Target Devices**: Meta Quest 2/3, SteamVR  
**Based On**: [beabodocl-babylon INTERFACE_DESIGN.md](https://github.com/buddha314/beabodocl-babylon/blob/main/specs/INTERFACE_DESIGN.md)

---

## Overview

This document specifies the visual design and spatial layout for the Unity VR research interface. The design is adapted from the Babylon.js web client to leverage Unity's native VR capabilities while maintaining design consistency across platforms.

### Design Goals

1. **Platform Parity**: Maintain visual consistency with Babylon.js web client
2. **Native Performance**: Leverage Unity's XR Interaction Toolkit and rendering
3. **VR Optimization**: Maximize comfort and usability in native VR
4. **Aesthetic Consistency**: Hybrid Cyberpunk-Solarpunk visual language

---

## Design Vision

### Aesthetic Philosophy: Hybrid Cyberpunk-Solarpunk

This interface blends two complementary futuristic aesthetics to create a unique, optimistic research environment:

#### Cyberpunk Elements (Technology/Artificial)
- **Holographic displays** with floating text and UI elements
- **Neon glow effects** using Unity's post-processing stack (bloom, emission)
- **Industrial materials**: Corrugated metal, dark stone surfaces
- **High-tech interfaces**: Glass transparency, scanline effects
- **Digital aesthetics**: Cyan/purple accents, futuristic UI patterns

#### Solarpunk Elements (Nature/Organic)
- **Natural materials**: Reclaimed wood grain, bamboo textures
- **Living elements**: Moss, lichen, bioluminescent plants
- **Positive futurism**: Hope, sustainability, harmony with nature
- **Warm lighting**: Golden hour tones, soft ambient illumination
- **Biophilic design**: Green accents, earth tones, organic forms
- **Curved geometry**: Flowing forms vs. hard industrial edges

#### Design Balance Principles
- ✅ Technology serves humanity - Tools feel accessible, not alienating
- ✅ Nature integrated with tech - Organic materials alongside digital displays
- ✅ Optimistic tone - Bright, inviting atmosphere (not dystopian)
- ✅ Sustainable aesthetic - Reclaimed materials, living elements
- ✅ Harmony over conflict - Smooth transitions between organic and synthetic

---

## Spatial Environment

### The Hexagonal Room

**Core Concept**: User stands in a large hexagonal room serving as the primary VR workspace.

#### Room Layout
```
                    Sky (Procedural)
                         │
         ╱───────────────────────────╲
        ╱         HEXAGONAL           ╲
       ╱            ROOM               ╲
      │                                 │
      │   [Panel 3]     [Panel 2]      │
      │       ╲           ╱             │
      │        ╲         ╱              │
      │         ╲       ╱               │
      │          ╲     ╱                │
      │           ╲   ╱                 │
      │         [Chat Panel]            │
      │      (Front-facing)             │
      │             │                   │
      │          Camera                 │
      │        (Standing,               │
      │      Y: 1.6m height)            │
      │                                 │
       ╲             │                 ╱
        ╲            │                ╱
         ╲───────────┼───────────────╱
                Ground Plane
         (Hexagonal or large plane)
```

#### Room Specifications (Unity Units)
- **Room Type**: Hexagonal architecture (6 walls)
- **Room Radius**: 5-6 meters (comfortable walking space)
- **Wall Height**: 4 meters (provides sense of enclosure without claustrophobia)
- **Floor**: Hexagonal mesh or large plane with hexagonal texture
- **Ceiling**: Optional skylight effect with plant canopy

#### Panel Distribution
- **Chat Panel**: Front wall (0° - initial camera view)
- **Panel 2**: 120° rotation (document review/visualization)
- **Panel 3**: 240° rotation (search results/data visualization)
- **Panel Distance**: 3.75-4.25 meters from camera (comfortable reading distance)
- **Even Spacing**: Ergonomic turning between panels

### Movement Constraints

**Grounded, Realistic Locomotion**:
- ✅ **Standing at all times** - No sitting, crouching, or prone
- ✅ **Lateral movement only** - Walk forward/back, strafe left/right
- ✅ **Rotation** - Turn to face different panels
- ❌ **No vertical movement** - Cannot jump, hover, or fly
- ❌ **Height locked** - Fixed at standing eye level (~1.6m)

**Benefits**:
- Natural task separation across room
- Physical movement aids memory and context switching
- Grounded, realistic interaction model reduces VR sickness
- Turn to access different workspaces (chat, documents, search)

### Initial Camera View

**Default Position**: [0, 1.6, -0.5] (standing, 0.5m back from center)  
**Eye Level**: 1.6 meters (160 units in Unity)  
**Looking At**: Chat Panel on front wall  
**Distance to Panel**: ~3.75 meters

**User sees two layered screens**:

1. **Front Screen (Holographic Display)**
   - Semi-transparent UI surface (20% opacity)
   - Holographic appearance with floating text
   - Inspired by cyberpunk/futuristic aesthetics
   - Text appears to float in space or be projected onto glass

2. **Background Panel (Contextual Surface)**
   - Provides visual context and depth
   - Hybrid materiality:
     - **Cyberpunk**: Corrugated metal, dark stone, industrial surfaces
     - **Solarpunk**: Reclaimed wood, bamboo, moss/lichen textures
   - Contrasts with ethereal front screen
   - Grounds interface in tangible, harmonious space
   - Warm organic tones balance cool digital displays

---

## Three-Panel System

### Panel 1: Chat Interface (Primary)

**Purpose**: Main agent chat and conversation interface

**Composition**: Two-layer system
- **Layer 1 - Background Panel** (`chatBackground`)
  - Solid, opaque material (100% opacity)
  - Textured surface (metal/stone/wood hybrid)
  - Provides frame and depth
  - Position: ~4.25m from camera (Z-axis)
  
- **Layer 2 - Interactive Screen** (`chatScreen`)
  - Semi-transparent material (20% opacity)
  - Holographic glass-like appearance
  - Hosts Unity UI Canvas for chat
  - Position: ~3.75m from camera (50 units in front of background)

**Unity Components**:
```
ChatPanel (GameObject)
├── ChatBackground (Mesh: Plane, scaled [5, 3.5, 1])
│   └── Material: PBRMaterial with textured albedo
└── ChatScreen (Mesh: Plane, scaled [4, 3, 1])
    ├── Material: PBRMaterial (transparent, glass-like)
    └── Canvas (World Space)
        ├── ChatMessages (Vertical Layout Group)
        │   └── MessageBubble prefabs
        ├── InputField (TMP)
        └── SendButton
```

### Panel 2: Document Review

**Purpose**: Display research papers and documents for reading

**Position**: 120° rotation from Chat Panel (left-side wall)

**Features**:
- Full document viewer with scrolling
- Paper metadata (title, authors, year, abstract)
- Navigation controls (page/section jumping)
- Annotation tools (highlight, notes)
- Same layered design (background + transparent screen)

**Usage**:
- User turns left to face document panel
- Separate from chat for focused reading
- Physical separation aids cognitive context switching
- Turn back to chat when needed

### Panel 3: Search & Visualization

**Purpose**: Search results, data visualization, settings

**Position**: 240° rotation from Chat Panel (right-side wall)

**Potential Uses**:
- Search results display with document cards
- 3D data visualizations (keyword trends, word clouds)
- Paper relationship graph/network
- Settings and configuration
- Knowledge graph visualization

**Usage**:
- User turns right to access
- Visual/spatial tasks separate from reading/chat
- Same layered aesthetic

---

## Chat Interface Design

### Modern Chat Aesthetic

**Inspiration**: Claude Desktop, contemporary messaging apps

**Visual Properties**:
- **Clean, contemporary** messaging interface
- **Mostly transparent** panel - background shows through (20% opacity)
- **Floating text effect** - messages appear to hover or be projected
- **Glass pane metaphor** - rendered as if on transparent holographic glass
- **Minimalist design** - doesn't obstruct the environment
- **Optimistic colors** - warm accents, inviting tones
- **Soft edges** - rounded corners, organic shapes vs. hard rectangles

### Unity Implementation

**Canvas Setup**:
```csharp
// World Space Canvas on chatScreen plane
Canvas chatCanvas = chatScreen.AddComponent<Canvas>();
chatCanvas.renderMode = RenderMode.WorldSpace;
chatCanvas.worldCamera = Camera.main;

// Scale to match screen dimensions
RectTransform canvasRect = chatCanvas.GetComponent<RectTransform>();
canvasRect.sizeDelta = new Vector2(400, 300); // Match plane scale
```

**Chat Message Layout**:
- **Vertical Layout Group** with padding
- **Message Bubbles**: TextMeshPro with rounded background
- **User Messages**: Right-aligned, blue tint
- **Agent Messages**: Left-aligned, green tint
- **Source Citations**: Smaller text, cyan color
- **Timestamps**: Subtle gray, small font

**Input System**:
- **Text Input Field** at bottom
- **Send Button** with VR interaction
- **VR Keyboard**: Unity's XR keyboard overlay
- **Optional Voice Input**: Speech-to-text integration

---

## Visual Design Principles

### Color Palette

#### Primary Colors (Current)
- **Frame Background**: Dark Brown-Red (#6F3838) - Warm, grounding, earth-toned
- **Screen Tint**: Light Purple-Blue (#6A6AAF) - Cool, technological
- **Sky**: Procedural gradient (natural atmosphere)
- **Ground**: Textured (tiled material)

#### Solarpunk Accent Colors (Enhancement)
- **Living Green**: #4A7C59 - Plant life, growth, vitality
- **Warm Wood**: #8B7355 - Natural materials, warmth, sustainability
- **Soft Gold**: #D4AF37 - Sunlight, optimism, energy
- **Earth Brown**: #6B4423 - Soil, grounding, organic matter
- **Sky Blue**: #87CEEB - Hope, openness, clarity
- **Bioluminescent Glow**: Cyan-green (#20E0B0) - Living light

#### Color Relationships
- **Warm frame + cool screen** = visual hierarchy
- **Green/gold accents** = life and positive energy
- **Earth tones** = grounding and sustainability
- **Transparency** = depth perception, openness
- **High contrast** = readability and accessibility
- **Optimistic palette** = inviting, not dystopian

### Material Strategy (Unity PBR)

**Physically Based Rendering (PBR)**:
- Realistic lighting response
- Standard Shader or URP Lit Shader
- Texture maps: Albedo, Normal, Metallic, Roughness, AO

**Panel Background Materials**:
1. **Cyberpunk Option: Industrial Metal**
   - Albedo: Dark steel with rust
   - Normal: Corrugated ridges, panel seams
   - Metallic: 0.3-0.5
   - Roughness: 0.6-0.8 (weathered)
   
2. **Solarpunk Option: Reclaimed Wood**
   - Albedo: Warm wood grain
   - Normal: Wood texture detail
   - Metallic: 0.0 (non-metallic)
   - Roughness: 0.7-0.9 (matte)

3. **Hybrid Option (Recommended): Tech-Organic Fusion**
   - Base: Industrial metal panels
   - Accents: Wood trim, bamboo borders
   - Living elements: Moss in crevices (separate materials with emission)
   - Combines both aesthetics

**Screen Material**:
```csharp
// Transparent holographic glass
Material screenMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
screenMat.SetColor("_BaseColor", new Color(0.417f, 0.417f, 0.687f, 0.2f)); // 20% alpha
screenMat.SetFloat("_Metallic", 0f);
screenMat.SetFloat("_Smoothness", 0.5f); // Slight gloss for glass effect
screenMat.SetFloat("_Surface", 1); // Transparent mode
```

### Depth & Layering

**Layer Stack (front to back)**:
1. **Chat UI Elements** - Text, buttons (Canvas on screen)
2. **Chat Screen** - Transparent plane (Z: 3.75m)
3. **Chat Background** - Textured panel (Z: 4.25m)
4. **Room Environment** - Walls, floor, sky
5. **Ground Plane** - Textured hexagonal floor

**Depth Cues**:
- ~50cm separation between screen and background
- Transparency creates see-through layering
- Unity's lighting creates natural shadow depth
- Post-processing bloom adds holographic glow
- Parallax from VR head movement enhances depth

---

## Typography & Text (Unity TextMeshPro)

### Font Sizing (VR-Optimized)

**Readability in VR** requires larger text than desktop:
- **Title/Header**: 28-32pt
- **Message Text**: 24-26pt (primary content)
- **Input Field**: 24pt
- **Metadata/Timestamps**: 18-20pt
- **Button Labels**: 22pt

### Text Colors (High Contrast for VR)

```csharp
// Color definitions
Color textPrimary = Color.white; // #FFFFFF
Color textSecondary = new Color(0.8f, 0.8f, 0.8f); // Light gray #CCCCCC
Color textPlaceholder = new Color(1f, 1f, 1f, 0.5f); // 50% opacity white
Color userMessageTint = new Color(0.6f, 0.8f, 1f); // Light blue
Color agentMessageTint = new Color(0.6f, 1f, 0.8f); // Light green
Color errorText = new Color(1f, 0.4f, 0.4f); // Light red
Color sourceCitation = new Color(0.4f, 0.9f, 1f); // Cyan
```

### Readability Enhancements

- **Text Shadow**: Slight drop shadow for legibility against transparent background
- **Outline**: Optional outline shader for critical UI
- **Line Spacing**: 1.4-1.6 for VR comfort (prevents eye strain)
- **Max Line Length**: ~50-60 characters per line
- **Smooth Scrolling**: Animated scroll for chat history

---

## Lighting & Environment

### Environment Setup (Unity)

**Skybox**:
- **Type**: Procedural Sky (Unity's built-in)
- **Sun Color**: Warm golden tone (sunrise/sunset feel)
- **Sun Intensity**: Medium (not harsh)
- **Atmosphere Thickness**: 1.0
- **Sky Tint**: Soft blue-purple gradient
- **Ground Color**: Warm earth tone

**Directional Light (Sun)**:
- **Color**: Warm white (#FFF4E6)
- **Intensity**: 0.8-1.0
- **Rotation**: Low angle (morning/evening light)
- **Shadows**: Soft shadows enabled
- **Shadow Distance**: 50m
- **Shadow Cascades**: 2 or 4 (for quality)

**Ambient Lighting**:
- **Source**: Skybox
- **Intensity**: 0.8
- **Ambient Mode**: Realtime or Baked (performance dependent)
- **Reflection Probes**: At room center for realistic reflections

### Solarpunk Lighting Enhancements

**Additional Light Sources**:
1. **Ceiling Skylight Effect**
   - Area Light simulating sunlight through glass
   - Warm golden color temperature (3500K)
   - Soft shadows, low intensity

2. **Bioluminescent Accents**
   - Emissive materials on plants/moss
   - Soft green-blue glow (#20E0B0)
   - Point lights with low intensity (0.3-0.5)
   - No shadows (emission only)

3. **Corner Ambient Lights**
   - Small point lights in room corners
   - Warm color temperature (2700K - warm white)
   - Fill light to soften shadows
   - Very low intensity (0.2-0.4)

**Lighting Goals**:
- Natural, inviting atmosphere
- Soft shadows (reduce harshness)
- Warm overall tone (not clinical/cold)
- Bioluminescent details add magic
- Golden hour lighting (hopeful, optimistic)

---

## Physics & Interaction (Unity XR)

### Physics Configuration

**Gravity**: [0, -9.81, 0] m/s² (Earth standard)

**Ground Collider**:
- Mesh Collider or Box Collider on ground plane
- Layer: "Ground"
- Material: Physical material with friction

**Panel Colliders**:
- None (UI elements, no physics needed)
- Interaction via XR Interaction Toolkit

### XR Interaction System

**Unity XR Interaction Toolkit Components**:

1. **XR Rig Setup**
```
XR Origin (GameObject)
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

2. **Chat Screen Interaction**
```csharp
// On chatScreen GameObject
XRSimpleInteractable interactable = chatScreen.AddComponent<XRSimpleInteractable>();
interactable.selectEntered.AddListener(OnChatScreenSelected);

// Canvas interaction
TrackedDeviceGraphicRaycaster raycaster = chatCanvas.AddComponent<TrackedDeviceGraphicRaycaster>();
```

### Locomotion System

**Unity XR Locomotion Components**:

1. **Teleportation System**
   - `Teleportation Provider` on XR Origin
   - `Teleportation Interactor` on controllers
   - `Teleportation Area` on ground plane
   - Visual arc and target reticle

2. **Continuous Movement** (Optional)
   - `Continuous Move Provider` on XR Origin
   - Left thumbstick: Forward/back, strafe
   - Smooth locomotion option

3. **Snap Turn Provider**
   - Right thumbstick: 30° or 45° snap turns
   - Alternative: Smooth turn provider

**Movement Configuration**:
```csharp
// Locomotion System on XR Origin
ContinuousMoveProviderBase moveProvider = xrOrigin.AddComponent<ActionBasedContinuousMoveProvider>();
moveProvider.moveSpeed = 2.0f; // 2 m/s walk speed

SnapTurnProviderBase turnProvider = xrOrigin.AddComponent<ActionBasedSnapTurnProvider>();
turnProvider.turnAmount = 45f; // 45-degree snap turns
```

### Input Methods

**VR Controllers** (Primary):
- Trigger: Select/confirm actions
- Grip: Grab (if applicable)
- Thumbstick: Movement and turning
- Buttons: Menu, UI shortcuts

**Desktop Fallback** (Testing):
- WASD: Movement
- Mouse: Look around
- Left Click: Select
- Right Click: Cancel
- Space: Teleport (testing)

**Voice Input** (Future):
- Speech-to-text for chat input
- Voice commands ("Open document", "Search for...")

---

## Asset Generation & Materials

### Texture Creation Strategy

**Recommended Workflow**:
1. **AI Generation** (ComfyUI, Stable Diffusion)
   - Generate base albedo textures
   - Create seamless tileable patterns
   - Use SDXL for high quality (1024x1024 or 2048x2048)

2. **PBR Map Generation**
   - Albedo: Base color texture
   - Normal Map: Surface detail (from height map)
   - Roughness: Grayscale map (matte/glossy areas)
   - Metallic: Black/white mask (metal vs non-metal)
   - Ambient Occlusion: Shadows in crevices
   - Emissive: For bioluminescent elements

3. **Unity Import**
   - Import textures to Unity
   - Create Material (URP Lit Shader)
   - Assign texture maps
   - Adjust material properties
   - Apply to mesh

### Panel Background Textures

**Cyberpunk Metal Panel** (Option 1):
```
AI Prompt (Stable Diffusion SDXL):
Positive: "corrugated metal texture, dark industrial steel, weathered rusty surface, 
rivets and bolts, seamless tileable pattern, PBR material, 4K resolution, photorealistic, 
high detail, panel seams, industrial sci-fi"

Negative: "people, faces, text, watermark, blurry, low quality, distorted"

Settings: 1024x1024, CFG 7-9, Steps 30-40
```

**Solarpunk Wood Panel** (Option 2):
```
AI Prompt (Stable Diffusion SDXL):
Positive: "reclaimed weathered wood texture, warm natural grain, sustainable eco-friendly 
material, bamboo accents, organic texture, seamless tileable pattern, PBR material, 4K 
resolution, photorealistic, earthy tones, hope and nature"

Negative: "people, faces, text, watermark, plastic, synthetic, cold colors, dystopian"

Settings: 1024x1024, CFG 7-9, Steps 30-40
```

**Hybrid Tech-Organic Panel** (Recommended):
```
AI Prompt (Stable Diffusion SDXL):
Positive: "industrial metal panel with organic moss growing in crevices, sustainable 
solarpunk cyberpunk fusion, reclaimed materials, nature reclaiming technology, green 
living plants on dark metal, seamless tileable PBR texture, 4K resolution, photorealistic, 
hopeful futurism"

Negative: "people, faces, text, watermark, pure synthetic, dystopian dark, death decay"

Settings: 1024x1024, CFG 7-9, Steps 35-45
```

**Living Wall Texture** (Accent Element):
```
AI Prompt (Stable Diffusion SDXL):
Positive: "vertical garden living wall texture, lush green moss and lichen, small plants 
and ferns, bioluminescent glow accents, natural organic growth, seamless tileable pattern, 
4K resolution, photorealistic, vibrant life, sustainable architecture"

Negative: "people, faces, text, watermark, dead plants, brown wilted, artificial fake"

Settings: 1024x1024, CFG 7-9, Steps 30-40
```

### Free Texture Resources

**High-Quality PBR Texture Libraries**:
- **Poly Haven** (polyhaven.com) - CC0 license, PBR materials
- **ambientCG** (ambientcg.com) - Free seamless textures
- **CC0 Textures** (cc0textures.com) - Public domain PBR sets
- **Texture Haven** (texturehaven.com) - Natural textures

### Holographic Effects (Unity Post-Processing)

**Post-Processing Stack (URP)**:

1. **Bloom** (Holographic Glow)
```csharp
// Add to camera
var volume = PostProcessVolume.Create();
var bloom = volume.profile.Add<Bloom>();
bloom.intensity.value = 0.3f;
bloom.threshold.value = 0.8f; // Only bright elements glow
bloom.scatter.value = 0.7f;
```

2. **Color Grading** (Cyberpunk Tint)
```csharp
var colorGrading = volume.profile.Add<ColorGrading>();
colorGrading.temperature.value = 10f; // Slight warm tint
colorGrading.tint.value = -5f; // Slight cyan-purple
```

3. **Vignette** (VR Comfort)
```csharp
var vignette = volume.profile.Add<Vignette>();
vignette.intensity.value = 0.2f; // Subtle edge darkening
vignette.smoothness.value = 0.4f;
```

### Particle Systems (Ambient Effects)

**Floating Organic Particles**:
```csharp
// Solarpunk ambient particles
ParticleSystem pollenParticles = roomCenter.AddComponent<ParticleSystem>();
var main = pollenParticles.main;
main.startLifetime = 10f;
main.startSpeed = 0.1f;
main.startSize = 0.02f;
main.startColor = new Color(0.9f, 0.95f, 0.7f, 0.6f); // Soft yellow-white

var emission = pollenParticles.emission;
emission.rateOverTime = 5f; // Sparse, subtle

// Bioluminescent light motes
ParticleSystem biolumParticles = corner.AddComponent<ParticleSystem>();
main = biolumParticles.main;
main.startColor = new Color(0.2f, 0.9f, 0.7f, 0.8f); // Cyan-green
main.startSize = 0.05f;
// Add glow with particle light module
```

---

## Hexagonal Room Geometry

### Room Creation (Unity)

**Option 1: Procedural Cylinder (Quick)**
```csharp
GameObject CreateHexagonalRoom(float radius, float height)
{
    GameObject room = new GameObject("HexagonalRoom");
    
    // Create hexagonal cylinder (6 sides)
    GameObject walls = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
    walls.name = "Walls";
    walls.transform.parent = room.transform;
    walls.transform.localScale = new Vector3(radius * 2, height / 2, radius * 2);
    
    // Set material
    Material wallMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    walls.GetComponent<Renderer>().material = wallMat;
    
    // Floor
    GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
    floor.name = "Floor";
    floor.transform.parent = room.transform;
    floor.transform.localScale = new Vector3(radius, 1, radius);
    
    return room;
}
```

**Option 2: Blender Modeling (Quality)**
1. Model hexagonal room in Blender
2. Separate walls for individual texturing
3. UV unwrap for seamless tiling
4. Export as FBX or GLB
5. Import to Unity

**Option 3: ProBuilder (Unity Tool)**
1. Install ProBuilder package
2. Create custom hexagon shape
3. Extrude to create walls
4. UV unwrap in ProBuilder
5. Apply materials

### Room Specifications

```csharp
// Recommended dimensions (Unity units = meters)
float roomRadius = 5.5f; // 5.5 meters from center to wall
float wallHeight = 4.0f; // 4 meters tall
float floorThickness = 0.1f;

Vector3[] hexagonVertices = new Vector3[6];
for (int i = 0; i < 6; i++)
{
    float angle = i * 60f * Mathf.Deg2Rad;
    hexagonVertices[i] = new Vector3(
        Mathf.Cos(angle) * roomRadius,
        0,
        Mathf.Sin(angle) * roomRadius
    );
}
```

### Panel Positioning

```csharp
// Position panels on hexagon walls
Vector3 GetPanelPosition(int panelIndex, float distanceFromCenter)
{
    float angle = panelIndex * 120f * Mathf.Deg2Rad; // 0°, 120°, 240°
    return new Vector3(
        Mathf.Sin(angle) * distanceFromCenter,
        1.6f, // Eye level
        Mathf.Cos(angle) * distanceFromCenter
    );
}

// Usage
Vector3 chatPanelPos = GetPanelPosition(0, 4.0f); // Front wall
Vector3 docPanelPos = GetPanelPosition(1, 4.0f); // Left wall (120°)
Vector3 searchPanelPos = GetPanelPosition(2, 4.0f); // Right wall (240°)
```

---

## Performance Optimization (Unity VR)

### Target Metrics

**Quest 2**:
- **Frame Rate**: 90 FPS (minimum)
- **Draw Calls**: <100
- **Batches**: <80
- **Tris**: <500k total scene
- **Memory**: <1GB

**Quest 3**:
- **Frame Rate**: 120 FPS (target)
- **Draw Calls**: <150
- **Resolution**: Higher than Quest 2

### Optimization Techniques

**1. Static Batching**
```csharp
// Mark room geometry as static
walls.isStatic = true;
floor.isStatic = true;
// Unity will batch static meshes automatically
```

**2. GPU Instancing**
```csharp
// Enable on materials
material.enableInstancing = true;
// Use for repeated elements (document cards, particles)
```

**3. LOD Groups** (if needed)
```csharp
LODGroup lodGroup = documentCard.AddComponent<LODGroup>();
LOD[] lods = new LOD[2];
lods[0] = new LOD(0.6f, highDetailRenderers); // 60% screen height
lods[1] = new LOD(0.1f, lowDetailRenderers); // 10% screen height
lodGroup.SetLODs(lods);
```

**4. Occlusion Culling**
- Bake occlusion data for room
- Panels behind user won't render
- Use Unity's Occlusion Culling window

**5. Texture Compression**
- Android: ASTC format (Quest devices)
- Max size: 2048x2048 for main textures
- Mipmap generation enabled

**6. Light Baking**
```csharp
// Static lighting for room
light.lightmapBakeType = LightmapBakeType.Baked;
// Bake in Lighting window
// Saves runtime performance
```

---

## Accessibility & VR Comfort

### VR Comfort Features

**Distance & Scale**:
- Panels at comfortable reading distance (3.75-4.25m)
- Text large enough for clarity (24pt+)
- Not too close (prevents eye strain and nausea)

**Transparency**:
- 20% opacity maintains environmental awareness
- Reduces motion sickness (peripheral vision preserved)
- User can see surroundings through UI

**Color Choices**:
- High contrast for readability
- No bright pure whites (use off-white #F0F0F0)
- No pure blacks (use dark gray #101010)
- Warm palette reduces eye strain

**Movement**:
- Grounded locomotion only (reduces sickness)
- Smooth movement option with comfort vignette
- Snap turn as alternative to smooth turn
- Teleportation as safest option

### Input Accessibility

**Multiple Control Schemes**:
1. **VR Controllers** (Primary)
   - Ray-based interaction
   - Physical button presses

2. **Gaze + Dwell** (Hands-free)
   - Look at UI element
   - Dwell timer (2 seconds) to select
   - For users with limited hand mobility

3. **Voice Commands** (Future)
   - "Send message"
   - "Open document"
   - "Search for [topic]"

4. **Desktop Mode** (Testing/Accessibility)
   - Mouse and keyboard
   - Full functionality without VR headset

---

## Future Enhancements

### Planned Features

**1. Living Wall Sections**
- Vertical gardens between panels
- Bioluminescent plant meshes
- Animated growth (subtle)
- Emissive materials for glow

**2. Dynamic Lighting**
- Time-of-day cycle (optional)
- Lighting mood presets
- User-adjustable ambient light
- Bioluminescent intensity control

**3. Room Customization**
- Multiple visual themes
- Material swapping (cyberpunk vs solarpunk emphasis)
- Panel layout rearrangement
- Room size adjustment

**4. Advanced Interactions**
- Hand tracking support (XR Hands package)
- Gesture controls (pinch to zoom, swipe to scroll)
- Physical document manipulation (pick up, rotate)
- Spatial audio for panel activation

**5. Holographic Enhancements**
- Scanline shader effect
- Glitch animation on data load
- Particle effects around UI
- Dynamic opacity based on user proximity

**6. Multi-User Features**
- Shared VR space
- Avatars for collaborators
- Synchronized document viewing
- Voice chat integration

---

## Implementation Checklist

### Phase 1: Basic Room & Chat

- [ ] Create hexagonal room geometry (Blender or ProBuilder)
- [ ] Apply basic materials to walls/floor
- [ ] Position Chat Panel (background + screen layers)
- [ ] Create World Space Canvas on chat screen
- [ ] Implement basic chat UI (messages, input field)
- [ ] Test VR interaction with chat panel
- [ ] Add teleportation locomotion
- [ ] Configure lighting (directional light + ambient)

### Phase 2: Visual Polish

- [ ] Generate/source panel background textures (AI or library)
- [ ] Create PBR materials with all maps
- [ ] Apply materials to chat background
- [ ] Add post-processing (bloom for holographic effect)
- [ ] Implement transparent glass material for screen
- [ ] Add bioluminescent accent lights (corner lights)
- [ ] Create skybox or procedural sky
- [ ] Optimize for VR performance (90 FPS target)

### Phase 3: Additional Panels

- [ ] Position Panel 2 (Document Review) at 120°
- [ ] Position Panel 3 (Search/Viz) at 240°
- [ ] Implement panel activation system (turn to activate)
- [ ] Create document viewer UI
- [ ] Create search results UI
- [ ] Add panel transition effects (fade in/out)

### Phase 4: Solarpunk Elements

- [ ] Add living wall sections (3D plants or textured planes)
- [ ] Implement bioluminescent emissive materials
- [ ] Create particle systems (pollen, light motes)
- [ ] Add wood/bamboo trim to panel frames
- [ ] Implement warm lighting scheme
- [ ] Add optional skylight effect on ceiling
- [ ] Balance cyberpunk-solarpunk aesthetic

### Phase 5: Optimization & Testing

- [ ] Bake lighting for static elements
- [ ] Enable GPU instancing on materials
- [ ] Test on Quest 2 (90 FPS target)
- [ ] Test on Quest 3 (120 FPS target)
- [ ] Implement LOD if needed
- [ ] Profile with Unity Profiler
- [ ] Test all interaction modalities
- [ ] User testing for comfort and usability

---

## Design Rationale

### Why Hexagonal Room?

- **Six walls** provide natural segmentation for displays
- **Three panels** use alternating walls (0°, 120°, 240°) for optimal spacing
- **120° rotation** between panels is comfortable turning distance
- **Enclosed space** creates focused work environment without claustrophobia
- **Symmetrical geometry** is aesthetically pleasing and intuitive
- **Hexagon in nature** - honeycomb pattern represents organic efficiency

### Why Hybrid Cyberpunk-Solarpunk?

- **Best of both worlds**: High-tech functionality + natural warmth
- **Positive futurism**: Technology as tool for good, not dystopian
- **Sustainable narrative**: Harmony between digital and natural
- **Visual richness**: Organic textures prevent sterile tech feel
- **Emotional balance**: Cool digital + warm organic = comfortable, inviting
- **Hope-oriented**: Solarpunk counters cyberpunk's darkness with optimism

### Why Grounded Movement?

- **Realistic locomotion** reduces VR sickness
- **No flying/jumping** prevents disorientation
- **Physical turning** to access panels aids spatial memory
- **Standing height locked** eliminates accidental vertical movement
- **Natural movement** feels familiar and accessible

### Why Layered Panels?

- **Background** provides context and grounding (solid, tactile)
- **Screen** maintains focus on content (transparent, ethereal)
- **Depth separation** creates natural 3D layering
- **Holographic aesthetic** aligns with futuristic research tool concept
- **Transparency** preserves spatial awareness and reduces claustrophobia

---

## Technical Specifications

### Unity Project Settings

**Render Pipeline**: Universal Render Pipeline (URP)

**Quality Settings**:
```
VR Quality Level:
- Anti-Aliasing: MSAA 4x (Quest 2) or 8x (Quest 3)
- Shadows: Hard shadows or soft shadows (baked)
- Texture Quality: Full resolution
- Anisotropic Textures: Per Texture
- Real-time Reflection Probes: Off (use baked)
```

**XR Plugin Management**:
- Oculus XR Plugin (Quest)
- OpenXR Plugin (SteamVR)

**Physics Settings**:
- Gravity: [0, -9.81, 0]
- Fixed Timestep: 0.0111 (90 Hz for Quest 2)
- Collision Matrix: Ground layer collides with player only

### Scene Hierarchy

```
Scene: MainScene
├── Environment
│   ├── HexagonalRoom
│   │   ├── Walls (6 separate meshes or single hexagonal cylinder)
│   │   ├── Floor (hexagonal plane)
│   │   └── Ceiling (optional, for skylight)
│   ├── Lighting
│   │   ├── Directional Light (Sun)
│   │   ├── Corner Lights (4x Point Light)
│   │   └── Bioluminescent Lights (optional accents)
│   └── Living Elements (optional)
│       ├── LivingWall_Panel1
│       ├── LivingWall_Panel2
│       └── CornerPlants
├── UI Panels
│   ├── ChatPanel
│   │   ├── ChatBackground (Mesh + PBR Material)
│   │   └── ChatScreen (Mesh + Transparent Material + Canvas)
│   ├── DocumentPanel (at 120°)
│   │   ├── DocBackground
│   │   └── DocScreen
│   └── SearchPanel (at 240°)
│       ├── SearchBackground
│       └── SearchScreen
├── XR Rig
│   ├── Camera Offset
│   │   └── Main Camera (Post-Processing Volume)
│   ├── LeftHand Controller
│   └── RightHand Controller
├── Locomotion System
│   ├── Teleportation Provider
│   ├── Continuous Move Provider
│   └── Snap Turn Provider
└── Managers
    ├── GameManager (API, State)
    ├── UIManager
    └── ChatManager
```

---

## References & Resources

### Unity Documentation
- [XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@latest)
- [Universal Render Pipeline](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@latest)
- [Post-Processing](https://docs.unity3d.com/Packages/com.unity.postprocessing@latest)
- [TextMeshPro](https://docs.unity3d.com/Manual/com.unity.textmeshpro.html)

### Design Inspiration
- **Babylon.js Interface Design**: [beabodocl-babylon/specs/INTERFACE_DESIGN.md](https://github.com/buddha314/beabodocl-babylon/blob/main/specs/INTERFACE_DESIGN.md)
- **Cyberpunk Aesthetics**: Blade Runner, Ghost in the Shell, Cyberpunk 2077
- **Solarpunk References**: Studio Ghibli, Wakanda (Black Panther), sustainable architecture
- **Modern VR UI**: Meta Horizon Workrooms, Apple Vision Pro, Spatial
- **Messaging Apps**: Claude Desktop, Discord, Slack (for chat layout inspiration)

### Asset Resources
- **Poly Haven** (polyhaven.com) - Free PBR textures, HDRIs
- **Sketchfab** - 3D models (some free CC)
- **Unity Asset Store** - XR tools, environment packs
- **Quixel Megascans** (via Epic) - High-quality scanned materials

### AI Generation Tools
- **ComfyUI + Stable Diffusion SDXL** - Texture generation
- **Midjourney** - Concept art and reference images
- **Meshy.ai / Luma AI** - 3D asset generation from text/images

---

**Document Status**: Complete  
**Version**: 1.0  
**Last Updated**: November 2025  
**Next Review**: After Phase 1 implementation

This design document serves as the comprehensive visual and spatial specification for the Unity VR client, ensuring consistency with the Babylon.js web client while leveraging Unity's native VR strengths.
