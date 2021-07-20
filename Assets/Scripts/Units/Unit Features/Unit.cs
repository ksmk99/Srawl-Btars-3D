using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public bool CanDoAction => Time.time - nextUseTime > 0;

    [SerializeField] private float reloadTime = 10f;

    private float nextUseTime;

    public void MakeAction()
    {
        if (CanDoAction)
        {
            UnitAction();
            ReloadAction();
        }
    }

    protected abstract void UnitAction();

    protected virtual void Awake()
    {
        if (GetComponent<AIMovement>() != null)
        {
            GetComponent<Health>().OnDeath += MakeAction;
        }
    }

    private void ReloadAction()
    {
        nextUseTime = Time.time + reloadTime;
    }
}
