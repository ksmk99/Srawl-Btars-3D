using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticle;
    [SerializeField] private float lifeTime = 7.5f;

    private void Awake()
    {
        GetComponentInChildren<Health>().OnDeath += Death;
        StartCoroutine(LifeTimer());
    }

    private IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Death();
    }

    private void Death()
    {
        Instantiate(deathParticle, transform.position + Vector3.up * 2, Quaternion.identity);
        Destroy(gameObject);
    }
}
