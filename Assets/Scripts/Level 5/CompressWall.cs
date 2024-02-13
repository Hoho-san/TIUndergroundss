using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompressWall : MonoBehaviour
{
    private Animator compress;
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
}
