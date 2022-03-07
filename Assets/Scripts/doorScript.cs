using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    private bool openDoorAllowed = false;
    public GameObject interactText;

    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        if (openDoorAllowed && Input.GetKeyDown(KeyCode.E))
            openDoor();
    }



    void OnTriggerEnter(Collider other)
    {
        openDoorAllowed = true;
        interactText.gameObject.SetActive(true);
        interactText.GetComponent<Text>().text = "Press 'E' to open door.";

    }

    void OnTriggerExit(Collider other)
    {
        openDoorAllowed = false;
        interactText.gameObject.SetActive(false);
        interactText.GetComponent<Text>().text = "";

    }

    private void openDoor()
    {
        openDoorAllowed = false;
        interactText.gameObject.SetActive(false);
        interactText.GetComponent<Text>().text = "";
        SceneManager.LoadScene("Woods Scene");
    }
}

