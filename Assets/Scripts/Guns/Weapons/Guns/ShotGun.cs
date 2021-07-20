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

    public override void Shoot()
    {
        if (Time.time > nextFire && weaponReload.Shoot())
        {
            animator.SetTrigger("Attack");
            nextFire = Time.time + minFireRate;
            foreach (var vector in vectors)
            {
                BulletInstantiate(vector);
            }
        }
    }

    private void BulletInstantiate(Vector3 pointMove)
    {
        var shoot = Instantiate(weaponData.Bullet, shootPoint.position, shootPoint.rotation);
        shootPoint.Rotate(pointMove);
    }
}
