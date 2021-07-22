using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public float ReloadTime { get; protected set; }

    private float nextUseTime;

    public abstract void SetVariant(string variant);

    public void MakeAction()
    {
        if (Time.time - nextUseTime > 0)
        {
            UnitAction();
            nextUseTime = Time.time + ReloadTime;
        }
    }

    protected abstract void UnitAction();

    protected virtual void Awake()
    {
        ReloadTime = 10;
        nextUseTime = Time.time;
        if (GetComponent<AIMovement>() != null)
        {
            GetComponent<Health>().OnDamage += MakeAction;
        }
    }
}
