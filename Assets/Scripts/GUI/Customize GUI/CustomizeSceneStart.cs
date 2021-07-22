using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomizeSceneStart : MonoBehaviour
{
    [SerializeField] private WeaponChoose weaponChoose;
    [SerializeField] private AbilityChoose abilityChoose;
    [SerializeField] private AbilityVariant abilityVariant;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadMainLEvel);
    }

    private void LoadMainLEvel()
    {
        Save();
        SceneManager.LoadScene(1);
    }

    private void Save()
    {
        var unitData = new UnitData(weaponChoose.GunName,
            abilityChoose.Ability, abilityVariant.Variant);

        var data = JsonUtility.ToJson(unitData);
        var path = Application.dataPath + "/Resources/Unit.json";

        StreamWriter sw = File.CreateText(path);
        sw.Close();

        File.WriteAllText(path, data);
    }
}

[System.Serializable]
public class UnitData
{
    public string GunName;
    public string Ability;
    public string Variant;

    public UnitData(string gunName, string ability, string variant)
    {
        GunName = gunName;
        Ability = ability;
        Variant = variant;
    }
}
