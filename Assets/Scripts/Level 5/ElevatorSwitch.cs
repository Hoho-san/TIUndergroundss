using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorSwitch : MonoBehaviour
{
    public GameObject elevatorSwitchbtn;
    public GameObject elevatorswitchtxt;
    private bool isReach;
    private bool doorIsOpen;
    public GameManagerScript gameManager;
    public CompressWall compressWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            elevatorSwitchbtn.SetActive(true);
            elevatorswitchtxt.SetActive(true);
            if (!doorIsOpen)
            {
                gameManager.StartTimer();
                compressWall.StartCompressing();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            elevatorSwitchbtn.SetActive(false);
            elevatorswitchtxt.SetActive(false);
        }
    }
}
