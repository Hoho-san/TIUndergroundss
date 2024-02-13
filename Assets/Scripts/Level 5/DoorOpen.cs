using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator door;
    void Start()
    {
        door = GetComponent<Animator>();
    }

    public void DoorOpening()
    {
        door.SetBool("Open", true);
    }
}
