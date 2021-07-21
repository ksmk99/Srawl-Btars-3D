using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : Powerup
{ 
    protected override void OnTriggerEnter(Collider other)
    {
        var shield = other.GetComponentInChildren<Shield>();
        if (shield != null)
        {
            shield.Activate();
            PickupParticle();
            Destroy(gameObject);
        }
    }
}
