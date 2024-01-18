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
    public GameObject buttonLockDoor;

    private bool isReach;
    private bool hasKey;
    private bool doorIsOpen;

    public GameObject doorLockText;
    public GameObject doorText;

    public GameObject LevelFinishedText;

    private Animator door;
    private bool doorOpening;
    public GameManagerScript gameManager;
    public Scene_Manager sceneManager;

    private void Start()
    {
        sceneManager.Save_and_Exit();
        isReach = false;
        hasKey = false;
        doorIsOpen = false;
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

        if (isReach && hasKey && !doorIsOpen)
        {
            buttonOpenDoor.SetActive(true);
        }
        gameManager.UpdateTimerDisplay();
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
            door.SetBool("Open", true);
            door.SetBool("Close", false);
            doorIsOpen = true;
            gameManager.StopTimer();
            doorOpening = true; // Set flag to prevent multiple door opening actions
        }
        StartCoroutine(LoadLevelAfterDelay(4f));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.LoadNextLevel();
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
