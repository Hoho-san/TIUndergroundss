using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCompleted : MonoBehaviour
{

    public GameObject postedPic1;
    public GameObject postedPic2;
    public GameObject postedPic3;
    public GameObject postedPic4;
    public GameObject postedPic5;
    public GameObject postedPic6;

    public GameObject LevelFinishedText;
    public GameManagerScript gameManager;


    public bool IspostedPic1, IspostedPic2, IspostedPic3, IspostedPic4, IspostedPic5, IspostedPic6;

    public Scene_Manager sceneManager;
    void Start()
    {
        sceneManager.Save_and_Exit();
    }
    void Update()
    {
        IspostedPic1 = postedPic1.activeInHierarchy;
        IspostedPic2 = postedPic2.activeInHierarchy;
        IspostedPic3 = postedPic3.activeInHierarchy;
        IspostedPic4 = postedPic4.activeInHierarchy;
        IspostedPic5 = postedPic5.activeInHierarchy;
        IspostedPic6 = postedPic6.activeInHierarchy;

        PuzzleIsCompleted();

    }

    private void PuzzleIsCompleted()
    {
        if (IspostedPic1 && IspostedPic2 && IspostedPic3 && IspostedPic4 && IspostedPic5 && IspostedPic6)
        {   
            gameManager.StopTimer();
            Levelfinished();
        }
    }

    private void Levelfinished()
    {
        gameManager.timerText.gameObject.SetActive(false);
        LevelFinishedText.SetActive(true);
        gameManager.timerText.gameObject.SetActive(false);
        Debug.Log("Level Done");
    }
}
