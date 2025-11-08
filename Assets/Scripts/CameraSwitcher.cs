using UnityEngine;

public class XRPlatformSwitcher : MonoBehaviour
{
    public GameObject arSession;
    public MonoBehaviour arCameraManager;
    public MonoBehaviour arBackground;

    void Awake()
    {
#if UNITY_EDITOR
        if (arSession) arSession.SetActive(false);
        if (arCameraManager) arCameraManager.enabled = false;
        if (arBackground) arBackground.enabled = false;
#else
        if (arSession) arSession.SetActive(true);
        if (arCameraManager) arCameraManager.enabled = true;
        if (arBackground) arBackground.enabled = true;
#endif
    }
}

