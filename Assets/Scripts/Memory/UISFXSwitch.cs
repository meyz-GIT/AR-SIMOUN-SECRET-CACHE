using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the UI representation of the SFX switch.
/// It calls the persistent SFXManager on click.
/// </summary>
public class UISFXSwitch : MonoBehaviour
{
    // All UI and animation parameters remain the same, controlling the visual slide.
    [Tooltip("The RectTransform of the circular handle image.")]
    public RectTransform handleRectTransform;

    [Header("Handle Positions (Local X)")]
    public float onPositionX = 60f;
    public float offPositionX = -60f;

    [Header("Animation Settings")]
    public float animationDuration = 0.15f;

    private bool isMuted = false;
    private bool isInitialized = false;

    private SFXManager sfxManagerInstance;

    private void Start()
    {
        StartCoroutine(DelayedInitialization());
    }

    private IEnumerator DelayedInitialization()
    {
        yield return null;

        sfxManagerInstance = SFXManager.Instance;

        if (handleRectTransform == null)
        {
            Debug.LogError("Handle RectTransform is not assigned! Switch disabled.");
            yield break;
        }

        // 1. Get the saved state from the persistent manager
        if (sfxManagerInstance != null)
        {
            isMuted = sfxManagerInstance.IsMuted();
        }
        else
        {
            Debug.LogWarning("SFXManager.Instance not found. Assuming UNMUTED state.");
            isMuted = false;
        }

        // 2. Snap the handle to the correct saved position
        float targetX = isMuted ? offPositionX : onPositionX;
        handleRectTransform.anchoredPosition = new Vector2(targetX, handleRectTransform.anchoredPosition.y);

        isInitialized = true;
    }

    /// <summary>
    /// Called by the UI Button's OnClick() event.
    /// </summary>
    public void OnSwitchClicked()
    {
        if (!isInitialized) return;

        // 1. Toggle the internal state
        isMuted = !isMuted;

        // 2. Call the SFX Manager to update audio and save the preference
        if (sfxManagerInstance != null)
        {
            sfxManagerInstance.ToggleSFX(isMuted);
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
