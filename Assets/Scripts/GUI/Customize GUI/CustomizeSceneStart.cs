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
        PlayerPrefs.SetString("GunName", weaponChoose.GunName);
        PlayerPrefs.SetString("Ability", abilityChoose.Ability);
        PlayerPrefs.SetString("Variant", abilityVariant.Variant);
    }
}
