using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPhone : MonoBehaviour
{
    public GameObject phoneButton;
    public GameObject phoneText;
    public GameObject PhonePanel;
    public GameObject AnswercallText;

    public GameObject Callsound;
    public bool isReach;


    private void Start()
    {
        isReach = false;
        Invoke("ActivateObject", 1f); // Invoke the method after 10 seconds
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            phoneButton.SetActive(true);
            phoneText.SetActive(true);
            AnswercallText.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            phoneButton.SetActive(false);
            phoneText.SetActive(false);

        }
    }

    public void PickThePhone()
    {
        phoneButton.SetActive(false);
        phoneText.SetActive(false);
        PhonePanel.SetActive(true);
    }

    void ActivateObject()
    {
        if (Callsound != null)
        {
            Callsound.SetActive(true); // Activate the GameObject
        }
        else
        {
            Debug.LogError("Object to activate is not assigned!");
        }
    }

}
