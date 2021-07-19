using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    private Vector3[] vectors = new Vector3[3]
    {
        new Vector3(0, 10f, 0),
        new Vector3(0, -20f, 0),
        new Vector3(0, 10f, 0)
    };

    public override void Shoot(int layer)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var vector in vectors)
            {
                BulletInstantiate(vector, layer);
            }
        }
    }

    private void BulletInstantiate(Vector3 pointMove, int layer)
    {
        var shoot = Instantiate(weaponData.Bullet, shootPoint.position, shootPoint.rotation);
        shoot.layer = layer;
        shootPoint.Rotate(pointMove);
    }
}
