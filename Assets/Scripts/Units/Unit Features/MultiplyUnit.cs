using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyUnit : Unit
{
    [SerializeField] private GameObject unitPrefab;

    private Vector3[] positions = new Vector3[4]
    {
        new Vector3(2, 0, 2),
        new Vector3(-2, 0, 2),
        new Vector3(2, 0, -2),
        new Vector3(-2, 0, -2),
    };

    public override void SetVariant(string variant)
    {
        return;
    }

    protected override void Awake()
    {
        ReloadTime = 10;
        if (GetComponent<AIMovement>() != null)
        {
            GetComponent<Health>().OnDeath += MakeAction;
        }
    }

    protected override void UnitAction()
    {
        for (int i = 0; i < 4; i++)
        {
            var unit = Instantiate(unitPrefab, transform.position + positions[i], Quaternion.identity);
            unit.transform.parent = transform.parent;
        }
    }
}
