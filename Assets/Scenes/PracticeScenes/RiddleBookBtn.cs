using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleBookBtn : MonoBehaviour
{
    public GameObject riddleBookPanel;
    public void ShowHideRiddleBook()
    {
        if (!riddleBookPanel.activeInHierarchy)
        {
            riddleBookPanel.SetActive(true);
        }
        else
        {
            riddleBookPanel.SetActive(false);
        }
    }
}
