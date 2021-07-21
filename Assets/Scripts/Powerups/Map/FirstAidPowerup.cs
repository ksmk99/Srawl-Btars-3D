using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidPowerup : Powerup
{
    [SerializeField] private int healthCount;

    protected override void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<Health>();
        if(health != null)
        {
            health.Heal(healthCount);
            PickupParticle();
            Destroy(gameObject);
        }
    }
}
