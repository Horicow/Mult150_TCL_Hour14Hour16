using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required for interacting with UI elements

public class ButtonPressScript : MonoBehaviour
{
    // This method is called when the button is clicked via UI
    public void OnButtonClicked()
    {
        Debug.Log("Button Was clicked!!");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Mouse1 is pressed
        if (Input.GetMouseButtonDown(0)) // 0 = Mouse1
        {
            // When the mouse is over the button
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Button Pressed!");
            }
            else
            {
                Debug.Log("No Button Pressed");
            }
        }
    }
}