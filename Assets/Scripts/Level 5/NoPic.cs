using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoPic : MonoBehaviour
{
    public bool isReach;

    public Color originalColor; // Define the original color in the inspector
    public Color newColor; // Define the color you want to change to in the inspector
    private Renderer renderer; // Reference to the renderer component of the game object
   
    void Start()
    {
        isReach = false;

        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            renderer.material.color = newColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
           // Revert the color of the game object to the original color
             renderer.material.color = originalColor;
        }

       
    }

}
