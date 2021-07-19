using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject weaponModel;

    [Range(0.01f, 5f)]
    [SerializeField]private float fireRate;
    [Range(1, 5)]
    [SerializeField] private int cellCount;


    public int CellCount => cellCount;
    public float FireRate => fireRate;

    public string WeaponName => weaponName;

    public Sprite Icon => icon;

    public GameObject WeaponModel => weaponModel;

    public GameObject Bullet
    {
        get
        {
            if (bullet.GetComponent<Bullet>())
                return bullet;
            throw new ArgumentException();
        }
    }
}
