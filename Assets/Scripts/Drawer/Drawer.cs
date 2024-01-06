using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Drawer : MonoBehaviour
{
    public GameObject buttonOpenDrawer;
    public GameObject buttonCloseDrawer;

    private bool isReach;
    private bool drawerIsOpen;
  
    public GameObject drawerText;
    
    private Animator drawer;

    private void Start()
    {
        isReach = false;
        drawerIsOpen = false;
        drawer = GetComponent<Animator>();
    }

    private void Update()
    {
      
        if (isReach && drawerIsOpen)
        {
            buttonCloseDrawer.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            drawerText.SetActive(true);
            buttonOpenDrawer.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            buttonOpenDrawer.SetActive(false);
            buttonCloseDrawer.SetActive(false);
            drawerText.SetActive(false);
        }
    }

    public void OpenDrawer()
    {
        drawer.SetBool("Open", true);
        drawer.SetBool("Close", false);
        drawerIsOpen = true;
  
    }

    public void CloseDrawer()
    {
        drawer.SetBool("Open", false);
        drawer.SetBool("Close", true);
        buttonCloseDrawer.SetActive(false);
        drawerIsOpen = false;
    }

    
}
