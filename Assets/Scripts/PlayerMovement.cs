using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f * 2;
    public float jumpHeight = 3f;

    public GameObject interactText;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public static int sticksCarried = 0;

    public bool playerAllowedtoInteract = false;


    bool isGrounded;
    Vector3 velocity;

    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        //interactText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Interact")
        {
            //You can still interact with anything at any distance, but the prompt will no longer show
            float distance = Vector3.Distance(hit.collider.gameObject.transform.position, gameObject.transform.position);
            if(distance < 5)
            {
                playerAllowedtoInteract = true;
                interactText.gameObject.SetActive(true);
                Debug.Log(hit.collider.gameObject.name);
            }
            
        }
        else
        {
           interactText.gameObject.SetActive(false);
            interactText.GetComponent<Text>().text = "";
        }

        //Reset game by pressing Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            scoringSystem.theScore = 0;
            sticksCarried = 0;
            Time.timeScale = 1;
        }

        isGrounded = controller.isGrounded;


        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

}
