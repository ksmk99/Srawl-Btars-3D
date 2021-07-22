using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeUnit : Unit
{
    private float speed = 10f;
    private float speedUpTime = 4f;

    private float minTime = 10f;
    private float maxTime = 15f;

    private Movement movement;


    public override void SetVariant(string variant)
    {
        switch(variant)
        {
            case "DURATION":
                {
                    speed = 8;
                    speedUpTime = 6;
                    break;
                }
            case "RELOAD":
                {
                    speed = 10;
                    speedUpTime = 4;
                    break;
                }
        }
    }

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
