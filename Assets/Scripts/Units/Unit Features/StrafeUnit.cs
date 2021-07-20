using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeUnit : Unit
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedUpTime = 4f;

    private float minTime = 10f;
    private float maxTime = 15f;

    private Movement movement;

    protected override void UnitAction()
    {
        StopAllCoroutines();
        StartCoroutine(SpeedUp());
    }

    protected override void Awake()
    {
        movement = GetComponent<Movement>();
        UnitAction();

        base.Awake();
    }

    private IEnumerator SpeedUp(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        movement.UpdateSpeed(speed);
        yield return new WaitForSeconds(speedUpTime);
        movement.UpdateSpeed(0, true);
        StartCoroutine(SpeedUp(Random.Range(minTime, maxTime)));
    }
}
