using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyUnit : Unit
{
    [SerializeField] private GameObject unit;

    private Vector3[] positions = new Vector3[4]
    {
        new Vector3(2, 0, 2),
        new Vector3(-2, 0, 2),
        new Vector3(2, 0, -2),
        new Vector3(-2, 0, -2),
    };

    protected override void UnitAction()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(unit, transform.position + positions[i], Quaternion.identity);
        }
    }
}
