using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloadGUI : MonoBehaviour
{
    [SerializeField] private ReloadCell reloadCellPrefab;
    [SerializeField] private WeaponChanger weaponChanger;

    private UnitShooter shooter;
    private List<ReloadCell> reloadCells = new List<ReloadCell>();

    private bool isReloading;
    private float reloadValue;
    private ReloadCell reloadingCell;


    private void Start()
    {
        shooter = GetComponentInParent<UnitShooter>();
        CellsSetUp();

        GetComponentInParent<Health>().OnDeath += () => StopAllCoroutines();
    }

    private void CellsSetUp()
    {
        for (int i = 0; i < weaponChanger.Weapon.WeaponData.CellCount; i++)
        {
            var cell = Instantiate(reloadCellPrefab, transform);
            reloadCells.Add(cell);
        }
        reloadCells.Reverse();
    }

    public bool Shoot()
    {
        for (int i = 0; i < reloadCells.Count; i++)
        {
            if(reloadCells[i].CanShoot)
            {
                if(reloadingCell != null)
                {
                    reloadingCell.SetReloadValue(0);
                }
                reloadingCell = reloadCells[i];
                if (!isReloading)
                {
                    StartCoroutine(CellReload());
                }
                return true;
            }
        }     
        
        return false;
    }

    public bool CanShoot()
    {
        for (int i = 0; i < reloadCells.Count; i++)
        {
            if (reloadCells[i].CanShoot)
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator CellReload()
    {
        isReloading = true;
        var startTime = Time.time;
        while (reloadValue < 1)
        {
            reloadValue = (Time.time - startTime) / weaponChanger.Weapon.WeaponData.ReloadTime;
            reloadingCell.SetReloadValue(reloadValue);
            yield return new WaitForEndOfFrame();
        }

        reloadValue = 0;
        reloadingCell.SetReloadValue(1);
        isReloading = false;

        for (int i = reloadCells.Count - 1; i > -1; i--)
        {
            if (!reloadCells[i].CanShoot)
            {
                reloadingCell = reloadCells[i];
                StartCoroutine(CellReload());
                break;
            }
        }
    }

}
