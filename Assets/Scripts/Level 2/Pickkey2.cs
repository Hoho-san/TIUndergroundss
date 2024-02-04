using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickkey2 : MonoBehaviour
{
    public GameObject keyObject;
    public GameObject keyInventory;
    public GameObject keyButton;
    public GameObject keyText;
    public GameObject keyScreen;


    public bool isReach;
    public Drawer2 drawerScript; // Reference to the Drawer script

    private void Start()
    {
        isReach = false;
        keyInventory.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            keyButton.SetActive(true);
            keyText.SetActive(true);
            drawerScript.drawerText.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            keyButton.SetActive(false);
            keyText.SetActive(false);
        }
    }

    public void PickTheKey()
    {
        // Perform key pickup actions
        keyObject.SetActive(false);
        keyInventory.SetActive(true);
        keyButton.SetActive(false);
        keyText.SetActive(false);
        keyScreen.SetActive(true);
    }
}
