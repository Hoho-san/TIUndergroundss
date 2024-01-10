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

    public string level2SceneName = "Level2"; // Name of your level 2 scene

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
            UpdateTimerDisplay();

            if (timer <= 1f)
            {
                StopTimer();
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
        Levelfinished();
        if (!doorOpening)
        {
            StartCoroutine(LoadLevelAfterDelay(5f)); // Load level after 5 seconds
            door.SetBool("Open", true);
            door.SetBool("Close", false);
            doorIsOpen = true;
            StopTimer();
            doorOpening = true; // Set flag to prevent multiple door opening actions
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for specified seconds

        // Load Level 2
        SceneManager.LoadScene("Level2"); // Replace "Level2" with your actual scene name
    }

    public void CloseDoor()
    {
        door.SetBool("Open", false);
        door.SetBool("Close", true);
        buttonCloseDoor.SetActive(false);
        doorIsOpen = false;

        // Load level 2 after opening the door     
        LoadLevel2();
    }


    public void DoorLocked()
    {
        doorLockText.SetActive(true);
        doorText.SetActive(false);
        StartTimer();
    }

    private void StartTimer()
    {
        timerText.gameObject.SetActive(true);
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

    private void Levelfinished()
    {
        timerText.gameObject.SetActive(false);
        LevelFinishedText.SetActive(true);
        timerText.gameObject.SetActive(false);
        // Implement game over actions here (e.g., restart level, show game over screen)
        Debug.Log("Level Done");
        // You can add your game over logic here
    }


    private void LoadLevel2()
    {
        // Load the next scene (Level 2)
        SceneManager.LoadScene(level2SceneName);
    }
}
