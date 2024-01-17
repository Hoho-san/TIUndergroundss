using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject ResumeButton;
    public Scene_Manager Scene_Manager;

    void Start()
    {
        showResume();
    }

    public void showResume()
    {
        if (Scene_Manager != null && !string.IsNullOrEmpty(Scene_Manager.Saved_scene))
        {
            ResumeButton.SetActive(true);
        }
        else
        {
            ResumeButton.SetActive(false);
        }
    }

}