using UnityEngine;
using UnityEngine.UI; // Needed for UI components
using System.Collections; // Needed for coroutines

/// <summary>
/// Controls the UI representation of the music switch (oblong background and sliding handle).
/// Called by the UI Button component on click.
/// </summary>
public class UIMusicSwitch : MonoBehaviour
{
    [Tooltip("The RectTransform of the circular handle image.")]
    public RectTransform handleRectTransform;

    [Header("Handle Positions (Local X)")]
    // Note: These values will be much larger in Canvas RectTransforms than in World Space!
    public float onPositionX = 60f;
    public float offPositionX = -60f;

    [Header("Animation Settings")]
    public float animationDuration = 0.15f;

    private bool isMuted = false;
    private bool isInitialized = false;

    // We only need the reference to the Manager, not the complex Find logic.
    private ManagerMusic musicManagerInstance;

    private void Start()
    {
        // Use a short delay to ensure the persistent MusicManager has loaded its state.
        StartCoroutine(DelayedInitialization());
    }

    private IEnumerator DelayedInitialization()
    {
        // Wait one frame to ensure persistent objects are ready
        yield return null;

        musicManagerInstance = ManagerMusic.Instance;

        if (handleRectTransform == null)
        {
            Debug.LogError("Handle RectTransform is not assigned! Switch disabled.");
            yield break;
        }

        // 1. Get the saved state from the persistent manager
        if (musicManagerInstance != null)
        {
            isMuted = musicManagerInstance.IsMuted();
        }
        else
        {
            Debug.LogWarning("MusicManager.Instance not found. Assuming UNMUTED state.");
            isMuted = false;
        }

        // 2. Snap the handle to the correct saved position
        float targetX = isMuted ? offPositionX : onPositionX;
        handleRectTransform.anchoredPosition = new Vector2(targetX, handleRectTransform.anchoredPosition.y);

        isInitialized = true;
    }

    /// <summary>
    /// This public function is called by the UI Button's OnClick() event.
    /// </summary>
    public void OnSwitchClicked()
    {
        if (!isInitialized) return;

        // 1. Toggle the internal state
        isMuted = !isMuted;

        // 2. Call the Manager to update audio and save the preference
        if (musicManagerInstance != null)
        {
            musicManagerInstance.ToggleMusic(isMuted);
        }

        // 3. Animate the handle to the new position
        StopAllCoroutines();
        StartCoroutine(AnimateHandle(isMuted));
    }

    private IEnumerator AnimateHandle(bool targetIsMuted)
    {
        float targetX = targetIsMuted ? offPositionX : onPositionX;
        Vector2 startPosition = handleRectTransform.anchoredPosition;
        Vector2 targetPosition = new Vector2(targetX, startPosition.y);

        float time = 0;

        while (time < animationDuration)
        {
            handleRectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, time / animationDuration);
            time += Time.deltaTime;
            yield return null;
        }

        handleRectTransform.anchoredPosition = targetPosition;
    }
}
