using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMen : Unit
{
    [SerializeField] private Shield shield;

    protected override void UnitAction()
    {
        shield.Activate();
    }
}
