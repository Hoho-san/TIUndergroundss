
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManagerScript : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject HUD;
    public GameObject buttons;
    public GameObject setting;
    public GameObject keypadpanel;
    public GameObject binderpanel;
    public GameObject joystick;

    public float timerDuration = 180f; // 3 minutes timer
    public TMP_Text timerText;
    private bool isTimerRunning;
    private float timer;

    public Controller controller;
    public Scene_Manager sceneManager;

    public GameObject dot;
    public GameObject Sounds;
    public GameObject gameOverVid;
    public GameObject gameOverVidPlayer;
    public float viddelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerDuration;
        isTimerRunning = false;

        // Check PlayerPrefs for the Dot state
        bool dotState = PlayerPrefs.GetInt("DotState", 1) == 1;

        // Set the Dot UI component's visibility based on PlayerPrefs
        dot.SetActive(dotState);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay();

            if (timer <= 1f)
            {
                StopTimer();
                gameOver();
            }
        }
    }

    public void gameOver()
    {
        HUD.SetActive(false);
        buttons.SetActive(false);
        setting.SetActive(false);
        joystick.SetActive(false);
        keypadpanel.SetActive(false);
        binderpanel.SetActive(false);
        Sounds.SetActive(false);
        controller.StopPlayer();

        gameOverVid.SetActive(true); // play video
        gameOverVidPlayer.SetActive(true);
        Debug.Log("Game Over: Time's up!");

        // Start the coroutine to play the game over video after a delay
        StartCoroutine(ShowGameOverVideoWithDelay());
    }

    IEnumerator ShowGameOverVideoWithDelay()
    {
        // Wait for a certain delay before showing the game over video
        yield return new WaitForSeconds(viddelay); // Adjust the delay time as needed
        PlayGameOverVideo();
    }

    public void PlayGameOverVideo()
    {
        gameOverUI.SetActive(true);
        gameOverVid.SetActive(false);
        gameOverVidPlayer.SetActive(false);
    }


    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        controller.ContPlayer();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        controller.ContPlayer();
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        Debug.Log("next level");

        // Check if there is a next scene
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene available.");
        }
    }

    public void StartTimer()
    {
        timerText.gameObject.SetActive(true);
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}