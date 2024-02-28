using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart3 : MonoBehaviour
{
    public GameManagerScript gameManager;
    public GameObject GameStartOFF;
    public GameObject waterSound;
    public ParticleController particleController;
    public WaterRise waterRise;
   

    public float delayTime = .5f; // Adjust delay time as needed
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(StartGameSequence());
        }
    }

    IEnumerator StartGameSequence()
    {
        waterSound.SetActive(true);
        waterRise.WaterRising();
        yield return new WaitForSeconds(delayTime); // Wait for specified delay time
        gameManager.StartTimer();
        particleController.PlayWaterPaticles();
        GameStartOFF.SetActive(false);
    }

}
