using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPickup : MonoBehaviour
{
    public GameObject gunHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gunHolder.GetComponent<Gun>().gunEquipped)
        {
            gunHolder.GetComponent<Gun>().gunEquipped = true;
            gunHolder.GetComponent<Gun>().gameObject.SetActive(true);
            gunHolder.GetComponent<Gun>().ammoCollectSound();

            Destroy(gameObject);
        }
    }
}
