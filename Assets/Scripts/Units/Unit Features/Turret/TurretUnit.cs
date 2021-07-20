using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUnit : Unit
{
    [SerializeField] private Turret turret;
    protected override void UnitAction()
    {
        var unit = Instantiate(turret, transform.position, Quaternion.identity);
        unit.GetComponentInChildren<TurretShooter>().SetOwner(transform);
    }
}
