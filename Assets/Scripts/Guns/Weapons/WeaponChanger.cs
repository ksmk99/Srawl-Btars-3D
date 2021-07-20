using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    public Weapon Weapon { get; private set; }

    public Transform ShootPoint => shootPoint;

    [SerializeField] private Weapon[] weapons;

    [SerializeField] private Transform shootPoint;
    [SerializeField] private WeaponReloadGUI weaponReload;

    private void Awake()
    {
        Weapon = weapons.Where(x => x.gameObject.activeSelf).FirstOrDefault();
        Weapon.SetComponents(shootPoint, weaponReload);
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
                Weapon.SetComponents(shootPoint, weaponReload);
                break;
            }
        }
    }
}
