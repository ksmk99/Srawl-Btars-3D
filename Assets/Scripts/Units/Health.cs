using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool IsDead { get; private set; }

    public int HealthCount => healthCount;

    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnDamage;

    [SerializeField] private int healthCount = 5;

    private int maxHealth;

    private void Awake()
    {
        maxHealth = healthCount;
    }

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

    public void Heal(int count)
    {
        healthCount += count;
        healthCount = healthCount > maxHealth ? maxHealth : healthCount;
        OnHeal?.Invoke();
    }
}
