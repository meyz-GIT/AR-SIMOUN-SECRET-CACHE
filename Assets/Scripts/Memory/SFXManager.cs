using UnityEngine;
using System.Collections;

/// <summary>
/// A persistent singleton to manage sound effects volume and playback.
/// This manager relies on the AudioListener's volume for muting/unmuting 
/// the entire SFX category, which is preserved across scenes.
/// </summary>
public class SFXManager : MonoBehaviour
{
    // Public static property for easy, consistent access
    public static SFXManager Instance { get; private set; }

    [Tooltip("The default sound clip to play when the Global Click Detector is activated.")]
    public AudioClip globalClickSFX;

    // AudioSource component used to play one-shot sound effects
    private AudioSource sfxAudioSource;

    // PlayerPrefs key for saving the SFX mute state (1 = muted, 0 = unmuted).
    private const string MuteKey = "SFXIsMuted";

    private void Awake()
    {
        // --- 1. Robust Singleton Setup ---
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Get the AudioSource or add one if missing.
            sfxAudioSource = GetComponent<AudioSource>();
            if (sfxAudioSource == null)
            {
                sfxAudioSource = gameObject.AddComponent<AudioSource>();
            }

            // SFX AudioSource settings:
            sfxAudioSource.playOnAwake = false; // Never play automatically
            sfxAudioSource.loop = false;       // Never loop
            sfxAudioSource.volume = 1f;        // Keep local volume high

            // 2. Initialize the master volume state
            LoadSFXState();
        }
        else
        {
            // Destroy this object if another SFXManager already exists.
            Destroy(gameObject);
        }
    }

    private void LoadSFXState()
    {
        // Default value is 0 (false/unmuted) if the key doesn't exist.
        bool isMuted = PlayerPrefs.GetInt(MuteKey, 0) == 1;

        // AudioListener.volume controls ALL sound. 
        sfxAudioSource.volume = isMuted ? 0f : 1f;
    }

    public void ToggleSFX(bool isMuted)
    {
        // Set the global volume.
        sfxAudioSource.volume = isMuted ? 0f : 1f;

        // Save the new state: 1 for muted, 0 for unmuted.
        PlayerPrefs.SetInt(MuteKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void PlayGlobalClickSFX()
    {
        PlaySFX(globalClickSFX);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxAudioSource != null)
        {
            // PlayOneShot allows multiple SFX to overlap without stopping the previous one.
            sfxAudioSource.PlayOneShot(clip);
        }
    }

    public bool IsMuted()
    {
        return PlayerPrefs.GetInt(MuteKey, 0) == 1;
    }
}
