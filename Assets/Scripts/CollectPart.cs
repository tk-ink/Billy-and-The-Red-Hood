// Testing Pull
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPart : MonoBehaviour
{
    private bool pickUpAllowed = false;
    public GameObject pickUpText;

    public AudioSource collectSound;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

   

    void OnTriggerEnter(Collider other)
    {
        pickUpAllowed = true;
        pickUpText.gameObject.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        pickUpAllowed = false;
        pickUpText.gameObject.SetActive(false);


    }

    private void PickUp()
    {
        collectSound.Play();
        scoringSystem.theScore++;
        Destroy(gameObject);
        pickUpText.gameObject.SetActive(false);
    }
}
