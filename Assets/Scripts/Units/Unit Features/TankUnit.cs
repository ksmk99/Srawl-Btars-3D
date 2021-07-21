using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUnit : Unit
{
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    protected override void UnitAction()
    {
        health.Heal(100);
    }
}
