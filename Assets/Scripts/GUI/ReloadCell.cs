using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadCell : MonoBehaviour
{
    public bool CanShoot => reloadBar.fillAmount == 1;

    [SerializeField] private Image reloadBar;

    private void Start()
    {
        reloadBar.fillAmount = 1;
    }

    public void SetReloadValue(float value)
    {
        reloadBar.fillAmount = value;
    }
}
