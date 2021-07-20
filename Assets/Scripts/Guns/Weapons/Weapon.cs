using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData WeaponData => weaponData;

    [SerializeField] protected WeaponData weaponData;
    protected Transform shootPoint;
    protected WeaponReloadGUI weaponReload;

    protected float minFireRate;
    protected float nextFire = 0;
    protected float fireRate;

    protected Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        fireRate = weaponData.ReloadTime;
        minFireRate = weaponData.MinFireRate;
    }

    public void SetComponents(Transform shootPoint, WeaponReloadGUI weaponReload)
    {
        this.shootPoint = shootPoint;
        this.weaponReload = weaponReload;
    }

    public abstract void Shoot();
}
