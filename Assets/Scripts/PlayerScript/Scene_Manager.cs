using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Import the UI namespace

public class Scene_Manager : MonoBehaviour
{
    public string Saved_scene; // Change to string for saving scene name
    public int Scene_index;
   // public GameObject ResumeButton; // Assign your ResumeButton GameObject in the Unity Editor

    void Start()
    {
        ToggleResumeButton();
    }
    

    public void new_game()
    {
        SceneManager.LoadSceneAsync(1);
       
    }

    public void Load_Saved_Scene()
    {
        Saved_scene = PlayerPrefs.GetString("Saved");
        if (!string.IsNullOrEmpty(Saved_scene))
            SceneManager.LoadSceneAsync(Saved_scene);
        else
            return;
    }

    public void Save_and_Exit()
    {
        Scene_index = SceneManager.GetActiveScene().buildIndex;
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("Saved", sceneName);
        PlayerPrefs.Save();
        Debug.Log("Level saved: " + Saved_scene);

        // Update ResumeButton state after saving
        ToggleResumeButton();
    }

    public void Next_Scene()
    {
        Scene_index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(Scene_index);
    }


    public GameObject resumeButton; // Reference to the resume button in the UI

    // Function to toggle the resume button based on the existence of a saved scene
    void ToggleResumeButton()
    {
        if (resumeButton != null)
        {
            Saved_scene = PlayerPrefs.GetString("Saved");

            // If a saved scene exists, activate the resume button
            if (!string.IsNullOrEmpty(Saved_scene))
            {
                resumeButton.SetActive(true);
            }
            else
            {
                resumeButton.SetActive(false);
            }
        }
    }
    
}