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
            Instantiate(weaponData.Bullet, shootPoint.position, shootPoint.rotation);
            animator.SetTrigger("Attack");
        }
    }
}
