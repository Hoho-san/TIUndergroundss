using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Desk : MonoBehaviour
{
    public GameObject buttonOpenDesk;
    public GameObject buttonCloseDesk;
    public AudioClip DeskSound;
    private AudioSource audioSource;

    private bool isReach;
    public bool DeskIsOpen;

    public GameObject DeskText;

    private Animator desk;

    public GameObject ReadButton;
    public Filebinder filebinder; // Reference to the PickKey script

    private float pushForce = 10f;

    public AudioManager Osuperman;
    private void Start()
    {
        isReach = false;
        DeskIsOpen = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = DeskSound;
        desk = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isReach)
        {
            if (DeskIsOpen)
            {
                buttonCloseDesk.SetActive(true);
                DeskText.SetActive(false);
            }
            else
            {
                buttonCloseDesk.SetActive(false);

                if (filebinder != null)
                {
                    ReadButton.SetActive(false);
                    filebinder.binderText.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            DeskText.SetActive(true);
            buttonOpenDesk.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            buttonOpenDesk.SetActive(false);
            buttonCloseDesk.SetActive(false);
            DeskText.SetActive(false);
            if (filebinder != null)
            {
                ReadButton.SetActive(false);
            }
        }
    }

    public void OpenDrawer()
    {
        PlayDrawerSound();
        desk.SetBool("Open", true);
        desk.SetBool("Close", false);
        DeskIsOpen = true;
        Osuperman.PlaySound();
    }

    public void CloseDrawer()
    {
        PlayDrawerSound();
        desk.SetBool("Open", false);
        desk.SetBool("Close", true);
        buttonCloseDesk.SetActive(false);
        DeskIsOpen = false;

        if (filebinder != null)
        {
            ReadButton.SetActive(false);
        }
    }

    private void PlayDrawerSound()
    {
        if (DeskSound != null)
        {
            audioSource.PlayOneShot(DeskSound);
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
