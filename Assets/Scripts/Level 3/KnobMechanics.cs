using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnobMechanics : MonoBehaviour
{
    public Knob Knob1;
    public Knob Knob2;  //off
    public Knob Knob3;  //off
    public Knob Knob4;
    public Knob Knob5;
    public Knob Knob6;  //off

    public LightsSwitch lights;

    public GameObject LevelFinishedText;
    public GameManagerScript gameManager;

    public Scene_Manager sceneManager;

    private bool isReach;

    public ParticleController particleController;
    public WaterRise waterRise;
   
    public GameObject waterSound;

    void Start()
    {
        sceneManager.Save_and_Exit();
        waterSound.SetActive(false);
        particleController.StopWaterParticles();
    }

    void Update()
    {
        CorrectCombination();
    }

   
    private void CorrectCombination()
    {
        if (Knob1.IsKnobOn && !Knob2.IsKnobOn && !Knob3.IsKnobOn && Knob4.IsKnobOn && Knob5.IsKnobOn && !Knob6.IsKnobOn)
        {
            gameManager.StopTimer();
            waterRise.WaterDraining();
            particleController.StopWaterParticles();
            waterSound.SetActive(false);
           // lights.LightsOff();
            Levelfinished();
            StartCoroutine(LoadLevelAfterDelay(3f));
        }
    }


    private void Levelfinished()
    {
        gameManager.timerText.gameObject.SetActive(false);
        LevelFinishedText.SetActive(true);
        gameManager.timerText.gameObject.SetActive(false);
        Debug.Log("Level Done");
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.LoadNextLevel();
    }
}
