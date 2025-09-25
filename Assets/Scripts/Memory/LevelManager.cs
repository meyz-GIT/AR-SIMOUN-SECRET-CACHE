using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private const string levelFileName = "PlayerData.json";
    private string filePath;
    public LevelData currentLevelData;
    //public TextMeshProUGUI awakeLevel;

    private void Start()
    {
        // On Android, use a streaming assets path for read-only files.
        // For writing, you would use Application.persistentDataPath.
        filePath = Path.Combine(Application.streamingAssetsPath, levelFileName);

        StartCoroutine(LoadLevelData());
        LoadSavedLevelData();
    }

    private IEnumerator LoadLevelData()
    {
        string jsonString = "";

        // Check if the application is running on an Android device
        if (Application.platform == RuntimePlatform.Android)
        {
            // Use UnityWebRequest for Android as files are inside the .apk
            using (UnityWebRequest www = UnityWebRequest.Get(filePath))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    jsonString = www.downloadHandler.text;
                }
                else
                {
                    Debug.LogError("Failed to read JSON file from StreamingAssets: " + www.error);
                    yield break;
                }
            }
        }
        else
        {
            // Use standard file I/O for editor and other platforms
            if (File.Exists(filePath))
            {
                jsonString = File.ReadAllText(filePath);
            }
            else
            {
                Debug.LogError("JSON file not found at " + filePath);
                yield break;
            }
        }

        // Now that we have the JSON string, proceed with deserialization
        DeserializeLevel(jsonString);
    }

    private void DeserializeLevel(string jsonString)
    {
        // Check if the JSON string is not empty
        if (string.IsNullOrEmpty(jsonString))
        {
            Debug.LogError("JSON string is null or empty.");
            return;
        }

        // Deserialize the JSON string into our C# object
        currentLevelData = JsonUtility.FromJson<LevelData>(jsonString);

        if (currentLevelData != null)
        {
            Debug.Log("Successfully loaded level: " + currentLevelData.levelNumber);
            // You can now access and manipulate the data
            Debug.Log("Level: " + currentLevelData.levelNumber);
            //awakeLevel.text = currentLevelData.levelNumber+"";
        }
        else
        {
            Debug.LogError("Failed to deserialize JSON data.");
        }
    }


    public void AddLevelData()
    {
        if (currentLevelData != null)
        {
            // Access and modify the data
            currentLevelData.levelNumber++;
            Debug.Log("Updated the level to: " + currentLevelData.levelNumber);
        }
    }

    public void ResetLevelData()
    {
        if (currentLevelData != null)
        {
            // Access and modify the data
            currentLevelData.levelNumber = 1;
            Debug.Log("Updated the level to: " + currentLevelData.levelNumber);
        }
    }

    public void SaveLevelData()
    {
        // Serialize the C# object back to a JSON string
        string jsonString = JsonUtility.ToJson(currentLevelData, true); // `true` for pretty printing

        // Define the save path for the persistent data
        string savePath = Path.Combine(Application.persistentDataPath, levelFileName);

        // Write the JSON string to a file
        try
        {
            File.WriteAllText(savePath, jsonString);
            Debug.Log("Successfully saved level data to: " + savePath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to save level data: " + ex.Message);
        }
    }

    public void LoadSavedLevelData()
    {
        string savePath = Path.Combine(Application.persistentDataPath, levelFileName);

        if (File.Exists(savePath))
        {
            try
            {
                string jsonString = File.ReadAllText(savePath);
                DeserializeLevel(jsonString);
                Debug.Log("Successfully loaded saved level data.");
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Failed to load saved level data: " + ex.Message);
            }
        }
        else
        {
            Debug.Log("No saved data found. Loading from original levels.json.");
            // Fallback to loading from StreamingAssets
            StartCoroutine(LoadLevelData());
        }
    }

    public int getCurrentLevel()
    {
        LoadSavedLevelData();
        return currentLevelData.levelNumber;
    }
}

