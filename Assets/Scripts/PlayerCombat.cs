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


    void Start()
    {
        stickBreakText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.sticksCarried >= 1 && Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }
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
