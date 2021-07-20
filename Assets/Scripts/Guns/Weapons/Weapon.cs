using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    public WeaponData WeaponData => weaponData;

    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected WeaponReloadGUI weaponReload;

    protected float minFireRate = 0.4f;
    protected float nextFire = 0;
    protected float fireRate;

    protected Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        fireRate = weaponData.FireRate;
    }

    public virtual void Shoot()
    {
        if (Time.time > nextFire && weaponReload.Shoot())
        {
            nextFire = Time.time + fireRate * Random.Range(0.65f, 1f);
            if(weaponReload.CanShoot())
            {
                nextFire = Time.time + minFireRate;
            }
            Instantiate(weaponData.Bullet, shootPoint.position, shootPoint.rotation);
            animator.SetTrigger("Attack");
        }
    }
}
