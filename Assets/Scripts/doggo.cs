using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class doggo : MonoBehaviour
{
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    public GameObject interactText;
    private GameObject foundPart;

    private Ray ray;
    private RaycastHit hit;

    private GameObject closestPart;

    private bool dogInteractAllow = false;
    private bool dogFindingPart = false;
    private bool dogHoldPattern = false;
    private bool dogIsBarking = false;
    private bool dogIsAlive = true;

    private int partsFound = 0;

    private float dogSpeed = 10f;

    public AudioSource dogBark;
    public AudioSource dogOneBark;
    public AudioSource dogHurt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "Doggo" && !dogFindingPart)
        {

              dogInteractAllow = true;
              interactText.GetComponent<Text>().text = "Press 'E' to pet dog.";
            
        }
        else
        {
            dogInteractAllow = false;
        }

        if (dogInteractAllow && Input.GetKeyDown(KeyCode.E))
        {
            if (!dogOneBark.isPlaying)
            {
                dogOneBark.Play();
            }
            interactText.GetComponent<Text>().text = "";
            Invoke("activateDog", 1);
        }
        if (partsFound >= 1)
        {
            dogSpeed = 20f;
        }
        if (dogHoldPattern)
        {
            if (!dogIsBarking)
            {
                dogIsBarking = true;
                dogBark.Play();
            }
        }
        else
        {
            if (dogIsBarking)
            {
                dogIsBarking = false;
                dogBark.Stop();
            }
        }

        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = dogSpeed;

        if(foundPart == null)
        {
            dogHoldPattern = false;
        }

        if (dogFindingPart && partsFound >= 1)
        {
            Invoke("killDogSound", 9.3f);
            Invoke("killDog", 10); 
        }

    }

    private void killDogSound()
    {
        if (!dogHurt.isPlaying && dogIsAlive)
        {
            dogHurt.Play();
        }
    }

    private void killDog()
    {
        dogIsAlive = false;
        Destroy(gameObject);
        Debug.Log("Doggo is Dead");
    }
 
 

    void OnTriggerEnter(Collider other)
    {
        foundPart = other.gameObject;
        if (other.gameObject.tag == "bodyPart")
        {
            partsFound++;
            dogFindingPart = false;
            dogHoldPattern = true;
            Debug.Log("Found Part");
        }

    }

    private void spinAroundPart()
    {
        //transform.RotateAround(foundPart.transform.position, Vector3.up, 20 * Time.deltaTime);
    }

    private void activateDog()
    {
        
        dogFindingPart = true;
        closestPart = FindClosestBodyPart();
        if (closestPart != null && !dogHoldPattern)
        {
            Vector3 targetVector = closestPart.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }



    }

    private GameObject FindClosestBodyPart()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("bodyPart");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        Debug.Log(closest.name);
        return closest;
    }
}
