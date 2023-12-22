using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public GameObject keyInventory;
    public GameObject buttonOpenDoor;
    public GameObject buttonCloseDoor;
    public GameObject buttonLockDoor;

    private bool isReach;
    private bool hasKey;
    private bool doorIsOpen;

    public GameObject doorLockText;
    public GameObject doorText;

    private Animator door;

    private void Start()
    {
        isReach = false;
        hasKey = false;
        doorIsOpen = false;

        door = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            doorText.SetActive(true);

            if (hasKey)
            {
                buttonOpenDoor.SetActive(true);
            }
            else
            {
                buttonLockDoor.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            buttonOpenDoor.SetActive(false);
            buttonCloseDoor.SetActive(false);
            buttonLockDoor.SetActive(false);
            doorLockText.SetActive(false);
            doorText.SetActive(false);
        }
    }

    private void Update()
    {
        if (keyInventory.activeInHierarchy)
        {
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }

        if (isReach && doorIsOpen)
        {
            buttonCloseDoor.SetActive(true);
        }

        if (isReach && hasKey && !doorIsOpen)
        {
            buttonOpenDoor.SetActive(true);
        }
    }

    public void OpenDoor()
    {
        door.SetBool("Open", true);
        door.SetBool("Close", false);
        doorIsOpen = true;
    }

    public void CloseDoor()
    {
        door.SetBool("Open", false);
        door.SetBool("Close", true);
        buttonCloseDoor.SetActive(false);
        doorIsOpen = false;
    }

    public void DoorLocked()
    {
        doorLockText.SetActive(true);
        doorText.SetActive(false);
    }
}
