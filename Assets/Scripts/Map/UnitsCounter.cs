using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitsCounter : MonoBehaviour
{
    private List<Unit> units;

    private void Start()
    {
        units = GetComponentsInChildren<Unit>().ToList();
        foreach (var unit in units)
        {
            unit.GetComponent<Health>().OnDeath += () =>
            {
                units.Remove(unit);
                if(unit.GetComponent<PlayerMovement>())
                {
                    GameManager.Instance.GameLoose();
                }
                else if(units.Count == 1)
                {
                    GameManager.Instance.GameWin();
                }
            };

        }
    }
}