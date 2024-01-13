using System.Collections;
using UnityEngine;


public class DoorMaze : MonoBehaviour
{
    public GameObject buttonOpenDoor;
   
    private bool isReach;
    private bool doorIsOpen;

    public GameObject doorText;
    public GameObject LevelFinishedText;

    private Animator door;
    private bool doorOpening;

    public GameManagerScript gameManager;

    private void Start()
    {
        isReach = false;
        doorIsOpen = false;

        door = GetComponent<Animator>();
        doorOpening = false;
    }

    private void Update()
    {
        gameManager.UpdateTimerDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            doorText.SetActive(true);

            if (!doorIsOpen)
            {
                buttonOpenDoor.SetActive(true);
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

    public void CloseDoor()
    {
        door.SetBool("Open", false);
        door.SetBool("Close", true);
        doorIsOpen = false;
    }

 
    private void Levelfinished()
    {
        gameManager.timerText.gameObject.SetActive(false);
        LevelFinishedText.SetActive(true);
        gameManager.timerText.gameObject.SetActive(false);
        Debug.Log("Level Done");
    }
}
