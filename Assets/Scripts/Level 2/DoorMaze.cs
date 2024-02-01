using System.Collections;
using UnityEngine;
public class DoorMaze : MonoBehaviour
{
    public GameObject buttonOpenDoor;
    public GameObject buttonLockDoor;
    public GameObject keyInventory;
    public GameObject AntidoteInventory;

    private bool isReach;
    private bool doorIsOpen;
    private bool hasKey;
    private bool hasAntidote;

    public GameObject doorText;
    public GameObject needkeyText;
    public GameObject needAntidoteText;
    public GameObject LevelFinishedText;

    private Animator door;
    private bool doorOpening;

    public GameManagerScript gameManager;
    public Scene_Manager sceneManager;  

    private void Start()
    {
        isReach = false;
        doorIsOpen = false;
        hasKey = false;
        hasAntidote = false;
        door = GetComponent<Animator>();
        doorOpening = false;
        sceneManager.Save_and_Exit();
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

        if (AntidoteInventory.activeInHierarchy)
        {
            hasAntidote = true;
        }
        else
        {
            hasAntidote = false;
        }

        if (isReach && hasKey && hasAntidote && !doorIsOpen)
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

            if (hasKey && hasAntidote)
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
            doorOpening = true;
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.LoadNextLevel();
       
    }
    private void Levelfinished()
    {
        gameManager.timerText.gameObject.SetActive(false);
        LevelFinishedText.SetActive(true);
        gameManager.timerText.gameObject.SetActive(false);
        Debug.Log("Level Done");
       
    }
}
