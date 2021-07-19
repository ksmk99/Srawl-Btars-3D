using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Text healthCount;

    private Health health;
    private int maxHealth;

    private void Start()
    {
        health = GetComponentInParent<Health>();
        maxHealth = health.HealthCount;

        health.OnDamage += Damage;
        health.OnDeath += Damage;
    }

    private void Damage()
    {
        var amount = (float)health.HealthCount / maxHealth;
        healthBar.fillAmount = (float)health.HealthCount / maxHealth;
        healthCount.text = health.HealthCount.ToString();
    }
}