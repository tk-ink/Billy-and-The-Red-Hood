using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;

    float timeSinceLastShot;

    public AudioSource gunShot;
    public AudioSource grabAmmo;

    public GameObject muzzleFlash;
    public GameObject redHood;
    public GameObject ammoText;

    public bool gunEquipped = false;

    private void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
        PlayerCombat.shootInput += Shoot;
        muzzleFlash.gameObject.SetActive(false);
        updateAmmoUI();
    }

    private bool CanShoot() => timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
        if(gunData.currentAmmo > 0 && gunEquipped)
        {
            if(CanShoot())
            {
                if(Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    if (hitInfo.collider.tag == "Enemy")
                    {
                        redHood.GetComponent<NPCMove>().stun();
                    }
                    //Debug.Log(hitInfo.transform.name);
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                onGunShot();
            }
        }
    }




    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    private void onGunShot()
    {
        gunShot.Play();
        StartCoroutine(showMuzzleFlash());
        updateAmmoUI();
    }

    public void updateAmmoUI()
    {
        ammoText.GetComponent<Text>().text = "Ammo: " + gunData.currentAmmo + "/" + gunData.magSize;
    }

    public void ammoCollectSound()
    {
        grabAmmo.Play();
    }

    IEnumerator showMuzzleFlash()
    {
        muzzleFlash.gameObject.SetActive(true);
        yield return new WaitForSeconds(.15f);
        muzzleFlash.gameObject.SetActive(false);
    }
}
