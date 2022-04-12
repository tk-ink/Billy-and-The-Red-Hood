using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public GameObject[] weapons;
    public AudioSource stickBreakSound;
    public GameObject stickBreakText;

    public GameObject settingsMenu;

    private bool settingsOpen = false;


    void Start()
    {
        stickBreakText.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.sticksCarried >= 1 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !settingsOpen)
        {
            openSettings();
        }else if (Input.GetKeyDown(KeyCode.Escape) && settingsOpen)
        {
            closeSettings();
        }
    }

    public void openSettings()
    {
        settingsOpen = true;
        settingsMenu.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void closeSettings()
    {
        settingsOpen = false;
        settingsMenu.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    void Attack()
    {
        weapons = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weapon in weapons)
        {
            weapon.GetComponent<StickScript>().swingStick();
        }

        Collider[] hitEnemies =  Physics.OverlapSphere(AttackPoint.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<NPCMove>().stun();

           
            
        }
        if(hitEnemies.Length >= 1)
        {
            //Delay destroying weapon to see swing animation
            //Invoke("destroyWeapon", 0.5f);
            destroyWeapon();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
        
    }

    private void destroyWeapon()
    {
        stickBreakSound.Play();
        stickBreakText.gameObject.SetActive(true);
        Invoke("removeBrokeStickText", 3f);

        weapons = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weapon in weapons)
        {
            Destroy(weapon.gameObject);

        }
        PlayerMovement.sticksCarried = 0;
       
    }

    private void removeBrokeStickText()
    {
        stickBreakText.gameObject.SetActive(false);
    }
}
