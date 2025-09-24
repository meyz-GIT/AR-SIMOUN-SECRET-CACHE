using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadJSON : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        TextAsset jsonTextAsset = Resources.Load<TextAsset>("PlayerData");

        if (jsonTextAsset != null)
        {
            // Get the JSON content as a string
            string jsonString = jsonTextAsset.text;

            // Now you can parse this string using Unity's JsonUtility or
            // a third-party library like Newtonsoft.Json
            Debug.Log("Successfully read JSON file on Android: " + jsonString);

            // Example: Parse the JSON string
            // MyData data = JsonUtility.FromJson<MyData>(jsonString);
        }
        else
        {
            Debug.LogError("JSON file not found! Make sure it's in a 'Resources' folder and named 'mydata' (without the extension).");
        }*/


        private string fileName = "PlayerData.json";
    private string filePath;

    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, fileName);
        Debug.Log("eto sa awake: " + filePath);
    }

    public string LoadData()
    {
        // Check if the modifiable file exists
        if (!File.Exists(filePath))
        {
            // If not, this is the first run. Load the default from Resources.
            Debug.Log("No save file found. Loading default from Resources.");
            TextAsset defaultData = Resources.Load<TextAsset>(Path.GetFileNameWithoutExtension(fileName));

            if (defaultData != null)
            {
                // Copy the default data to the persistent path
                File.WriteAllText(filePath, defaultData.text);
                return defaultData.text;
            }
            else
            {
                Debug.LogError("Default file not found in Resources!");
                return null;
            }
        }
        else
        {
            // If the file exists, load it from the persistent path.
            string content = File.ReadAllText(filePath);
            Debug.Log("Loading data from save file: " + content);
            
            return File.ReadAllText(filePath);
        }
    }

    public void SaveData(string dataToSave)
    {
        // Save the new data to the persistent path
        File.WriteAllText(filePath, dataToSave);
        Debug.Log("Data saved successfully!");
    }
}

    