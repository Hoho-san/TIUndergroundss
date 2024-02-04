using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAntidote : MonoBehaviour
{
    public GameObject AntidoteObject;
    public GameObject AntidoteInventory;
    public GameObject AntidoteButton;
    public GameObject AntidoteText;
    public GameObject AntidoteScreen;

    public bool isReach;


    private void Start()
    {
        isReach = false;
        AntidoteInventory.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            AntidoteButton.SetActive(true);
            AntidoteText.SetActive(true);
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            AntidoteButton.SetActive(false);
            AntidoteText.SetActive(false);
        }
    }

    public void PicktheAntidote()
    {
        // Perform key pickup actions
        AntidoteObject.SetActive(false);
        AntidoteInventory.SetActive(true);
        AntidoteButton.SetActive(false);
        AntidoteText.SetActive(false);
        AntidoteScreen.SetActive(true);
    }
}
