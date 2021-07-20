using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBullet : Bullet
{
    protected override void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<Health>();
        if (health != null)
        {
            health.Damage();
        }
        var shield = other.GetComponent<Shield>();
        if (shield != null && 
            shield.GetComponentInParent<Movement>().gameObject == parent)
        {
            return;
        }
        Destroy(gameObject);
    }
}
