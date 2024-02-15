using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    public GameObject OnKnob;
    public GameObject OffKnob;
   // public AudioClip morgueDoorsound;
  //  private AudioSource audioSource;

    private bool isReach;
    public bool IsKnobOn;

    public GameObject KnobText;
    // public MorgueBed morgueBed;

    private Animator knob;

    private void Start()
    {
        isReach = false;
        IsKnobOn = true;
        //audioSource = GetComponent<AudioSource>();
        // audioSource.clip = morgueDoorsound;
        knob = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isReach)
        {
            if (!IsKnobOn)
            {
                OnKnob.SetActive(true);
                OffKnob.SetActive(false);
            }
            else
            {
                OnKnob.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            KnobText.SetActive(true);
            OffKnob.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            OnKnob.SetActive(false);
            OffKnob.SetActive(false);
            KnobText.SetActive(false);
        }
    }

    public void OnthisKnob()
    {
        //PlayMorgueDoorSound();
        knob.SetBool("On", true);
        knob.SetBool("Off", false);
        IsKnobOn = true;
    }

    public void OffthisKnob()
    {
        // PlayMorgueDoorSound();
        knob.SetBool("On", false);
        knob.SetBool("Off", true);
        OffKnob.SetActive(false);
        IsKnobOn = false;
    }

    //private void PlayMorgueDoorSound()
    //{
    //    if (morgueDoorsound != null)
    //    {
    //        audioSource.PlayOneShot(morgueDoorsound);
    //    }
    //}

}
