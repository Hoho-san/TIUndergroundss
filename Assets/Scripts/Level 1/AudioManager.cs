using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public AudioClip Objectsound;  
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Objectsound;
    }

     public void PlaySound()
    {
        // Play the key pickup sound
        if (Objectsound != null && audioSource != null)
        {
            audioSource.PlayOneShot(Objectsound);
        }
    }
   

}
