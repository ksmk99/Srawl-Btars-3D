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

    private void Start()
    {
        var data = Resources.LoadAll<Turret>("Abilities/Turret");
        turret = data[Random.Range(0, data.Length)];
    }

    protected override void UnitAction()
    {
        var unit = Instantiate(turret, transform.position + new Vector3(2, 1, 2), Quaternion.identity);
        var turretShooter = unit.GetComponentInChildren<TurretShooter>();
        turretShooter.SetOwner(transform);
    }
}
