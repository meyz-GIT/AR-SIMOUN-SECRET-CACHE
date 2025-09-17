using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
                    //load ar scene
                }
                else if(levelnum.Equals("2 (TMPro.TextMeshProUGUI)"))
                {
                    //load ar scene
                }
                else if (levelnum.Equals("3 (TMPro.TextMeshProUGUI)"))
                {
                    //load ar scene
                }
                else if (levelnum.Equals("4 (TMPro.TextMeshProUGUI)"))
                {
                    //load ar scene
                }
                else if (levelnum.Equals("5 (TMPro.TextMeshProUGUI)"))
                {
                    //load ar scene
                }
                else if (levelnum.Equals("6 (TMPro.TextMeshProUGUI)"))
                {
                    //load ar scene
                }
                else if (levelnum.Equals("7 (TMPro.TextMeshProUGUI)"))
                {
                    //load ar scene
                }
                else if (levelnum.Equals("8 (TMPro.TextMeshProUGUI)"))
                {
                    //load ar scene
                }
                else if (levelnum.Equals("9 (TMPro.TextMeshProUGUI)"))
                {
                    //load ar scene
                }
                else if (levelnum.Equals("10 (TMPro.TextMeshProUGUI)"))
                {
                    //load ar scene
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
