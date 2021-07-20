using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRiffle : Weapon
{
    public override void Shoot()
    {
        if (Time.time > nextFire && weaponReload.Shoot())
        {
            nextFire = Time.time + minFireRate;
            StartCoroutine(ShootPattern());
        }
    }

    private IEnumerator ShootPattern()
    {
        for (int i = 0; i < 3; i++)
        {
            animator.SetTrigger("Attack");
            var bullet = Instantiate(weaponData.Bullet, shootPoint.position, shootPoint.rotation);
            bullet.GetComponent<Bullet>().SetParent(GetComponentInParent<Movement>().gameObject);
            yield return new WaitForSeconds(0.075f);
        }
    }
}
