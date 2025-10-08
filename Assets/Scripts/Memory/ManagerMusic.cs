using UnityEngine;

/// <summary>
/// A persistent singleton that manages the background music state across all scenes.
/// It saves the user's music preference using PlayerPrefs.
/// Requires an AudioSource component.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class ManagerMusic : MonoBehaviour
{
    // Static instance allows easy access from any other script (Singleton).
    public static ManagerMusic Instance { get; private set; }

    // Reference to the AudioSource component on this GameObject.
    private AudioSource musicAudioSource;

    // PlayerPrefs key for saving the music mute state (1 = muted, 0 = unmuted).
    private const string MuteKey = "MusicIsMuted";

    private void Awake()
    {
        // --- 1. Singleton Setup: Ensure only one instance exists ---
        if (Instance == null)
        {
            Instance = this;
            // IMPORTANT: Keeps this object active across scene loads.
            DontDestroyOnLoad(gameObject);

            // Get the AudioSource component
            musicAudioSource = GetComponent<AudioSource>();

            // 2. Initialize the state based on saved preference
            LoadMusicState();

            // 3. Start playback if the music is not muted
            if (!IsMuted())
            {
                musicAudioSource.loop = true; // Ensure the music loops indefinitely
                musicAudioSource.Play();
            }
        }
        else
        {
            // Destroy this object if another MusicManager already exists.
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Loads the mute preference from PlayerPrefs and applies it.
    /// </summary>
    private void LoadMusicState()
    {
        // Default value is 0 (false/unmuted) if the key doesn't exist.
        bool isMuted = PlayerPrefs.GetInt(MuteKey, 0) == 1;
        musicAudioSource.mute = isMuted;
    }

    /// <summary>
    /// Toggles the music state (mute/unmute) and saves the preference.
    /// This is called by the 2D switch interaction script.
    /// </summary>
    /// <param name="isMuted">True to mute the music, False to unmute it.</param>
    public void ToggleMusic(bool isMuted)
    {
        musicAudioSource.mute = isMuted;

        // Save the new state: 1 for muted, 0 for unmuted.
        PlayerPrefs.SetInt(MuteKey, isMuted ? 1 : 0);
        PlayerPrefs.Save(); // Ensure the preference is written to disk

        // Ensure the audio is playing if we just unmuted it and it was previously stopped.
        if (!isMuted && !musicAudioSource.isPlaying)
        {
            musicAudioSource.Play();
        }
    }

    /// <summary>
    /// Returns the current mute status (True if muted, False if playing).
    /// </summary>
    public bool IsMuted()
    {
        return PlayerPrefs.GetInt(MuteKey, 0) == 1;
    }
}
