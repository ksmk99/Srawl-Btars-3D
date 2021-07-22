using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMen : Unit
{
    private float lifeTime = 4f;
    private Shield shieldPrefab;

    public override void SetVariant(string variant)
    {
        shieldPrefab = Resources.Load<Shield>("Abilities/Shield/" + variant);
    }

    private void Start()
    {
        var shields = Resources.LoadAll<Shield>("Abilities/Shield");
        shieldPrefab = shields[Random.Range(0, shields.Length)];
    }

    protected override void UnitAction()
    {
        var shield = Instantiate(shieldPrefab, transform);
        shield.transform.localPosition = shieldPrefab.transform.localPosition;
        shield.Activate();
        Destroy(shield.gameObject, lifeTime);
    }
}
