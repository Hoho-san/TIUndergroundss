using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool elevatorDoorIsOpen;
    private Animator elevator;

    private void Start()
    {
      //  isReach = false;
        elevatorDoorIsOpen = false;
        // audioSource = GetComponent<AudioSource>();
        //audioSource.clip = morgueDoorsound;
        elevator = GetComponent<Animator>();
        
    }
    
    public void OpenElevator()
    {
        //PlayMorgueDoorSound();
        elevator.SetBool("Open", true);
        elevator.SetBool("Close", false);
        elevatorDoorIsOpen = true;
    }

    public void CloseElevator()
    {
        //PlayMorgueDoorSound();
        elevator.SetBool("Open", false);
        elevator.SetBool("Close", true);
        elevatorDoorIsOpen = false;

        /*if (pickKeyScript != null)
        {
            pickKeyButton.SetActive(false);
        }*/
    }
}
