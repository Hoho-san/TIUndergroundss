using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filebinder : MonoBehaviour
{
    public GameObject PickBinderButton;
    private bool isReach;
    private bool doorIsOpen;
    public GameManagerScript gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            PickBinderButton.SetActive(true);
            if (!doorIsOpen)
            {
                gameManager.StartTimer();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            PickBinderButton.SetActive(false);
          
        }
    }
}
