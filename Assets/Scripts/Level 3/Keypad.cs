using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public GameObject KeypadButton;

    private bool isReach;
    private bool doorIsOpen;
    public GameManagerScript gameManager;

    private bool isFunctionalityActive = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isFunctionalityActive &&  other.gameObject.tag == "Reach")
        {
            isReach = true;
            KeypadButton.SetActive(true);
            if (!doorIsOpen)
            {
                gameManager.StartTimer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isFunctionalityActive && other.gameObject.tag == "Reach")
        {
            isReach = false;
            KeypadButton.SetActive(false);
        }
    }
    public void StopFunctionality()
    {
        isFunctionalityActive = false;
    }
}
