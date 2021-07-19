using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(int layer)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var shoot = Instantiate(weaponData.Bullet, shootPoint.position, shootPoint.rotation);
            shoot.layer = layer;
        }
    }
}
