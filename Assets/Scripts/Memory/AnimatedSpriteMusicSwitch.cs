using UnityEngine;
using System.Collections;

/// <summary>
/// Handles the visual and interactive logic for the 2D music switch with sliding animation.
/// Controls the movement of a child object (the handle) between ON and OFF positions.
/// Requires a 2D Collider on the parent object (this script) to detect clicks.
/// </summary>
[RequireComponent(typeof(Collider2D))] // Must have a 2D collider for OnMouseDown
public class AnimatedSpriteMusicSwitch : MonoBehaviour
{
    // Assign the child GameObject (the circle image) that slides.
    [Tooltip("The Transform of the circle/handle sprite that slides.")]
    public Transform handleTransform;

    // Define the local X positions for the ON and OFF states. These must be set
    // in the Inspector based on the size of your oblong background image.
    [Header("Handle Positions (Local X)")]
    [Tooltip("The local X position when the switch is ON (music playing).")]
    public float onPositionX = 0.5f;
    [Tooltip("The local X position when the switch is OFF (music muted).")]
    public float offPositionX = -0.5f;

    [Header("Animation Settings")]
    [Tooltip("Time in seconds for the handle to slide.")]
    public float animationDuration = 0.15f;

    private bool isMuted = false;

    private void Start()
    {
        if (handleTransform == null)
        {
            Debug.LogError("Handle Transform is not assigned on the Music Switch Parent! Please assign the circular handle child object in the Inspector.");
            return;
        }

        // Check if the MusicManager is available and get the saved state
        if (ManagerMusic.Instance != null)
        {
            isMuted = ManagerMusic.Instance.IsMuted();
        }

        // Immediately snap the handle to the correct saved position upon loading
        float targetX = isMuted ? offPositionX : onPositionX;
        handleTransform.localPosition = new Vector3(targetX, handleTransform.localPosition.y, handleTransform.localPosition.z);
    }

    /// <summary>
    /// Called automatically by Unity when the mouse is clicked over the 2D Collider.
    /// </summary>
    private void OnMouseDown()
    {
        if (handleTransform == null || ManagerMusic.Instance == null) return;

        // 1. Toggle the internal state
        isMuted = !isMuted;

        // 2. Call the Manager to update audio and save the preference
        ManagerMusic.Instance.ToggleMusic(isMuted);

        // 3. Animate the handle to the new position
        StopAllCoroutines(); // Stop any movement currently running
        StartCoroutine(AnimateHandle(isMuted));
    }

    /// <summary>
    /// Coroutine for smooth movement of the handle.
    /// </summary>
    private IEnumerator AnimateHandle(bool targetIsMuted)
    {
        float targetX = targetIsMuted ? offPositionX : onPositionX;
        Vector3 startPosition = handleTransform.localPosition;
        Vector3 targetPosition = new Vector3(targetX, startPosition.y, startPosition.z);

        float time = 0;

        while (time < animationDuration)
        {
            // Linear interpolation (Lerp) for smooth movement
            handleTransform.localPosition = Vector3.Lerp(startPosition, targetPosition, time / animationDuration);
            time += Time.deltaTime;
            yield return null; // Wait until next frame
        }

        // Ensure it snaps exactly to the final position
        handleTransform.localPosition = targetPosition;
    }
}
