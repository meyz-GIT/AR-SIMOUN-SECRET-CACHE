using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private ARSession arSession;

    [SerializeField] private ArPositioner arPositioner; 

    private bool isPaused = false;

    void Start()
    {
        if (arSession == null)
        {
            Debug.LogError("AR Session not assigned to PauseManager!");
        }
        if (arPositioner == null)
        {
            Debug.LogError("Ar Positioner not assigned to PauseManager!");
        }
    }
    
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
        Time.timeScale = 0f;
        Debug.Log("Game Paused: Freezing AR Session.");

        if (arSession != null)
        {
            arSession.enabled = false; // Stops all AR tracking and camera updates
        }
    }


    private void ResumeGameAndAR()
    {
        if (arSession != null)
        {
            arSession.enabled = true; 
        }

        
        if (arPositioner != null && arPositioner.hasplaced)
        {
            arPositioner.planeManager.enabled = false;
            foreach (var p in arPositioner.planeManager.trackables)
            {
                p.gameObject.SetActive(false);
            }
            Debug.Log("Planes re-hidden after resuming AR Session.");
        }

        Time.timeScale = 1f;
        Debug.Log("Game Resumed.");
    }
}