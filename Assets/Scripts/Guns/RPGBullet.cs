using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGBullet : Bullet
{
    [SerializeField] private ParticleSystem boomParticle;

    protected override void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<Health>();
        if (health != null)
        {
            var units = Physics.OverlapSphere(transform.position, 1f);
            foreach (var unit in units)
            {
                unit.GetComponent<Health>()?.Damage();
            }
            Instantiate(boomParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
