using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARUIManager : MonoBehaviour
{

    public GameObject pauseMenuUI;   // assign PauseMenu panel here
    public GameObject pauseButtonUI; // assign PauseButton here
    private bool isPaused = false;

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f; // freeze game
            pauseMenuUI.SetActive(true);  // show pause menu
            pauseButtonUI.SetActive(false); // hide pause button
            isPaused = true;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // unfreeze
        pauseMenuUI.SetActive(false); // hide pause menu
        pauseButtonUI.SetActive(true); // show pause button
        isPaused = false;
    }

    public void GoBackToMenu()
    {
        Time.timeScale = 1f; // reset time
        SceneManager.LoadScene("MainMenu"); // replace with your menu scene name
    }

}
