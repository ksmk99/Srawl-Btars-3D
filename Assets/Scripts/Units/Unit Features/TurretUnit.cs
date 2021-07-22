using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUnit : Unit
{
    private Turret turret;

    public override void SetVariant(string variant)
    {
        turret = Resources.Load<Turret>("Abilities/Turret/" + variant);
    }

    protected override void UnitAction()
    {
        var unit = Instantiate(turret, transform.position + new Vector3(2, 1, 2), Quaternion.identity);
        unit.GetComponentInChildren<TurretShooter>().SetOwner(transform);
    }
}
