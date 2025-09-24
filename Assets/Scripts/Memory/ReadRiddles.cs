using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReadRiddles : MonoBehaviour
{
    /*
        // Assign in the Unity Inspector
    public TextMeshProUGUI riddleText;
    public TextMeshProUGUI firstWordText;
    public Button nextButton;
    public TextAsset jsonFile;

    private string[] lines;
    private int currentIndex = 0;

    void Start()
    {
        // Check if the JSON file is assigned
        if (jsonFile == null)
        {
            Debug.LogError("JSON file is not assigned to the script.");
            return;
        }

        // Read the file and split into lines, removing any empty lines
        lines = jsonFile.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        // Add a listener to the button to trigger the display of the next line
        nextButton.onClick.AddListener(DisplayNextRiddle);

        // Display the first riddle upon starting
        if (lines.Length > 0)
        {
            DisplayRiddle(currentIndex);
        }
    }

    void DisplayNextRiddle()
    {
        // Move to the next index, wrapping around to 0 if at the end of the array
        currentIndex = (currentIndex + 1) % lines.Length;
        DisplayRiddle(currentIndex);
    }

    void DisplayRiddle(int index)
    {
        // Ensure the index is valid
        if (index < 0 || index >= lines.Length)
        {
            return;
        }

        string fullLine = lines[index];
        string[] words = fullLine.Split(' ');

        if (words.Length > 1)
        {
            // The first word is displayed in the firstWordText object
            firstWordText.text = words[0];

            // The rest of the line is displayed in the riddleText object
            // Join the remaining words back together with spaces
            string remainingRiddle = string.Join(" ", words, 1, words.Length - 1);
            riddleText.text = remainingRiddle;
        }
        else
        {
            // If there's only one word or the line is empty, clear both text objects
            firstWordText.text = "";
            riddleText.text = fullLine;
        }
    }
    
     
Ship I have a deck, but I'm not a card game. I'm made of steel, but I can float. What am I? 
RubberDuck I quack, but I'm not a frog. I have feathers, but I'm not a chicken. I can swim, but I'm not a fish. What am I? 
DeepPan I get hot when I'm on the fire, but I don't feel pain. I have a belly and a handle, but no arms or legs. What am I? 
Beer I can be bitter or sweet. I'm often a golden color and served cold in a glass. People raise a toast to me. What am I? 
Rock I'm hard and gray, and you can find me anywhere. I'm older than you, but I don't have a birthday. What am I? 
Money I can be earned, but I can't be bought. I can be spent, but I can't be used. What am I?
 
*/

    public TextMeshProUGUI riddleText, firstWordText, winMessage, answer, message;
    public Button nextButton;
    public TextAsset jsonFile;
    public GameObject confirmationPanel, riddleBookPanel, pausePanel;
    public string sceneName;

    // Change from array to a List for easy removal
    private List<string> riddles;
    private int currentIndex = 0;

    void Start()
    {
        if (jsonFile == null)
        {
            Debug.LogError("JSON file is not assigned to the script.");
            return;
        }

        // Read the file and put lines into a list
        riddles = new List<string>(jsonFile.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries));

        nextButton.onClick.AddListener(DisplayNextRiddle);

        if (riddles.Count > 0)
        {
            DisplayRiddle(currentIndex);
        }
    }

    void DisplayNextRiddle()
    {
        // Wrap around if all riddles are completed
        if (riddles.Count == 0)
        {
            confirmationPanel.SetActive(true);
            winMessage.SetText("You've solved all the riddles!");
            riddleText.text = "You've solved all the riddles!";
            firstWordText.text = "";
            return;
        }
        
        // Move to the next index, wrapping around
        currentIndex = (currentIndex + 1) % riddles.Count;
        DisplayRiddle(currentIndex);
    }

    // Public method to be called by other scripts
    public void RemoveCurrentRiddle()
    {
        if (riddles.Count > 0)
        {
            // Remove the riddle from the list
            riddles.RemoveAt(currentIndex);

            // Adjust the index if the last riddle was removed to prevent out of bounds error
            if (currentIndex >= riddles.Count)
            {
                currentIndex = 0;
            }

            // Display the next riddle
            DisplayNextRiddle();
        }
    }

    void DisplayRiddle(int index)
    {
        if (riddles.Count == 0 || index < 0 || index >= riddles.Count)
        {
            
            return;
        }

        if (riddles.Count == 1)
        {
            nextButton.gameObject.SetActive(false);
        }

        string fullLine = riddles[index];
        string[] words = fullLine.Split(' ');

        if (words.Length > 1)
        {
            firstWordText.text = words[0];
            string remainingRiddle = string.Join(" ", words, 1, words.Length - 1);
            riddleText.text = remainingRiddle;
        }
        else
        {
            firstWordText.text = "";
            riddleText.text = fullLine;
        }
    }

    public void playAnimation()
    {
        if (riddles.Count == 0)
        {
            /*//reading json file
            string path = Path.Combine(Application.persistentDataPath, "PlayerData.json");
            string jsonData = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);

            data.level++;

            string json = JsonUtility.ToJson(data);
            Debug.Log(json);


            File.WriteAllText(path, json);
            */

            // 1. Define the file path
            string path = Path.Combine(Application.persistentDataPath, "PlayerData.json");

            // 2. Check if the file exists. If not, create it from the Resources folder.
            if (!File.Exists(path))
            {
                Debug.Log("Save file not found. Creating from default in Resources.");
                TextAsset jsonTextAsset = Resources.Load<TextAsset>(Path.GetFileNameWithoutExtension("PlayerData"));

                if (jsonTextAsset != null)
                {
                    File.WriteAllText(path, jsonTextAsset.text);
                }
                else
                {
                    Debug.LogError("PlayerData.json not found in Resources folder!");
                    return;
                }
            }

            // 3. Now that the file is guaranteed to exist, read it, modify it, and save it.
            try
            {
                // Read the data
                string jsonData = File.ReadAllText(path);
                PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);

                // Modify the data
                data.level++;

                // Save the data
                string json = JsonUtility.ToJson(data);
                Debug.Log("Updated JSON data: " + json);
                File.WriteAllText(path, json);
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error during file operation: {ex.Message}");
                return;
            }

            SceneManager.LoadScene(sceneName);
            gameObject.SetActive(false);
        }
        else
        {

        }
        
    }

    [System.Serializable]
    private class PlayerData
    {
        public int level;
    }


}
