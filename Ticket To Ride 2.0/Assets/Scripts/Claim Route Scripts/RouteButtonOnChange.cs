using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RouteButtonOnChange : MonoBehaviour

{
    public Button[] routeButtons; // Array of route buttons
    public GameObject[] targetObjects; // Array of target GameObjects

    private Color blueColor = Color.blue;
    private Color redColor = Color.red;

    private void Start()
    {
        // Attach the SetObjectColor method to the onClick event of each route button
        for (int i = 0; i < routeButtons.Length; i++)
        {
            int index = i; // Store the index in a separate variable to avoid closure issues
            routeButtons[i].onClick.AddListener(() => SetObjectColor(index));
        }
    }

    private void SetObjectColor(int index)
    {
        if (index >= 0 && index < targetObjects.Length)
        {
            GameObject targetObject = targetObjects[index];
            Renderer renderer = targetObject.GetComponent<Renderer>();

            // Change the color of the target GameObject based on its current color
            if (renderer.material.color == blueColor)
            {
                renderer.material.color = redColor;
            }
            else
            {
                renderer.material.color = blueColor;
            }
        }
    }
}


