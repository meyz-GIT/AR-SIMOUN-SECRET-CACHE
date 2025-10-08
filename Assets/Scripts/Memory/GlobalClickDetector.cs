using UnityEngine;
using UnityEngine.EventSystems; // Required for checking UI interaction

/// <summary>
/// This script detects clicks/taps anywhere on the screen (not just buttons)
/// and tells the SFX Manager to play a sound, unless the click was on UI.
/// </summary>
public class GlobalClickDetector : MonoBehaviour
{
    private SFXManager sfxManager;

    private void Start()
    {
        // Get the persistent manager instance once at the start
        sfxManager = SFXManager.Instance;
        if (sfxManager == null)
        {
            Debug.LogError("GlobalClickDetector requires SFXManager.Instance to be present in the scene!");
        }
    }

    void Update()
    {
        // Check for mouse click (used for desktop/editor testing) or first finger tap
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                // IMPORTANT: Temporarily remove this check to see if the sound plays
                /* if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                */

                // If the sound plays now, the issue is that the EventSystem.current.IsPointerOverGameObject() 
                // is always returning TRUE, possibly due to a full-screen image behind your menu.
                PlayScreenClickSFX();
            }
        }
    }

    private void PlayScreenClickSFX()
    {
        if (sfxManager != null)
        {
            // Tell the persistent manager to play the default SFX
            sfxManager.PlayGlobalClickSFX();
        }
    }
}
