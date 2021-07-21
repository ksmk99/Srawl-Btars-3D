using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMen : Unit
{
    [SerializeField] private float lifeTime;
    [SerializeField] private Shield shieldPrefab;

    protected override void UnitAction()
    {
        var shield = Instantiate(shieldPrefab, transform);
        shield.Activate();
        Destroy(shield.gameObject, lifeTime);
    }
}
