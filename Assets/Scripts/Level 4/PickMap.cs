using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMap : MonoBehaviour
{
    public GameObject MapObject;
    public GameObject MapInventory;
    public GameObject MapButton;
    public GameObject MapText;
    public GameObject MapIcon;

    public bool isReach;

    private void Start()
    {
        isReach = false;
        MapInventory.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            MapButton.SetActive(true);
            MapText.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            MapButton.SetActive(false);
            MapText.SetActive(false);
        }

    }

    public void PickthisMap()
    {
        MapObject.SetActive(false);
        MapInventory.SetActive(true);
        MapButton.SetActive(false);
        MapText.SetActive(false);
        MapIcon.SetActive(true );
    }
}
