using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
  
    // Called when YES button is pressed
    public void QuitGame()
    {
        Debug.Log("Exiting game..."); // For testing in Editor
        Application.Quit(); // Works only in a built APK/IPA
    }

    // Called when NO button is pressed
    public void CancelQuit(GameObject panel)
    {
        panel.SetActive(false); // Hides the quit confirmation panel
    }
}
