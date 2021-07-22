using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityVariant : MonoBehaviour
{
    public string Variant { get; private set; }

    [SerializeField] private TMP_Text label;

    private TMP_Dropdown dropdown;

    public void SetVariants(string value)
    {
        var options = new string[2];
        switch(value)
        {
            case "TURRET":
                {
                    options[0] = "RIFLE";
                    options[1] = "RPG";
                    break;
                }
            case "SHIELD":
                {
                    options[0] = "BACK";
                    options[1] = "FRONT";
                    break;
                }
            case "TANK":
                {
                    options[0] = "COUNT";
                    options[1] = "RELOAD";
                    break;
                }
            case "SPEED":
                {
                    options[0] = "DURATION";
                    options[1] = "RELOAD";
                    break;
                }
            case "FIRE LINE":
                {
                    options[0] = "RIFLE";
                    options[1] = "RPG";
                    break;
                }
        }

        dropdown.ClearOptions();
        foreach (var option in options)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(option));
        }
        dropdown.value = 0;
        Variant = dropdown.options[0].text;
        label.text = Variant;
    }

    private void Awake()
    {
        dropdown = GetComponentInChildren<TMP_Dropdown>();
    }
}
