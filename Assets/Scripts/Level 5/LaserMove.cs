using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    private Animator compress;
    public GameManagerScript gameManager;  

    void Start()
    {
        compress = GetComponent<Animator>();
       
    }

    public void StartCompressing()
    {
        compress.SetBool("Shrink", true);
    }

    public void WallReversing()
    {
        compress.SetBool("Shrink", false);
        compress.SetBool("TaskDone", true);
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
