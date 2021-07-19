using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadCell : MonoBehaviour
{
    public bool CanShoot { get; private set; }

    [SerializeField] private Image reloadBar;

    private WeaponReloadGUI weaponReload;
    private float reloadTime;

    private void Awake()
    {
        weaponReload = GetComponentInParent<WeaponReloadGUI>();
    }

    public void ReloadTimeSetUp(float time)
    {
        CanShoot = true;
        reloadTime = time;
    }

    public void Shoot()
    {
        if (!CanShoot)
            StopAllCoroutines();

        reloadBar.fillAmount = 0;
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        CanShoot = false;
        var startTime = Time.deltaTime;
        while(reloadBar.fillAmount != 1)
        {
            reloadBar.fillAmount = (Time.deltaTime - startTime) / reloadTime;
            yield return new WaitForEndOfFrame();
        }
        CanShoot = true;
        weaponReload.ReloadEnd();
    }
}
