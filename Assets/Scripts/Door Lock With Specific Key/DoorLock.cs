using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorLock : MonoBehaviour
{
    public GameObject keyInventory;
    public GameObject buttonOpenDoor;
    public GameObject buttonCloseDoor;
    public GameObject buttonLockDoor;

    public float timerDuration = 180f; // 3 minutes timer
    public TMP_Text timerText;

    private bool isReach;
    private bool hasKey;
    private bool doorIsOpen;
    private bool isTimerRunning;
    private float timer;

    public GameObject doorLockText;
    public GameObject doorText;
    public GameObject GameOverText;

    private Animator door;

    private void Start()
    {
        isReach = false;
        hasKey = false;
        doorIsOpen = false;

        timer = timerDuration;
        isTimerRunning = false;

        door = GetComponent<Animator>();
    }

    private void Update()
    {
        if (keyInventory.activeInHierarchy)
        {
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }

        if (isReach && doorIsOpen)
        {
            buttonCloseDoor.SetActive(true);
        }

        if (isReach && hasKey && !doorIsOpen)
        {
            buttonOpenDoor.SetActive(true);
        }

        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay();

            if (timer <= 0f)
            {
                StopTimer();
                // Timer expired, perform game over actions
                GameOver();

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            doorText.SetActive(true);

            if (hasKey)
            {
                buttonOpenDoor.SetActive(true);
            }
            else
            {
                buttonLockDoor.SetActive(true);
                StartTimer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            buttonOpenDoor.SetActive(false);
            buttonCloseDoor.SetActive(false);
            buttonLockDoor.SetActive(false);
            doorLockText.SetActive(false);
            doorText.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        door.SetBool("Open", true);
        door.SetBool("Close", false);
        doorIsOpen = true;
        StopTimer();
    }

    public void CloseDoor()
    {
        door.SetBool("Open", false);
        door.SetBool("Close", true);
        buttonCloseDoor.SetActive(false);
        doorIsOpen = false;
    }

    public void DoorLocked()
    {
        doorLockText.SetActive(true);
        doorText.SetActive(false);
        StartTimer();
    }

    private void StartTimer()
    {
        isTimerRunning = true;
    }

    private void StopTimer()
    {
        isTimerRunning = false;
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        timerText.gameObject.SetActive(false);
        GameOverText.SetActive(true);
        // Implement game over actions here (e.g., restart level, show game over screen)
        Debug.Log("Game Over: Time's up!");
        // You can add your game over logic here
    }
}
