using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadARLevels : MonoBehaviour
{
    public GameObject remindPanel;

    public void CheckComponents()
    {
        TextMeshProUGUI textComponent = GetComponentInChildren<TextMeshProUGUI>();

        if (textComponent != null)
        {
            if (textComponent.gameObject.activeInHierarchy)
            {
                Debug.Log(textComponent);

                string levelnum = textComponent+"";
                if (levelnum.Equals("1 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level1");
                }
                else if(levelnum.Equals("2 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level2");
                }
                else if (levelnum.Equals("3 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level3");
                }
                else if (levelnum.Equals("4 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level4");
                }
                else if (levelnum.Equals("5 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level5");
                }
                else if (levelnum.Equals("6 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level6");
                }
                else if (levelnum.Equals("7 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level7");
                }
                else if (levelnum.Equals("8 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level8");
                }
                else if (levelnum.Equals("9 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level9");
                }
                else if (levelnum.Equals("10 (TMPro.TextMeshProUGUI)"))
                {
                    SceneManager.LoadScene("Level10");
                }
                else
                {
                    //no match
                }
            }
            else
            {
                Debug.Log("The Text component is NOT active.");
            }
        }
        else
        {
            Debug.Log("Locked Level");
            remindPanel.SetActive(true);
        }

    }
}
