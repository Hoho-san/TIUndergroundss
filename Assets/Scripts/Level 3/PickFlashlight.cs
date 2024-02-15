using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFlashlight : MonoBehaviour
{
    public GameObject FlashlightObject;
    public GameObject FlashlightInventory;
    public GameObject FlashlightButton;
    public GameObject FlashlightText;
    public GameObject FlashlightONIcon;

    public bool isReach;

    private void Start()
    {
        isReach = false;
        FlashlightInventory.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            FlashlightButton.SetActive(true);
            FlashlightText.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            FlashlightButton.SetActive(false);
            FlashlightText.SetActive(false);
        }

    }

    public void PickthisFlashlight()
    {
        FlashlightObject.SetActive(false);
        FlashlightInventory.SetActive(true);
        FlashlightButton.SetActive(false);
        FlashlightText.SetActive(false);
        FlashlightONIcon.SetActive(true);
    }
}
