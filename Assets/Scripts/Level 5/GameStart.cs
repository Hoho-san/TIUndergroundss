using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private bool isReach;
    private bool doorIsOpen;
    public GameManagerScript gameManager;
    public CompressWall compressWall;
    public GameObject wallSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            if (!doorIsOpen)
            {
                gameManager.StartTimer();
                compressWall.StartCompressing();
                wallSound.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
        }
    }
}
