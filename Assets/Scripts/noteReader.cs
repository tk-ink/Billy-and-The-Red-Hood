using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noteReader : MonoBehaviour
{
    private bool pickUpAllowed = false;
    private bool holdingNote = false;
    public GameObject readText;
    public Image noteImage;
    public GameObject blackFade;

    private Ray ray;
    private RaycastHit hit;

    private void Start()
    {
        readText.gameObject.SetActive(false);
        noteImage.gameObject.SetActive(false);
        blackFade.gameObject.SetActive(false);

    }
    // Update is called once per frame
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Note")
        {
            pickUpAllowed = true;
            readText.gameObject.SetActive(true);
        }
        else
        {
            pickUpAllowed = false;
            readText.gameObject.SetActive(false);
        }

        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();

        if (holdingNote && Input.GetKeyDown(KeyCode.I))
            Drop();
    }



    private void PickUp()
    {
        blackFade.gameObject.SetActive(true);
        noteImage.gameObject.SetActive(true);
        noteImage.GetComponent<Image>().sprite = hit.collider.GetComponent<Image>().sprite;
        readText.gameObject.SetActive(false);
        holdingNote = true;
    }

    private void Drop()
    {
        blackFade.gameObject.SetActive(false);
        noteImage.gameObject.SetActive(false);
        holdingNote = false;
    }
}
