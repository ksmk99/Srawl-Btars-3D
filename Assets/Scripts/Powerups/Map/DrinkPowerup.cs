using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrinkPowerup : Powerup
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float time = 4f;

    protected override void OnTriggerEnter(Collider other)
    {
        var movement = other.GetComponent<Movement>();
        if(movement != null)
        {
            movement.UpdateSpeed(speed);
            PickupParticle();
            transform.localScale = new Vector3();
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(NormolizeSpeed(movement));
        }
    }

    private IEnumerator NormolizeSpeed(Movement movement)
    {
        yield return new WaitForSeconds(time);
        movement?.UpdateSpeed(0, true);
        Destroy(gameObject);
    }
}
