using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private Animator startGame;

    void Start()
    {
        // Get the Animator component
        startGame = GetComponent<Animator>();
        Debug.Log("animatioin start");
        // Trigger the first animation at the beginning of the game
        startGame.SetTrigger("PlayTheBeginning_GetUp");
    }

    // You can add an event in the Animator window to call this method when the first animation finishes
    public void StartSecondAnimation()
    {
        // Trigger the second animation
        startGame.SetTrigger("PlayTheBeginning_LookAround");
    }
}
