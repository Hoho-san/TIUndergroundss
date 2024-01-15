using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Add this line for scene management

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
    public GameObject LevelFinishedText;

    private Animator door;
    private bool doorOpening;
    public GameManagerScript gameManager;


    private void Start()
    {
        isReach = false;
        hasKey = false;
        doorIsOpen = false;

        timer = timerDuration;
        isTimerRunning = false;

        door = GetComponent<Animator>();
        doorOpening = false; // Initialize doorOpening flag
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
            gameManager.UpdateTimerDisplay();

            if (timer <= 1f)
            {
                gameManager.StopTimer();
                // Timer expired, perform game over actions
                gameManager.gameOver();

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
                gameManager.StartTimer();
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
        Levelfinished();
        if (!doorOpening)
        {
            StartCoroutine(LoadLevelAfterDelay(3f));
            door.SetBool("Open", true);
            door.SetBool("Close", false);
            doorIsOpen = true;
            gameManager.StopTimer();
            doorOpening = true; // Set flag to prevent multiple door opening actions
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.LoadNextLevel();

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
        gameManager.StartTimer();
    }

    private void Levelfinished()
    {
        gameManager.timerText.gameObject.SetActive(false);
        LevelFinishedText.SetActive(true);
        gameManager.timerText.gameObject.SetActive(false);
        Debug.Log("Level Done");
    }
}
