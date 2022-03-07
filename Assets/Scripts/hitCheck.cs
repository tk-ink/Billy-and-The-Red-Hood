using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitCheck : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerMovement.sticksCarried >= 1 && Input.GetKey(KeyCode.Mouse0))
            swingStick();
    }

    private void swingStick()
    {
        Debug.Log("Swinging Stick");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Enemy")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Colliding with NPC");
        }

    }
}
