using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameManagerScript gameManager;
    public LaserMove LaserWall;
    public AudioManager LaserSound;
    public GameObject GameStartOFF;
    public Elevator Elevator;
    public GameObject LaserOn;

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
        LaserSound.PlaySound();
        LaserOn.SetActive(true);
        yield return new WaitForSeconds(delayTime); // Wait for specified delay time
        gameManager.StartTimer();
        LaserWall.StartCompressing();
        Elevator.CloseElevator();
        GameStartOFF.SetActive(false);
    }
}
