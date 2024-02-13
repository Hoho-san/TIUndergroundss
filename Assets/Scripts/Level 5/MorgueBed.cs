using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueBed : MonoBehaviour
{
    public GameObject buttonPullMorgueBed;
    public GameObject buttonPushMorgueBed;
    //public AudioClip morgueDoorsound;
   // private AudioSource audioSource;

    private bool isReach;
    public bool MorgueBedIsOpen;

    public GameObject MorgueBedText;
    public MorgueDoor morgueDoor;

    private Animator morgue;

    // public GameObject pickKeyButton;
    // public PickKey pickKeyScript; // Reference to the PickKey script
    private void Start()
    {
        isReach = false;
        MorgueBedIsOpen = false;
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = morgueDoorsound;
        morgue = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isReach)
        {
            if (MorgueBedIsOpen)
            {
                buttonPushMorgueBed.SetActive(true);

            }
            else
            {
                buttonPushMorgueBed.SetActive(false);

                /* if (pickKeyScript != null)
                 {
                     pickKeyButton.SetActive(false);
                     pickKeyScript.keyText.SetActive(false);
                 }*/
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            if (morgueDoor.MorgueDoorIsOpen)
            {
                MorgueBedText.SetActive(true);
                buttonPullMorgueBed.SetActive(true);
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            buttonPullMorgueBed.SetActive(false);
            buttonPushMorgueBed.SetActive(false);
            MorgueBedText.SetActive(false);
            /*   if (pickKeyScript != null)
               {
                   pickKeyButton.SetActive(false);
               }*/
        }
    }

    public void PullMorgueBed()
    {
       // PlayMorgueDoorSound();
        morgue.SetBool("Show", true);
        morgue.SetBool("Hide", false);
        MorgueBedIsOpen = true;
    }

    public void PushMorgueBed()
    {
        //PlayMorgueDoorSound();
        morgue.SetBool("Show", false);
        morgue.SetBool("Hide", true);
        buttonPushMorgueBed.SetActive(false);
        MorgueBedIsOpen = false;

        /*if (pickKeyScript != null)
        {
            pickKeyButton.SetActive(false);
        }*/
    }

    //private void PlayMorgueDoorSound()
    //{
    //    if (morgueDoorsound != null)
    //    {
    //        audioSource.PlayOneShot(morgueDoorsound);
    //    }
    //}
}
