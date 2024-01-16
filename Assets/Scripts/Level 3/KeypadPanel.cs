using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class KeypadPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text Ans;
    private string Answer = "12345";
    public GameObject Keypad;
    public GameObject Door;

    public DoorLock3 DoorLock3;
    public Keypad deactivatekeypad;
    private bool passwordEntered = false;
    public GameObject Entrancewall;

    

    public void Number(int number)
    {
        if (!passwordEntered)
        {
            Ans.text = ""; // Clear the initial "0" when the user starts typing
            passwordEntered = true;
        }

        if (Ans.text.Length < 6) // Check if the length is less than 6 before adding
        {
            Ans.text += number.ToString();
        }
       else
        {
            Ans.text = "Too Long";
        }
    }

    public void Execute()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Nice";
            DoorLock3.OpenDoor();
            DoorLock3.StopFunctionality();
            deactivatekeypad.StopFunctionality();
            Entrancewall.SetActive(true);

        }
        else
        {
            Ans.text = "Bobo";
        }
    }
   
    public void Clear()
    {
        Ans.text = "";
        passwordEntered = false; // Reset the flag when clearing the input
    }
}
