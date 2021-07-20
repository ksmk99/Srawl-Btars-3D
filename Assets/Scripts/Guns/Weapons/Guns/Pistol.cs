using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        if (Time.time > nextFire && weaponReload.Shoot())
        {
            nextFire = Time.time + minFireRate;
            var bullet = Instantiate(weaponData.Bullet, shootPoint.position, shootPoint.rotation);
            bullet.GetComponent<Bullet>().SetParent(GetComponentInParent<UnitShooter>().gameObject);
            animator?.SetTrigger("Attack");
        }
    }
}
