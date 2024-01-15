using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntranceWall : MonoBehaviour
{
    private bool isReach;
    private bool doorIsOpen;
    public GameManagerScript gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            if (!doorIsOpen)
            {
                gameManager.StartTimer();
            }
        }
    }
}
