using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBullet : Bullet
{
    protected override void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<Health>();
        if(health != null)
        {
            health.Damage();
            Destroy(gameObject);
        }
    }
}
