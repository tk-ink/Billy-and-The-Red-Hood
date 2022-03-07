using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject WinText;
    private bool playerWin = false;

    // Start is called before the first frame update
    void Start()
    {
        WinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWin)
        {
            playerWins();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (scoringSystem.theScore == 6)
        {
            playerWin = true;
            
        }
    }

    private void playerWins()
    {
        WinText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
