using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    private Animator water;
    void Start()
    {
        water = GetComponent<Animator>();
    }

    public void WaterRising()
    {
        water.SetBool("Rise", true);
    }

    public void WaterDraining()
    {
        water.SetBool("Rise", false);
        water.SetBool("Drain", true);
    }
}
