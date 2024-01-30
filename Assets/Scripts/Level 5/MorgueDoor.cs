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
    private bool MorgueDoorIsOpen;

    public GameObject MorgueDoorText;

    private Animator morgue;

   // public GameObject pickKeyButton;
   // public PickKey pickKeyScript; // Reference to the PickKey script

    private float pushForce = 10f;
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
            MorgueDoorText.SetActive(true);
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
            MorgueDoorText.SetActive(false);
         /*   if (pickKeyScript != null)
            {
                pickKeyButton.SetActive(false);
            }*/
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

        /*if (pickKeyScript != null)
        {
            pickKeyButton.SetActive(false);
        }*/
    }

    private void PlayMorgueDoorSound()
    {
        if (morgueDoorsound != null)
        {
            audioSource.PlayOneShot(morgueDoorsound);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.collider.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
                playerRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }

}
