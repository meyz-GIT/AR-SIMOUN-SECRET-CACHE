using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickedItem : MonoBehaviour
{
    public static bool InteractionEnabled = false;

    private string currentItem;
    
    public ReadRiddles riddleManager;

    private void OnMouseDown()
    {
        if (!InteractionEnabled)
        {
            riddleManager.confirmationPanel.SetActive(true);
            riddleManager.message.SetText("Open riddle book first!");
            Debug.Log("Interaction is currently disabled. Click 'FIND THIS ITEM' first.");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (riddleManager.riddleBookPanel.activeInHierarchy || riddleManager.pausePanel.activeInHierarchy)
        {

        }
        else
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Clicked object name: " + hit.collider.gameObject.name);

                currentItem = riddleManager.answer.text;
                if (currentItem.Equals(hit.collider.gameObject.name))
                {
                    // Correct answer!
                    riddleManager.confirmationPanel.SetActive(true);
                    riddleManager.message.SetText("Nice, that's it! You got the answer to the riddle right. Now, on to the next one!");


                    // Call the method on the ReadRiddles script
                    if (riddleManager != null)
                    {
                        riddleManager.RemoveCurrentRiddle();
                    }

                    hit.collider.gameObject.SetActive(false);
                }
                else
                {
                    // Incorrect answer
                    riddleManager.confirmationPanel.SetActive(true);
                    riddleManager.message.SetText("That's not it, but don't give up! Look closely at the riddle again—the answer is hiding in plain sight. Think carefully and try a different item.");
                }
            }

        }
    }

}
