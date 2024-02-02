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
    public GameObject antidoteText;
    public GameObject doorLockText;
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
        hasKey = keyInventory.activeInHierarchy; // bool value
        hasAntidote = AntidoteInventory.activeInHierarchy; // bool value
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
            else if (hasKey && !hasAntidote)
            {
                doorText.SetActive(false);
                needAntidoteText.SetActive(true);   
            }
            else if (!hasKey && hasAntidote)
            {
                doorText.SetActive(false);
                needkeyText.SetActive(true);
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
            buttonLockDoor.SetActive(false);
            needkeyText.SetActive(false);
            needAntidoteText.SetActive(false);
            doorLockText.SetActive(false);
            antidoteText.SetActive(false);
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
            doorOpening = true;
        }
        StartCoroutine(LoadLevelAfterDelay(3f));
    }

    public void DoorLocked()
    {
        doorLockText.SetActive(true);
        doorText.SetActive(false);
        gameManager.StartTimer();
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
        Debug.Log("Level Done");
    }
}
