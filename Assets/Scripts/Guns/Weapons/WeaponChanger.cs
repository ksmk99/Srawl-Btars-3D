using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    public Weapon Weapon { get; private set; }

    [SerializeField] private Weapon[] weapons;

    private void Awake()
    {
        Weapon = weapons.Where(x => x.gameObject.activeSelf).FirstOrDefault();
    }

    public void ChangeWeapon(WeaponData data)
    {
        foreach (var weapon in weapons)
        {
            if(weapon.WeaponData == data)
            {
                Weapon.gameObject.SetActive(false);
                weapon.gameObject.SetActive(true);
                Weapon = weapon;
                break;
            }
        }
    }
}
