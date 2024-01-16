using UnityEngine;

public class Entrance3 : MonoBehaviour
{
    private bool isReach;
    private bool doorIsOpen;
    public DoorLock3 DoorLock3; // Make sure to assign this in the Unity Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reach")) // Use CompareTag for performance
        {
            isReach = true;
            if (!doorIsOpen && DoorLock3 != null) // Check if DoorLock3 is not null
            {
                DoorLock3.Levelfinished();
            }
        }
    }
}
