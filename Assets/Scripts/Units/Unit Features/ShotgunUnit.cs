using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunUnit : Unit
{
    [SerializeField] private WeaponData weaponData;

    private WeaponChanger weaponChanger;

    private void Start()
    {
        weaponChanger = GetComponentInChildren<WeaponChanger>();
    }

    protected override void UnitAction()
    {
        for (float i = 0; i > -3; i -= 0.5f)
        {
            var bullet = Instantiate(weaponData.Bullet, weaponChanger.ShootPoint.position + Vector3.right * i, weaponChanger.ShootPoint.rotation);
            bullet.name = "Bullet";
            bullet.GetComponent<Bullet>().SetParent(GetComponentInParent<UnitShooter>().gameObject);
        }
        Debug.Log("Bullets");
    }
}
