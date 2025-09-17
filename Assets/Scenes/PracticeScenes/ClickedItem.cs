using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedItem : MonoBehaviour
{
    

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits a collider
        if (Physics.Raycast(ray, out hit))
        {
            // Get the GameObject that was hit and print its name to the console
            Debug.Log("Clicked object name: " + hit.collider.gameObject.name);
        }


    }
}
