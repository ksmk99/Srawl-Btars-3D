using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool IsDead { get; private set; }

    public int HealthCount => healthCount;

    public event Action OnDeath;
    public event Action OnDamage;

    [SerializeField] private int healthCount = 5;

    public void Damage()
    {
        if (IsDead) return;

        healthCount--;
        if (healthCount <= 0)
        {
            IsDead = true;
            GetComponent<CapsuleCollider>().enabled = false;
            OnDeath?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
        }
    }
}
