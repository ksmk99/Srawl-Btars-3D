using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChoose : MonoBehaviour
{
    public string GunName { get; private set; }

    private TMP_Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponentInChildren<TMP_Dropdown>();
        dropdown.onValueChanged.AddListener(
            (x) =>
            {
                GunName = dropdown.options[x].text;
            });
        GunName = dropdown.options[0].text;
    }
}
