using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickClue : MonoBehaviour
{
    public GameObject PickClueButton;
    public GameObject ClueText;
    private bool isReach;
    private bool doorIsOpen;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            PickClueButton.SetActive(true);
            ClueText.SetActive(true);
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            PickClueButton.SetActive(false);
            ClueText.SetActive(false);
        }
    }
}
