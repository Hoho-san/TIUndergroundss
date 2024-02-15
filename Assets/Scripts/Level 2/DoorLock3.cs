using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorLock3 : MonoBehaviour
{
    private bool isReach;
    private bool doorIsOpen;

    public GameObject doorText;
    public GameObject LevelFinishedText;


    private Animator door;
    private bool doorOpening;

    public GameManagerScript gameManager;
    public Scene_Manager sceneManager;

    private bool isFunctionalityActive = true;


    private void Start()
    {
        isReach = false;
        doorIsOpen = false;
        door = GetComponent<Animator>();
        doorOpening = false;
        sceneManager.Save_and_Exit();
    }

    private void Update()
    {
        gameManager.UpdateTimerDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFunctionalityActive && other.gameObject.tag == "Reach")
        {
            isReach = true;
            doorText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isFunctionalityActive && other.gameObject.tag == "Reach")
        {
            isReach = false;
            doorText.SetActive(false);
        }
    }

    // Another function to stop the functionality
    public void StopFunctionality()
    {
        isFunctionalityActive = false;
    }

 
    public void OpenDoor()
    {
        Debug.Log("Door open");
       // Levelfinished();
        if (!doorOpening)
        {
            StartCoroutine(LoadLevelAfterDelay(5f));
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


    public void Levelfinished()
    {
        gameManager.timerText.gameObject.SetActive(false);
        LevelFinishedText.SetActive(true);
        gameManager.timerText.gameObject.SetActive(false);
        Debug.Log("Level Done");
        doorText.SetActive(false);
       
    }
}
