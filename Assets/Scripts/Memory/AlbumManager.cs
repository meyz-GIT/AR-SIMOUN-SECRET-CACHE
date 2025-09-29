using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumManager : MonoBehaviour
{
    public GameObject contentContainer;


    void Start()
    {
        int currentLevel = LevelManager.Instance.getCurrentLevel();

        if (contentContainer == null)
        {
            Debug.LogError("Content Container is not assigned. Please assign the Scroll View's content GameObject.");
            return;
        }

        // Iterate through all children of the content container
        foreach (Transform child in contentContainer.transform)
        {
            // Get the GameObject of the button
            GameObject buttonObject = child.gameObject;

            // Check the name of the button and the current level
            string buttonName = buttonObject.name;

            bool shouldBeActive = false;

            if (currentLevel == 2)
            {
                if (buttonName == "One")
                {
                    shouldBeActive = true;
                }
                else 
                {
                    shouldBeActive = false;
                }
            }
            else if (currentLevel == 3)
            {
                if (buttonName == "One" || buttonName == "Two")
                {
                    shouldBeActive = true;
                }
            }
            else if (currentLevel == 4)
            {
                if (buttonName == "One" || buttonName == "Two" || buttonName == "Three")
                {
                    shouldBeActive = true;
                }
            }
            else if (currentLevel == 5)
            {
                if (buttonName == "One" || buttonName == "Two" || buttonName == "Three" || buttonName == "Four")
                {
                    shouldBeActive = true;
                }
            }
            else if (currentLevel == 6)
            {
                if (buttonName == "One" || buttonName == "Two" || buttonName == "Three" || buttonName == "Four" || buttonName == "Five")
                {
                    shouldBeActive = true;
                }
            }
            else if (currentLevel == 7)
            {
                if (buttonName == "One" || buttonName == "Two" || buttonName == "Three" || buttonName == "Four" 
                    || buttonName == "Five" || buttonName == "Six")
                {
                    shouldBeActive = true;
                }
            }
            else if (currentLevel == 8)
            {
                if (buttonName == "One" || buttonName == "Two" || buttonName == "Three" || buttonName == "Four" 
                    || buttonName == "Five" || buttonName == "Six" || buttonName == "Seven")
                {
                    shouldBeActive = true;
                }
            }
            else if (currentLevel == 9)
            {
                if (buttonName == "One" || buttonName == "Two" || buttonName == "Three" || buttonName == "Four"
                    || buttonName == "Five" || buttonName == "Six" || buttonName == "Seven" || buttonName == "Eight")
                {
                    shouldBeActive = true;
                }
            }
            else if (currentLevel == 10)
            {
                if (buttonName == "One" || buttonName == "Two" || buttonName == "Three" || buttonName == "Four"
                    || buttonName == "Five" || buttonName == "Six" || buttonName == "Seven" || buttonName == "Eight" || buttonName == "Nine")
                {
                    shouldBeActive = true;
                }
            }
            else if (currentLevel == 11)
            {
                if (buttonName == "One" || buttonName == "Two" || buttonName == "Three" || buttonName == "Four"
                    || buttonName == "Five" || buttonName == "Six" || buttonName == "Seven" || buttonName == "Eight" || buttonName == "Nine" || buttonName == "Ten")
                {
                    shouldBeActive = true;
                }
            }

            // Set the active state of the button
            buttonObject.SetActive(shouldBeActive);
        }

    }

}
