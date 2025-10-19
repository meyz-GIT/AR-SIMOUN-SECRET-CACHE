using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReadRiddles : MonoBehaviour
{

    public TextMeshProUGUI riddleText, firstWordText, winMessage, answer, message, pageNumber;
    public Button nextButton;
    public TextAsset jsonFile;
    public GameObject confirmationPanel, riddleBookPanel, pausePanel;
    public string sceneName;

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
        if (riddles.Count == 0)
        {
            confirmationPanel.SetActive(true);
            winMessage.SetText("You've solved all the riddles!");
            riddleText.text = "You've solved all the riddles!";
            firstWordText.text = "";

            UpdatePageNumberDisplay();
            return;
        }
        
        currentIndex = (currentIndex + 1) % riddles.Count;
        DisplayRiddle(currentIndex);

    }

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

    private void UpdatePageNumberDisplay()
    {
        if (pageNumber == null) return; //Safety

        if (riddles.Count == 0)
        {
            // Display an empty or "0/0" count if the list is empty
            pageNumber.text = "0/0";
            return;
        }

        int currentPage = currentIndex + 1;

        // Total Pages
        int totalPages = riddles.Count;

        pageNumber.text = $"{currentPage}/{totalPages}";
    }
    void DisplayRiddle(int index)
    {
        if (riddles.Count == 0 || index < 0 || index >= riddles.Count)
        {
            UpdatePageNumberDisplay();
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
        UpdatePageNumberDisplay();
    }

    public void playAnimation()
    {
        if (riddles.Count == 0)
        {
            
            SceneManager.LoadScene(sceneName);
            gameObject.SetActive(false);
        }
        else
        {

        }
        
    }


    public void openRiddleBook()
    {
        if (message.Equals("Nice, that's it! You got the answer to the riddle right. Now, on to the next one!") ||
            winMessage.Equals("Nice, that's it! You got the answer to the riddle right. Now, on to the next one!"))
        {
            riddleBookPanel.SetActive(true);
        }
        
    }

    [System.Serializable]
    private class PlayerData
    {
        public int level;
    }


}
