using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frame : MonoBehaviour
{
    public GameObject Putpicbutton;
    public GameObject frametext1;
    public GameObject frametext2;

    public GameObject PicInventory;
    public GameObject postedPic;
    public bool hasPic;
    public bool IspostedPic;

    private bool isReach;
    private bool doorIsOpen;
 
    private void Start()
    {
        isReach = false;
        hasPic = false;
    }

    private void Update()
    {
        hasPic = PicInventory.activeInHierarchy; // bool value
        IspostedPic = postedPic.activeInHierarchy;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            frametext1.SetActive(true);
            if (hasPic)
            {
                Debug.Log("has pic");
                Putpicbutton.SetActive(true);
                if (IspostedPic)
                {
                    Putpicbutton.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            Putpicbutton.SetActive(false);
            frametext1.SetActive(false);
            frametext2.SetActive(false);
        }
    }
}
