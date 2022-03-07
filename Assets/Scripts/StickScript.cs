using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : MonoBehaviour
{
    private bool pickUpAllowed = false;
    public GameObject pickUpText;
    public GameObject PlayerCharacter;

    

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();

    }

    void OnTriggerEnter(Collider other)
    {
        if (PlayerMovement.sticksCarried < 1)
        {
            pickUpAllowed = true;
            pickUpText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        pickUpAllowed = false;
        pickUpText.gameObject.SetActive(false);

    }

    private void PickUp()
    {
        PlayerMovement.sticksCarried++;
        gameObject.transform.parent = PlayerCharacter.transform;
        gameObject.tag = "Weapon";

        //Not setting the stick correctly to player position
        Vector3 newPos = new Vector3(0.88f, 0.91f, 1.02f);
        gameObject.transform.localPosition = newPos;
        pickUpText.gameObject.SetActive(false);
    }

    public void swingStick()
    {
        animator.SetBool("SwingingStick", true);
    }

}
