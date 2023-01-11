using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCollect : MonoBehaviour
{

    public GameObject gunHolder;
    
    void Start()
    {
        gunHolder = GameObject.Find("GunHolder");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gunHolder.GetComponent<GunData>().currentAmmo < gunHolder.GetComponent<GunData>().magSize)
        {
            gunHolder.GetComponent<GunData>().currentAmmo++;
            gunHolder.GetComponent<Gun>().updateAmmoUI();
            gunHolder.GetComponent<Gun>().ammoCollectSound();

            Destroy(gameObject);
        }


        

    }

}
