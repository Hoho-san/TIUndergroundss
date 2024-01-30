using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool elevatorDoorIsOpen;
    private Animator elevator;

    public AudioManager elevatorOpensound;
    public AudioManager elevatorDownsound; 
    private void Start()
    {
        //isReach = false;
        
        elevatorDoorIsOpen = false;
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = morgueDoorsound;
        elevator = GetComponent<Animator>();
        StartCoroutine(MoveElevatorAndOpen());
    }
    private IEnumerator MoveElevatorAndOpen()
    {
        DownElevator();
        yield return new WaitForSeconds(10f); // Adjust the delay as needed
        OpenElevator();
        yield return new WaitForSeconds(5f);
        CloseElevator();
    }
    private void DownElevator()
    {
        elevatorDownsound.PlaySound();
        elevator.SetBool("Down", true);
    }


    public void OpenElevator()
    {
        elevatorOpensound.PlaySound();
        elevator.SetBool("Open", true);
        elevator.SetBool("Close", false);
        elevator.SetBool("Down", false );
        elevatorDoorIsOpen = true;
    }

    public void CloseElevator()
    {
        elevatorOpensound.PlaySound();
        elevator.SetBool("Open", false);
        elevator.SetBool("Close", true);
        elevatorDoorIsOpen = false;

        /*if (pickKeyScript != null)
        {
            pickKeyButton.SetActive(false);
        }*/
    }
}
