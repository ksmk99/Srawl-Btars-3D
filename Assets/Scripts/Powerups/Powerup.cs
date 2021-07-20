using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    [SerializeField] private float destroyTime = 15f;
    [SerializeField] private ParticleSystem pickupParticle;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    protected abstract void OnTriggerEnter(Collider other);

    protected void PickupParticle()
    {
        Instantiate(pickupParticle, transform.position + Vector3.up * 2, Quaternion.identity);
    }
}
