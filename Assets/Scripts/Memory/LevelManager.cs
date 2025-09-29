using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // --- STATIC SINGLETON INSTANCE ---
    public static LevelManager Instance { get; private set; }

    // --- PRIVATE DATA ---
    // Key used to store and retrieve the level number in PlayerPrefs
    private const string LevelKey = "GameLevelProgress";

    // In-memory representation of the current level (defaulting to 1)
    private int currentLevelNumber = 1;

    // --- UNITY LIFECYCLE ---

    private void Awake()
    {
        // 1. Singleton Enforcement and Persistence
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // 2. Load the saved data immediately using PlayerPrefs
        LoadSavedLevelData();
    }

    // --- PUBLIC ACCESSORS AND MUTATORS ---

    // Retrieves the current unlocked level from memory.
    public int getCurrentLevel()
    {
        return currentLevelNumber;
    }

    // Increments the level number in memory.
    public void AddLevelData()
    {
        currentLevelNumber++;
        Debug.Log("Updated the level to: " + currentLevelNumber);
    }

    // Resets the level to 1 in memory.
    public void ResetLevelData()
    {
        currentLevelNumber = 1;
        Debug.Log("Reset the level to: " + currentLevelNumber);
    }

    // --- SAVE/LOAD IMPLEMENTATION (PlayerPrefs) ---

    public void SaveLevelData()
    {
        // 1. Set the integer value to be saved
        PlayerPrefs.SetInt(LevelKey, currentLevelNumber);

        // 2. Write the data to the device's disk (CRITICAL step for mobile)
        PlayerPrefs.Save();

        Debug.Log($"Level Saved successfully via PlayerPrefs: {currentLevelNumber}");
    }

    public void LoadSavedLevelData()
    {
        // PlayerPrefs.GetInt(key, defaultValue)
        // It retrieves the stored value. If the key doesn't exist (first run), 
        // it returns the specified default value (1).
        currentLevelNumber = PlayerPrefs.GetInt(LevelKey, 1);

        Debug.Log($"Level Loaded successfully via PlayerPrefs: {currentLevelNumber}");
    }

    // --- The unnecessary JSON/File I/O methods (LoadLevelData, SaveLevelData, etc.) are removed ---

    // Note: The [System.Serializable] LevelData class is also no longer needed 
    // since we're saving a direct integer.
}