using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityChoose : MonoBehaviour
{
    public string Ability { get; private set; }

    [SerializeField] private AbilityVariant abilityVariant;

    private TMP_Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponentInChildren<TMP_Dropdown>();

        dropdown.onValueChanged.AddListener((x) => Ability = dropdown.options[x].text);
        dropdown.onValueChanged.AddListener((x) => abilityVariant.SetVariants(Ability));

        Ability = dropdown.options[0].text;
        abilityVariant.SetVariants(Ability);
    }
}
