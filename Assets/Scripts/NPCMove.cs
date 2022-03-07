using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    private bool playerLose = false;
    public GameObject LoseText;

    private bool amStunned = false;
    private bool outsideMap = true;
    private bool loseSoundPlayer = false;

    public AudioSource loseSound;

    // Start is called before the first frame update
    void Start()
    {
        LoseText.gameObject.SetActive(false);
        gameObject.GetComponent<Collider>().isTrigger = false;
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLose)
        {
            playerLoses();
        }

        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(outsideMap && scoringSystem.theScore >= 1)
        {
           beginStalk();
        }
        //Speed up the enemy based on body parts collected
        if (!amStunned)
        {
            _navMeshAgent.speed = scoringSystem.theScore * 2.5f;
        }
        else
        {
            _navMeshAgent.speed = 0;
        }
        

        if (_navMeshAgent == null)
        {
            Debug.LogError("Nav mesh not attached");
        }
        else
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        playerLose = true;
        
    }

    private void playerLoses()
    {
        LoseText.gameObject.SetActive(true);
        Time.timeScale = 0;
        if (!loseSoundPlayer)
        {
            loseSoundPlayer = true;
            loseSound.Play();
        }
       
    }

    public void stun()
    {
        amStunned = true;
        Invoke("unstun", 5);
    }

    public void unstun()
    {
        amStunned = false;
    }

    private void beginStalk()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
        gameObject.GetComponent<Renderer>().enabled = true;
        outsideMap = false;
    }
}
