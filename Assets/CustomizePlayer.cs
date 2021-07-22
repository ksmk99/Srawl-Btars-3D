using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizePlayer : MonoBehaviour
{
    private void Awake()
    {
        var data = Resources.Load<TextAsset>("UnitData");
        var unitData = JsonUtility.FromJson<UnitData>(data.text);

        ChooseWeapon(unitData.GunName);
        SelectAbility(unitData.Ability, unitData.Variant);
    }

    private void ChooseWeapon(string gunName)
    {
        var weaponChanger = GetComponentInChildren<WeaponChanger>();
        weaponChanger.ChangeWeapon(gunName);
    }

    private void SelectAbility(string ability, string variant)
    {
        switch (ability)
        {
            case "TURRET":
                {
                    var unit = gameObject.AddComponent<TurretUnit>();
                    unit.SetVariant(variant);
                    break;
                }
            case "SHIELD":
                {
                    var unit = gameObject.AddComponent<ShieldMen>();
                    unit.SetVariant(variant);
                    break;
                }
            case "TANK":
                {
                    var unit = gameObject.AddComponent<TankUnit>();
                    unit.SetVariant(variant);
                    break;
                }
            case "SPEED":
                {
                    var unit = gameObject.AddComponent<StrafeUnit>();
                    unit.SetVariant(variant);
                    break;
                }
            case "FIRE LINE":
                {
                    var unit = gameObject.AddComponent<ShotgunUnit>();
                    unit.SetVariant(variant);
                    break;
                }
        }
    }
}
