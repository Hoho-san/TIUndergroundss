using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MorgueDoor : MonoBehaviour
{
    public GameObject buttonOpenMorgueDoor;
    public GameObject buttonCloseMorgueDoor;
    public AudioClip morgueDoorsound;
    private AudioSource audioSource;

    private bool isReach;
    public bool MorgueDoorIsOpen;

    //public GameObject MorgueDoorText;
   // public MorgueBed morgueBed;

    private Animator morgue;

    private void Start()
    {
        isReach = false;
        MorgueDoorIsOpen = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = morgueDoorsound;
        morgue = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isReach)
        {
            if (MorgueDoorIsOpen)
            {
                buttonCloseMorgueDoor.SetActive(true);
            }
            else
            {
                buttonCloseMorgueDoor.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            //MorgueDoorText.SetActive(true);
            buttonOpenMorgueDoor.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            buttonOpenMorgueDoor.SetActive(false);
            buttonCloseMorgueDoor.SetActive(false);
            //MorgueDoorText.SetActive(false);
        }
    }

    public void OpenMortuaryChamber()
    {
        PlayMorgueDoorSound();
        morgue.SetBool("Open", true);
        morgue.SetBool("Close", false);
        MorgueDoorIsOpen = true;
    }

    public void CloseMortuaryChamber()
    {
        PlayMorgueDoorSound();
        morgue.SetBool("Open", false);
        morgue.SetBool("Close", true);
        buttonCloseMorgueDoor.SetActive(false);
        MorgueDoorIsOpen = false;
    }

    private void PlayMorgueDoorSound()
    {
        if (morgueDoorsound != null)
        {
            audioSource.PlayOneShot(morgueDoorsound);
        }
    }
   
}
