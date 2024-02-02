
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        gameOverUI.SetActive(true);
        HUD.SetActive(false);
        buttons.SetActive(false);
        setting.SetActive(false);
        joystick.SetActive(false);
        keypadpanel.SetActive(false);
        binderpanel.SetActive(false);
        controller.StopPlayer();
        Debug.Log("Game Over: Time's up!");
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