using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    private Animator Laser;
    public GameManagerScript gameManager;  

    void Start()
    {
        Laser = GetComponent<Animator>();
    }

    public void StartCompressing()
    {
        Laser.SetBool("Shrink", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.gameOver();
            Debug.Log("gameover");
        }
    }
}
