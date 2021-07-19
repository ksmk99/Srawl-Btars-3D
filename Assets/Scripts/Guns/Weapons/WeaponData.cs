using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private string weaponName;
    [SerializeField]
    private string description;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject weaponModel;
    [SerializeField]
    [Range(0.01f, 5f)]
    private float fireRate;
    [SerializeField]
    [Range(0.01f, 5f)]
    private float minFireRate;

    public float FireRate { get => fireRate; }
    public float MinFireRate { get => minFireRate; }

    public string WeaponName { get => weaponName; }

    public string Description { get => description; }

    public Sprite Icon { get => icon; }

    public GameObject Bullet
    {
        get
        {
            if (bullet.GetComponent<Bullet>())
                return bullet;
            throw new ArgumentException();
        }
    }

    public GameObject WeaponModel { get => weaponModel; }
}
