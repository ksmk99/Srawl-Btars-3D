using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    public WeaponData WeaponData => weaponData;

    [SerializeField]
    protected WeaponData weaponData;
    [SerializeField]
    protected Transform shootPoint;
    protected float nextFire = 0;
    protected float fireRate;

    private void Awake()
    {
        fireRate = weaponData.FireRate;
    }

    public virtual void Shoot(int layer)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate * Random.Range(0.65f, 1f);
            var bullet = Instantiate(weaponData.Bullet, shootPoint.position, shootPoint.rotation);
            bullet.layer = layer;
        }
    }
}
