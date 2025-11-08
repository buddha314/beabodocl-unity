# Unity Implementation Plan

**Project**: Beabodocl-Unity  
**Date Created**: November 7, 2025  
**Platform**: Unity 2022.3 LTS  
**Target**: Meta Quest, SteamVR, Desktop

---

## Executive Summary

This document outlines the complete implementation plan for the Unity VR client for the Babocument research platform. The Unity client provides native VR/XR capabilities with high performance and immersive interactions, complementing the web-based Babylon.js client.

### Key Differences from Babylon.js Client

| Aspect | Babylon (Web) | Unity (Native) |
|--------|---------------|----------------|
| **Platform** | Browser-based WebXR | Native VR (Quest, SteamVR) |
| **Performance** | 72 FPS target | 90 FPS+ native rendering |
| **Distribution** | URL link | App stores, sideloading |
| **Graphics** | WebGL limitations | Full GPU access |
| **Input** | Web APIs | Native XR input |
| **Offline** | Limited PWA | Full offline capability |
| **Language** | TypeScript/JavaScript | C# |
| **Build Size** | ~5-10 MB initial | ~50-100 MB APK |

### Development Timeline

- **Phase 1**: Foundation (4-6 weeks) - 40-58 hours
- **Phase 2**: Core Features (6-8 weeks) - 72-100 hours  
- **Phase 3**: Advanced Features (8-12 weeks) - 126-174 hours
- **Phase 4**: Polish & Launch (4-6 weeks) - 54-78 hours

**Total**: 22-32 weeks with 1-2 developers

---

## Phase 1: Foundation & Infrastructure (4-6 weeks)

### Sprint 1.1: Unity Project Setup (1 week, 12-16 hours)

**Goal**: Establish Unity project structure and XR foundation

#### Tasks

**1.1 Project Configuration (3-4 hours)**
- [ ] Create Unity 2022.3 LTS project
- [ ] Configure project settings
  - Android build target for Quest
  - Windows build target for PC VR
  - Graphics API: Vulkan (Android), DirectX 11 (Windows)
  - Color space: Linear
- [ ] Set up version control (.gitignore for Unity)
- [ ] Create folder structure (Assets/Scripts, Prefabs, Scenes, etc.)

**1.2 XR Package Installation (2-3 hours)**
- [ ] Install XR Plugin Management
- [ ] Install XR Interaction Toolkit 2.5.0+
- [ ] Install Oculus XR Plugin (for Quest)
- [ ] Install OpenXR Plugin (for SteamVR)
- [ ] Configure XR settings
  - Enable Oculus for Android
  - Enable OpenXR for Windows
- [ ] Create XR Rig prefab with:
  - XR Origin
  - XR Camera
  - Left/Right XR Controllers
  - Locomotion system (teleport + continuous movement)

**1.3 Scene Setup (3-4 hours)**
- [ ] Create MainScene.unity
- [ ] Add XR Rig to scene
- [ ] Create basic environment (floor, skybox)
- [ ] Add lighting
- [ ] Test in editor with XR Device Simulator
- [ ] Test on actual VR headset

**1.4 Input System (4-5 hours)**
- [ ] Configure Input Actions for XR
  - Grip, Trigger, Thumbstick, Buttons
- [ ] Create InputManager.cs singleton
- [ ] Implement desktop fallback controls
  - WASD movement
  - Mouse look
  - Mouse clicks for interactions
- [ ] Test input in both VR and desktop modes

**Deliverables:**
- ✅ Unity project configured for VR
- ✅ XR Rig working in editor and on headset
- ✅ Basic scene with navigation
- ✅ Input system functional

---

### Sprint 1.2: API Client Implementation (2 weeks, 16-24 hours)

**Goal**: Create C# API client for Babocument backend communication

#### Architecture

```
Unity Scripts
├── API/
│   ├── ApiClient.cs              # HTTP client wrapper
│   ├── AgentApi.cs               # Agent chat endpoints
│   ├── DocumentApi.cs            # Document endpoints
│   ├── Models/
│   │   ├── ChatMessage.cs
│   │   ├── ChatRequest.cs
│   │   ├── ChatResponse.cs
│   │   ├── Document.cs
│   │   └── SearchResult.cs
│   └── Config/
│       └── ApiConfig.cs          # API configuration ScriptableObject
```

#### Tasks

**2.1 HTTP Client Foundation (4-6 hours)**

Create `Assets/Scripts/API/ApiClient.cs`:

```csharp
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ApiClient : MonoBehaviour
{
    public static ApiClient Instance { get; private set; }
    
    [SerializeField] private ApiConfig config;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public async Task<T> Get<T>(string endpoint)
    {
        string url = $"{config.BaseUrl}{endpoint}";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            await SendRequest(request);
            return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);
        }
    }
    
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
    
    private async Task SendRequest(UnityWebRequest request)
    {
        var operation = request.SendWebRequest();
        while (!operation.isDone)
            await Task.Yield();
            
        if (request.result != UnityWebRequest.Result.Success)
        {
            throw new Exception($"API Error: {request.error}");
        }
    }
}
```

**2.2 Data Models (3-4 hours)**

Create models in `Assets/Scripts/API/Models/`:

```csharp
// ChatMessage.cs
[Serializable]
public class ChatMessage
{
    public string role;        // "user" | "assistant" | "system"
    public string content;
    public string timestamp;
}

// ChatRequest.cs
[Serializable]
public class ChatRequest
{
    public string message;
    public string conversation_id;
    public object context;
}

// ChatResponse.cs
[Serializable]
public class ChatResponse
{
    public string message;
    public string conversation_id;
    public ChatSource[] sources;
    public object metadata;
}

[Serializable]
public class ChatSource
{
    public string title;
    public string url;
    public float relevance;
}

// Document.cs
[Serializable]
public class Document
{
    public string id;
    public string title;
    public string[] authors;
    public int year;
    public string @abstract;
    public string content;
}
```

**2.3 Agent API Implementation (4-6 hours)**

Create `Assets/Scripts/API/AgentApi.cs`:

```csharp
using System.Threading.Tasks;
using UnityEngine;

public class AgentApi : MonoBehaviour
{
    public static AgentApi Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public async Task<ChatResponse> SendMessage(string message, string conversationId = null)
    {
        var request = new ChatRequest
        {
            message = message,
            conversation_id = conversationId
        };
        
        return await ApiClient.Instance.Post<ChatResponse>("/api/v1/agent/chat", request);
    }
    
    public async Task<ChatMessage[]> GetHistory(string conversationId)
    {
        return await ApiClient.Instance.Get<ChatMessage[]>($"/api/v1/agent/conversations/{conversationId}");
    }
    
    public async Task DeleteConversation(string conversationId)
    {
        // Implementation for DELETE request
    }
}
```

**2.4 Configuration (2-3 hours)**

Create ScriptableObject `Assets/Scripts/API/Config/ApiConfig.cs`:

```csharp
using UnityEngine;

[CreateAssetMenu(fileName = "ApiConfig", menuName = "Config/API Configuration")]
public class ApiConfig : ScriptableObject
{
    [Header("Backend Configuration")]
    public string BaseUrl = "http://192.168.1.200:8000";
    
    [Header("Timeouts")]
    public int TimeoutSeconds = 30;
    
    [Header("Retry Settings")]
    public int MaxRetries = 3;
    public float RetryDelaySeconds = 1.0f;
    
    [Header("Authentication")]
    public bool UseAuthentication = false;
    public string AuthToken;
}
```

Create asset: `Assets/Config/ApiConfig.asset`

**2.5 Testing (3-5 hours)**
- [ ] Create test scene with UI
- [ ] Test GET /api/v1/documents
- [ ] Test POST /api/v1/agent/chat
- [ ] Test error handling
- [ ] Test timeout handling
- [ ] Verify JSON serialization/deserialization

**Deliverables:**
- ✅ ApiClient with GET/POST methods
- ✅ Data models for all API types
- ✅ AgentApi for chat functionality
- ✅ ApiConfig ScriptableObject
- ✅ Test scene demonstrating API calls

---

### Sprint 1.3: Error Handling & Loading States (1 week, 12-18 hours)

**Goal**: Implement robust error handling and user feedback

#### Tasks

**3.1 Error Handling System (4-6 hours)**

Create `Assets/Scripts/Managers/ErrorManager.cs`:

```csharp
using UnityEngine;
using System;

public class ErrorManager : MonoBehaviour
{
    public static ErrorManager Instance { get; private set; }
    
    [SerializeField] private ErrorPanel errorPanel;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void ShowError(string message, Exception exception = null)
    {
        Debug.LogError($"Error: {message}");
        if (exception != null)
            Debug.LogException(exception);
            
        if (errorPanel != null)
            errorPanel.Show(message);
    }
    
    public void ShowNetworkError()
    {
        ShowError("Network error. Please check your connection to the backend server.");
    }
    
    public void ShowApiError(string endpoint, string error)
    {
        ShowError($"API Error ({endpoint}): {error}");
    }
}
```

**3.2 Loading State UI (4-6 hours)**

Create `Assets/Scripts/UI/LoadingOverlay.cs`:

```csharp
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingOverlay : MonoBehaviour
{
    public static LoadingOverlay Instance { get; private set; }
    
    [SerializeField] private GameObject overlay;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Slider progressBar;
    [SerializeField] private GameObject spinner;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void Show(string message, float progress = -1)
    {
        overlay.SetActive(true);
        statusText.text = message;
        
        if (progress >= 0)
        {
            progressBar.gameObject.SetActive(true);
            progressBar.value = progress;
            spinner.SetActive(false);
        }
        else
        {
            progressBar.gameObject.SetActive(false);
            spinner.SetActive(true);
        }
    }
    
    public void Hide()
    {
        overlay.SetActive(false);
    }
}
```

**3.3 Unity Try-Catch Patterns (2-3 hours)**

Update ApiClient with error handling:

```csharp
public async Task<T> Get<T>(string endpoint)
{
    try
    {
        LoadingOverlay.Instance.Show("Loading...");
        
        string url = $"{config.BaseUrl}{endpoint}";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            await SendRequest(request);
            return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);
        }
    }
    catch (Exception ex)
    {
        ErrorManager.Instance.ShowApiError(endpoint, ex.Message);
        throw;
    }
    finally
    {
        LoadingOverlay.Instance.Hide();
    }
}
```

**3.4 UI Prefabs (2-3 hours)**
- [ ] Create ErrorPanel prefab with retry button
- [ ] Create LoadingOverlay prefab
- [ ] Create Toast notification prefab
- [ ] Add to Canvas in MainScene
- [ ] Test error scenarios

**Deliverables:**
- ✅ ErrorManager for centralized error handling
- ✅ LoadingOverlay for async operations
- ✅ UI prefabs for user feedback
- ✅ Try-catch in all API calls

---

## Phase 2: Core VR Features (6-8 weeks)

### Sprint 2.1: VR Chat Interface (2 weeks, 14-20 hours)

**Goal**: Implement 3D chat panel in VR with agent integration

#### Architecture

```
Chat System
├── ChatManager.cs                # Singleton manager
├── ChatPanel3D.cs                # 3D floating chat panel
├── ChatMessage.cs                # Individual message bubble
├── VoiceInput.cs                 # Voice recognition (optional)
└── Prefabs/
    ├── ChatPanel.prefab
    ├── MessageBubble.prefab
    └── ChatInput.prefab
```

#### Tasks

**1.1 Chat Panel 3D (6-8 hours)**

Create `Assets/Scripts/Chat/ChatPanel3D.cs`:

```csharp
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ChatPanel3D : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform messageContainer;
    [SerializeField] private GameObject messageBubblePrefab;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button sendButton;
    
    [Header("Positioning")]
    [SerializeField] private Transform xrCamera;
    [SerializeField] private float distanceFromCamera = 2.0f;
    [SerializeField] private Vector3 offset = new Vector3(0.5f, -0.2f, 0);
    
    private string conversationId;
    private bool isProcessing = false;
    private List<GameObject> messageBubbles = new List<GameObject>();
    
    private void Start()
    {
        sendButton.onClick.AddListener(OnSendMessage);
        inputField.onSubmit.AddListener((_) => OnSendMessage());
        
        // Position panel in VR space
        PositionPanel();
    }
    
    private void PositionPanel()
    {
        if (xrCamera == null)
            xrCamera = Camera.main.transform;
            
        Vector3 targetPosition = xrCamera.position + 
                                 xrCamera.forward * distanceFromCamera + 
                                 offset;
        transform.position = targetPosition;
        transform.rotation = Quaternion.LookRotation(transform.position - xrCamera.position);
    }
    
    private async void OnSendMessage()
    {
        if (isProcessing || string.IsNullOrEmpty(inputField.text))
            return;
            
        string message = inputField.text;
        inputField.text = "";
        
        // Add user message
        AddMessage("You", message, Color.blue);
        
        isProcessing = true;
        
        try
        {
            // Show loading indicator
            AddMessage("Agent", "...", Color.gray);
            
            // Call API
            ChatResponse response = await AgentApi.Instance.SendMessage(message, conversationId);
            
            // Remove loading indicator
            RemoveLastMessage();
            
            // Add agent response
            AddMessage("Agent", response.message, Color.green);
            
            // Display sources if any
            if (response.sources != null && response.sources.Length > 0)
            {
                string sourcesText = "\n\nSources:\n";
                foreach (var source in response.sources)
                {
                    sourcesText += $"• {source.title} ({source.relevance:P0})\n";
                }
                AddMessage("Agent", sourcesText, Color.cyan);
            }
            
            conversationId = response.conversation_id;
        }
        catch (System.Exception ex)
        {
            RemoveLastMessage();
            AddMessage("Error", $"Failed to get response: {ex.Message}", Color.red);
        }
        finally
        {
            isProcessing = false;
        }
    }
    
    private void AddMessage(string sender, string message, Color color)
    {
        GameObject bubble = Instantiate(messageBubblePrefab, messageContainer);
        
        TextMeshProUGUI text = bubble.GetComponentInChildren<TextMeshProUGUI>();
        text.text = $"<b>{sender}:</b> {message}";
        text.color = color;
        
        messageBubbles.Add(bubble);
        
        // Scroll to bottom
        Canvas.ForceUpdateCanvases();
    }
    
    private void RemoveLastMessage()
    {
        if (messageBubbles.Count > 0)
        {
            GameObject last = messageBubbles[messageBubbles.Count - 1];
            messageBubbles.RemoveAt(messageBubbles.Count - 1);
            Destroy(last);
        }
    }
    
    // Update panel position to follow player gaze
    private void Update()
    {
        if (Vector3.Distance(transform.position, xrCamera.position) > distanceFromCamera + 1.0f)
        {
            PositionPanel();
        }
    }
}
```

**1.2 VR Keyboard Input (4-6 hours)**
- [ ] Add XR keyboard for VR text input
- [ ] Implement controller-based text input
- [ ] Add voice input button (optional)
- [ ] Test in VR headset

**1.3 Chat Prefab Creation (2-3 hours)**
- [ ] Create ChatPanel prefab with Canvas
- [ ] Create MessageBubble prefab
- [ ] Style UI for VR readability
- [ ] Add to MainScene

**1.4 Voice Input (Optional, 2-3 hours)**
- [ ] Integrate Windows Speech Recognition or other voice API
- [ ] Add microphone button to chat panel
- [ ] Convert speech to text
- [ ] Send to chat API

**Deliverables:**
- ✅ 3D floating chat panel in VR
- ✅ Functional text input
- ✅ Integration with AgentApi
- ✅ Message history display
- ✅ Source citations

---

### Sprint 2.2: VR Locomotion & Controls (2 weeks, 16-22 hours)

**Goal**: Implement smooth and comfortable VR navigation

#### Unity XR Locomotion Features

Unity's XR Interaction Toolkit provides built-in locomotion:

**1. Teleportation System (6-8 hours)**

```csharp
// Already provided by XR Interaction Toolkit
// Configure in XR Rig:
// - Add Teleportation Provider component
// - Add Teleportation Interactor to controllers
// - Create teleportation areas
```

- [ ] Configure Teleportation Provider on XR Origin
- [ ] Add Teleportation Interactors to controllers
- [ ] Create teleportation reticle
- [ ] Define valid teleportation areas
- [ ] Add visual feedback (arc, target marker)
- [ ] Test comfort settings

**2. Continuous Movement (6-8 hours)**

Create `Assets/Scripts/VR/ContinuousMovement.cs`:

```csharp
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    [SerializeField] private XRNode inputSource = XRNode.LeftHand;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float turnSpeed = 60.0f;
    [SerializeField] private float deadzone = 0.15f;
    
    [SerializeField] private Transform xrRig;
    [SerializeField] private Transform xrCamera;
    
    private InputDevice device;
    
    private void Update()
    {
        if (!device.isValid)
            device = InputDevices.GetDeviceAtXRNode(inputSource);
            
        // Get joystick input
        Vector2 inputAxis;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis))
        {
            if (inputAxis.magnitude > deadzone)
            {
                MovePlayer(inputAxis);
            }
        }
    }
    
    private void MovePlayer(Vector2 input)
    {
        // Calculate movement direction relative to camera
        Vector3 forward = xrCamera.forward;
        Vector3 right = xrCamera.right;
        
        // Keep movement horizontal
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        
        // Calculate movement vector
        Vector3 movement = (forward * input.y + right * input.x) * speed * Time.deltaTime;
        
        // Move the rig
        xrRig.position += movement;
    }
}
```

**3. NavMesh Integration (4-6 hours)**

Implement ground-level movement with Unity NavMesh:

```csharp
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    [SerializeField] private Transform xrRig;
    [SerializeField] private float heightOffset = 1.6f;  // Eye height
    
    private NavMeshAgent agent;
    
    private void Start()
    {
        // Bake NavMesh in scene
        // Window > AI > Navigation
    }
    
    private void Update()
    {
        // Constrain Y position to NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(xrRig.position, out hit, 2.0f, NavMesh.AllAreas))
        {
            Vector3 targetPosition = hit.position;
            targetPosition.y += heightOffset;
            
            xrRig.position = new Vector3(
                xrRig.position.x,
                targetPosition.y,
                xrRig.position.z
            );
        }
    }
}
```

**Tasks:**
- [ ] Implement teleportation system
- [ ] Implement continuous movement with thumbstick
- [ ] Add snap/smooth turning on right thumbstick
- [ ] Integrate NavMesh for floor constraints
- [ ] Add comfort options (vignette, snap turn)
- [ ] Test and tune for comfort
- [ ] Create locomotion settings UI

**Deliverables:**
- ✅ Teleportation working
- ✅ Continuous movement implemented
- ✅ NavMesh constrains movement
- ✅ Comfortable VR navigation

---

### Sprint 2.3: Document Visualization (2-3 weeks, 20-30 hours)

**Goal**: Display documents as 3D cards in VR space

#### Architecture

```
Document System
├── DocumentManager.cs            # Manage document data
├── DocumentCard3D.cs             # Individual document card
├── DocumentGrid.cs               # Layout manager
├── DocumentViewer.cs             # Full document reader
└── Prefabs/
    ├── DocumentCard.prefab       # Card with metadata
    └── DocumentPanel.prefab      # Full document view
```

#### Tasks

**3.1 Document Card (8-10 hours)**

Create `Assets/Scripts/Documents/DocumentCard3D.cs`:

```csharp
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class DocumentCard3D : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI authorsText;
    [SerializeField] private TextMeshProUGUI yearText;
    [SerializeField] private TextMeshProUGUI abstractText;
    [SerializeField] private MeshRenderer cardRenderer;
    
    [Header("Interaction")]
    [SerializeField] private XRSimpleInteractable interactable;
    
    private Document documentData;
    
    public void Initialize(Document doc)
    {
        documentData = doc;
        
        titleText.text = doc.title;
        authorsText.text = string.Join(", ", doc.authors);
        yearText.text = doc.year.ToString();
        abstractText.text = doc.@abstract.Substring(0, Mathf.Min(200, doc.@abstract.Length)) + "...";
        
        // Set up interaction
        interactable.selectEntered.AddListener(OnSelect);
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
    }
    
    private void OnSelect(SelectEnterEventArgs args)
    {
        // Open document viewer
        DocumentViewer.Instance.ShowDocument(documentData);
    }
    
    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        // Highlight card
        cardRenderer.material.SetColor("_EmissionColor", Color.blue * 0.5f);
    }
    
    private void OnHoverExit(HoverExitEventArgs args)
    {
        // Remove highlight
        cardRenderer.material.SetColor("_EmissionColor", Color.black);
    }
}
```

**3.2 Document Grid Layout (6-8 hours)**

Create `Assets/Scripts/Documents/DocumentGrid.cs`:

```csharp
using UnityEngine;
using System.Collections.Generic;

public class DocumentGrid : MonoBehaviour
{
    [SerializeField] private GameObject documentCardPrefab;
    [SerializeField] private Transform gridContainer;
    
    [Header("Layout")]
    [SerializeField] private float cardSpacing = 1.5f;
    [SerializeField] private int columns = 3;
    [SerializeField] private float arcRadius = 5.0f;
    [SerializeField] private LayoutMode layoutMode = LayoutMode.Grid;
    
    public enum LayoutMode
    {
        Grid,
        Arc,
        Timeline
    }
    
    private List<GameObject> cards = new List<GameObject>();
    
    public void DisplayDocuments(Document[] documents)
    {
        ClearCards();
        
        for (int i = 0; i < documents.Length; i++)
        {
            GameObject card = Instantiate(documentCardPrefab, gridContainer);
            card.GetComponent<DocumentCard3D>().Initialize(documents[i]);
            
            // Position card
            card.transform.localPosition = CalculateCardPosition(i);
            card.transform.localRotation = CalculateCardRotation(i);
            
            cards.Add(card);
        }
    }
    
    private Vector3 CalculateCardPosition(int index)
    {
        switch (layoutMode)
        {
            case LayoutMode.Grid:
                return GridPosition(index);
            case LayoutMode.Arc:
                return ArcPosition(index);
            case LayoutMode.Timeline:
                return TimelinePosition(index);
            default:
                return Vector3.zero;
        }
    }
    
    private Vector3 GridPosition(int index)
    {
        int row = index / columns;
        int col = index % columns;
        
        return new Vector3(
            col * cardSpacing - (columns * cardSpacing / 2),
            -row * cardSpacing,
            0
        );
    }
    
    private Vector3 ArcPosition(int index)
    {
        float angle = (index - cards.Count / 2.0f) * 30f;
        float radians = angle * Mathf.Deg2Rad;
        
        return new Vector3(
            Mathf.Sin(radians) * arcRadius,
            0,
            arcRadius - Mathf.Cos(radians) * arcRadius
        );
    }
    
    private Vector3 TimelinePosition(int index)
    {
        // Position by year
        return new Vector3(index * cardSpacing, 0, 0);
    }
    
    private Quaternion CalculateCardRotation(int index)
    {
        if (layoutMode == LayoutMode.Arc)
        {
            // Face player
            return Quaternion.LookRotation(Vector3.forward);
        }
        return Quaternion.identity;
    }
    
    private void ClearCards()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }
}
```

**3.3 Document Viewer (6-8 hours)**
- [ ] Create full-screen document reader
- [ ] Add page navigation
- [ ] Implement zoom/pan
- [ ] Add annotation tools (optional)
- [ ] Test readability in VR

**3.4 Search Integration (4-6 hours)**
- [ ] Add search bar above document grid
- [ ] Connect to DocumentApi
- [ ] Filter and sort documents
- [ ] Display search results

**Deliverables:**
- ✅ Document cards display in 3D
- ✅ Multiple layout modes (grid, arc, timeline)
- ✅ Interactive card selection
- ✅ Full document viewer
- ✅ Search functionality

---

## Phase 3: Advanced Features (8-12 weeks)

### Data Visualization

**Keyword Trends (10-14 hours)**
- Unity UI Toolkit with charts
- Or TextMesh Pro + custom mesh generation
- Or integrate third-party charting library

**Word Clouds (8-10 hours)**
- Generate word cloud texture
- Display on 3D plane
- Interactive word selection

### DICOM Medical Imaging (38-54 hours)

**Unity DICOM Libraries:**
- fo-dicom for C# DICOM parsing
- Volume rendering with compute shaders
- Slice viewers with Unity UI

**Implementation:**
- [ ] Install fo-dicom NuGet package
- [ ] Create DICOM parser
- [ ] Implement 2D slice viewer
- [ ] Implement 3D volume rendering
- [ ] Add measurement tools
- [ ] VR interaction with volumes

### Performance Optimization (12-16 hours)

**Unity-Specific Optimizations:**
- LOD groups for documents
- Occlusion culling
- GPU instancing for cards
- Texture atlasing
- Mesh combining
- Async loading
- Object pooling

**Target Performance:**
- 90 FPS on Quest 2
- 120 FPS on Quest 3
- Draw calls < 100
- Memory < 1GB

---

## Phase 4: Testing & Polish (4-6 weeks)

### Unity Testing Framework

**PlayMode Tests:**
```csharp
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class ApiClientTests
{
    [UnityTest]
    public IEnumerator TestAgentChat()
    {
        // Setup
        var apiClient = new GameObject().AddComponent<ApiClient>();
        
        // Test
        var task = AgentApi.Instance.SendMessage("Hello");
        yield return new WaitUntil(() => task.IsCompleted);
        
        // Assert
        Assert.IsNotNull(task.Result);
        Assert.IsNotEmpty(task.Result.message);
    }
}
```

**EditMode Tests:**
- Test data models
- Test utility functions
- Test without Play mode

### Build Pipeline

**Automated Builds:**
- [ ] Create Unity Build script
- [ ] CI/CD with Unity Cloud Build or GitHub Actions
- [ ] Automated testing on commits
- [ ] Version management

**Platform-Specific:**
- Android APK for Quest
- Windows EXE for SteamVR
- Separate debug/release builds

---

## Key Differences Summary

### Unity Advantages
- **Performance**: Native rendering, 90+ FPS
- **Offline**: Full offline capability
- **Features**: Access to full Unity ecosystem
- **Distribution**: App stores, enterprise

### Unity Challenges
- **Build Size**: Larger than web (~100 MB vs ~10 MB)
- **Updates**: Requires app update (vs hot reload)
- **Platform**: Must build separately for Quest/PC
- **Development**: C# vs TypeScript learning curve

### When to Use Unity vs Babylon
- **Unity**: Native VR apps, Quest store, offline, performance-critical
- **Babylon**: Quick prototypes, web access, easy updates, broader reach

---

## Next Steps

1. **Immediate**: Set up Unity project and XR Toolkit
2. **Week 1**: Complete API client implementation
3. **Week 2**: Build VR chat interface
4. **Week 3**: Document visualization
5. **Month 2+**: Advanced features per roadmap

---

**Document Status**: Complete  
**Last Updated**: November 7, 2025  
**Ready for**: Development kickoff
