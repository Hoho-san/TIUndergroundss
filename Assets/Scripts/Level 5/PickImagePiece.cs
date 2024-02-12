using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickImagePiece : MonoBehaviour
{
    public GameObject ImagePieceObject;
    public GameObject ImagePieceInventory;
    public GameObject ImagePieceButton;
    public GameObject ImagePieceText;

    public bool isReach;

    private void Start()
    {
        isReach = false;
        ImagePieceInventory.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = true;
            ImagePieceButton.SetActive(true);
            ImagePieceText.SetActive(true);
       
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            isReach = false;
            ImagePieceButton.SetActive(false);
            ImagePieceText.SetActive(false);
        }

    }

    public void PickthisImagePiece()
    {
     
        ImagePieceObject.SetActive(false);
        ImagePieceInventory.SetActive(true);
        ImagePieceButton.SetActive(false);
        ImagePieceText.SetActive(false);
    }
}
