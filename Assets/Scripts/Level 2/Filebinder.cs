using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filebinder : MonoBehaviour
{
    public GameObject PickBinderButton;
    public GameObject binderText;
    private bool isReach;
    private bool doorIsOpen;
    public GameManagerScript gameManager;
    public Desk desk;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            if (desk.DeskIsOpen) // Check if the desk is open
            {
                PickBinderButton.SetActive(true);
                binderText.SetActive(true);
            }
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
            binderText.SetActive(false);
          
        }
    }
}
