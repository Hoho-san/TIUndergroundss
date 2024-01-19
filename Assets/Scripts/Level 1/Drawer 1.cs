using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Drawer : MonoBehaviour
{
    public GameObject buttonOpenDrawer;
    public GameObject buttonCloseDrawer;
    public AudioClip drawerSound;
    private AudioSource audioSource;

    private bool isReach;
    private bool drawerIsOpen;
  
    public GameObject drawerText;
    
    private Animator drawer;

    public GameObject pickKeyButton;
    public PickKey pickKeyScript; // Reference to the PickKey script

    public float pushForce = 10f;
    private void Start()
    {
        isReach = false;
        drawerIsOpen = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = drawerSound;
        drawer = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isReach)
        {
            if (drawerIsOpen)
            {
                buttonCloseDrawer.SetActive(true);
               
            }
            else
            {
                buttonCloseDrawer.SetActive(false);

                if (pickKeyScript != null)
                {
                    pickKeyButton.SetActive(false);
                    pickKeyScript.keyText.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            drawerText.SetActive(true);
            buttonOpenDrawer.SetActive(true);
           

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            buttonOpenDrawer.SetActive(false);
            buttonCloseDrawer.SetActive(false);
            drawerText.SetActive(false);
            if (pickKeyScript != null)
            {
                pickKeyButton.SetActive(false);
            }
        }
    }

    public void OpenDrawer()
    {
        PlayDrawerSound();
        drawer.SetBool("Open", true);
        drawer.SetBool("Close", false);
        drawerIsOpen = true;
        
    }

    public void CloseDrawer()
    {
        PlayDrawerSound();
        drawer.SetBool("Open", false);
        drawer.SetBool("Close", true);
        buttonCloseDrawer.SetActive(false);
        drawerIsOpen = false;
        
        if (pickKeyScript != null)
        {
            pickKeyButton.SetActive(false);
        }
    }

    private void PlayDrawerSound()
    {
        if (drawerSound != null)
        {
            audioSource.PlayOneShot(drawerSound);
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
