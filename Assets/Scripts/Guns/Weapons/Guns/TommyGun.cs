using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TommyGun : Weapon
{
    public override void Shoot(int layer)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + 0.3f;
            StartCoroutine(ShootPattern());
        }
    }

    private IEnumerator ShootPattern()
    {
        BulletInstantiate(new Vector3(0, 10f, 0));
        yield return new WaitForSeconds(0.1f);
        BulletInstantiate(new Vector3(0, -20f, 0));
        yield return new WaitForSeconds(0.1f);
        BulletInstantiate(new Vector3(0, 10f, 0));
        yield return new WaitForSeconds(0.1f);
        
    }
    
    private void BulletInstantiate(Vector3 pointMove)
    {
        var shoot = Instantiate(weaponData.Bullet, shootPoint.position, shootPoint.rotation);
        shootPoint.Rotate(pointMove);
    }
}
