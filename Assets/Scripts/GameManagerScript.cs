using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject HUD;
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

    public void gameOver()
    {
      
        gameOverUI.SetActive(true);
        HUD.SetActive(false);
        buttons.SetActive(false);
        Debug.Log("Game Over: Time's up!");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
