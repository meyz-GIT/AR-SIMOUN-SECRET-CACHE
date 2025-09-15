using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Memory : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        //write
        /*PlayerData playerData = new PlayerData();
        playerData.level = 0;

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
        */

        //reading json file
        string jsonfile = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(jsonfile);
        Debug.Log(loadedPlayerData.level);
        
        //get loaded scene name
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        //with progress = MainMenu, without progress = StartingMenu
        if (sceneName.Equals("MainMenu"))
        {
            if (loadedPlayerData.level == 0)
            {
                SceneManager.LoadScene("StartingMenu");
            }
        } else if (sceneName.Equals("StartingMenu"))
        {
            if (loadedPlayerData.level > 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }


    }
    

    private class PlayerData
    {
        public int level;
    }


    void UpdateGameLevel()
    {
        PlayerData data;
        filePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read the existing JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<PlayerData>(jsonString);
        }
        else
        {
            // If the file doesn't exist, create a new MyData object with default values
            data = new PlayerData();
            data.level = 0;
        }

        // Modify the desired data
        data.level++;

        // Convert the updated data object back to a JSON string
        string updatedJson = JsonUtility.ToJson(data, true); // 'true' for pretty printing

        // Write the updated JSON string back to the file
        File.WriteAllText(filePath, updatedJson);

        Debug.Log("JSON file updated successfully!");
    }
}
