using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    public event Action OnPickup;

    [SerializeField] private ParticleSystem pickupParticle;

    protected abstract void OnTriggerEnter(Collider other);

    protected void PickupParticle()
    {
        OnPickup?.Invoke();
        Instantiate(pickupParticle, transform.position + Vector3.up * 2, Quaternion.identity);
    }
}
