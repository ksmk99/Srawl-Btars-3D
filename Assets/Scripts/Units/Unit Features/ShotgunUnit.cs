using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunUnit : Unit
{
    [SerializeField] private GameObject bulletLine;

    private WeaponChanger weaponChanger;

    private void Start()
    {
        weaponChanger = GetComponentInChildren<WeaponChanger>();
    }

    protected override void UnitAction()
    {
        Instantiate(bulletLine, weaponChanger.ShootPoint.position, weaponChanger.ShootPoint.rotation);
    }
}
