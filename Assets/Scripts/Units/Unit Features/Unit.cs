using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private float reloadTime = 10f;

    private float nextUseTime;

    public void MakeAction()
    {
        if (Time.time - nextUseTime > 0)
        {
            UnitAction();
            nextUseTime = Time.time + reloadTime;
        }
    }

    protected abstract void UnitAction();

    protected virtual void Awake()
    {
        nextUseTime = Time.time;
        if (GetComponent<AIMovement>() != null)
        {
            GetComponent<Health>().OnDamage += MakeAction;
        }
    }
}
