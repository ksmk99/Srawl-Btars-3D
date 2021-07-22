using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUnit : Unit
{
    private Health health;
    private int count;

    public override void SetVariant(string variant)
    {
        switch (variant)
        {
            case "COUNT":
                {
                    count = 5;
                    ReloadTime = 10;
                    break;
                }
            case "RELOAD":
                {
                    count = 2;
                    ReloadTime = 5;
                    break;
                }
        }
    }

    private void Start()
    {
        health = GetComponent<Health>();
    }

    protected override void UnitAction()
    {
        health.Heal(count);
    }
}
