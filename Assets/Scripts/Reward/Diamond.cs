using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private ParticleSystem collectParticle;

    private bool isCollecting;
    private float power;

    private Rigidbody rigidbody;
    private Transform target;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Collect(Transform target, float power)
    {
        if(isCollecting) return;
        isCollecting = true;
        this.target = target;
        this.power = power;
        StartCoroutine(Collect());
        StartCoroutine(Destroy(1.2f));
    }

    private IEnumerator Collect()
    {
        var time = 0f;
        while(time < 1)
        {
            yield return new WaitForFixedUpdate();
            transform.position = Vector3.Lerp(transform.position, target.position + Vector3.up, time);
            time += 0.1f;
        }
        StartCoroutine(Destroy(0));
    }

    private IEnumerator Destroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Money.Instance.AddMoney(1);
        Instantiate(collectParticle, transform.position, Quaternion.identity).transform.parent = 
            PlayerMovement.Instance.transform;
        Destroy(gameObject);
    }
}
