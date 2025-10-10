using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class PauseManager : MonoBehaviour
{
    [SerializeField] private XROrigin xrOrigin;

    private ARCameraManager arCameraManager;

    private bool isPaused = false;

    void Start()
    {
        // Safety check
        if (xrOrigin == null)
        {
            Debug.LogError("XR Origin not assigned to PauseManager!");
            return;
        }

        // The ARCameraManager is usually on the Camera component within the XROrigin
        arCameraManager = xrOrigin.GetComponentInChildren<ARCameraManager>();

        if (arCameraManager == null)
        {
            Debug.LogError("AR Camera Manager not found on XR Origin children!");
        }
    }

    // This function will be called by your UI Button
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGameAndAR();
        }
        else
        {
            ResumeGameAndAR();
        }
    }

    private void PauseGameAndAR()
    {
        // 1. Freeze game logic (Optional, but standard for pausing)
        Time.timeScale = 0f;
        Debug.Log("Game Paused");

        // 2. Freeze the AR Camera Feed and Tracking
        if (arCameraManager != null)
        {
            // Disabling the ARCameraManager freezes the video background and tracking updates
            arCameraManager.enabled = false;
        }
    }

    private void ResumeGameAndAR()
    {
        // 1. Unfreeze the AR Camera Feed and Tracking first
        if (arCameraManager != null)
        {
            arCameraManager.enabled = true;
        }

        // 2. Unfreeze game logic
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }
}