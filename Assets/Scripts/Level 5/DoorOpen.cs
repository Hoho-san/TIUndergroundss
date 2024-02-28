using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator door;
    public GameObject DoorSound;
    public float soundDelay = 0.5f; // Delay for the sound in seconds
    public AudioManager audioManager;

    public GameObject EndingVid;
    public GameObject EndingVidPlayer;

    void Start()
    {
        door = GetComponent<Animator>();
      
    }

    public void DoorOpening()
    {
        door.SetBool("Open", true);
        StartCoroutine(ActivateDoorSoundWithDelay());
        audioManager.PlaySound();
        EndingVid.SetActive(true);
        EndingVidPlayer.SetActive(true);
    }

    IEnumerator ActivateDoorSoundWithDelay()
    {
        yield return new WaitForSeconds(soundDelay);
        DoorSound.SetActive(true);
    }
}

