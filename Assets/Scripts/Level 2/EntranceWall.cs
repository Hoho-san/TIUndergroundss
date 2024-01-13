using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntranceWall : MonoBehaviour
{
    public GameObject buttonOpenDoor;
    public GameObject buttonCloseDoor;

    public float timerDuration = 180f; // 3 minutes timer
    public TMP_Text timerText;

    private bool isReach;
    private bool doorIsOpen;
    private bool isTimerRunning;
    private float timer;

    public GameObject doorText;
    public GameObject LevelFinishedText;

    private Animator door;
    private bool doorOpening;

    public GameManagerScript gameManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
           // doorText.SetActive(true);

            if (!doorIsOpen)
            {
           //     buttonOpenDoor.SetActive(true);
                gameManager.StartTimer();
            }
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            buttonOpenDoor.SetActive(false);
            buttonCloseDoor.SetActive(false);
            doorText.SetActive(false);
        }
    }*/
}
