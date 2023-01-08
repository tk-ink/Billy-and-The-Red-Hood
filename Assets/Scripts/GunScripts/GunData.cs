using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunData : MonoBehaviour
{
    [Header("Info")]
    public new string name;

    [Header("Shooting")]
    public float damage;
    public float maxDistance;

    [Header("Reloading")]
    public int currentAmmo;
    public int magSize;
    public float fireRate;
}
