using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPhone : MonoBehaviour
{
    public GameObject phoneButton;
    public GameObject phoneText;
    public GameObject PhonePanel;
    public GameObject AnswercallText;
    
    public bool isReach;

    public Animator doll;

    private void Start()
    {
        isReach = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            phoneButton.SetActive(true);
            phoneText.SetActive(true);
            AnswercallText.SetActive(false);
            doll.SetBool("Look", true);
            doll.SetBool("Lookback", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            phoneButton.SetActive(false);
            phoneText.SetActive(false);
            doll.SetBool("Look", false);
            doll.SetBool("Lookback", true);
        }
    }

    public void PickThePhone()
    {
        phoneButton.SetActive(false);
        phoneText.SetActive(false);
        PhonePanel.SetActive(true);
    }
}
