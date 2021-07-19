using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloadGUI : MonoBehaviour
{
    [SerializeField] private ReloadCell reloadCell;
    [SerializeField] private WeaponChanger weaponChanger;

    private UnitShooter shooter;
    private List<ReloadCell> reloadCells = new List<ReloadCell>();

    public void ReloadEnd()
    {
        for (int i = reloadCells.Count - 1; i > -1; i--)
        {
            if(!reloadCells[i].CanShoot)
            {
                reloadCells[i].Shoot();
                return;
            }
        }
    }

    private void Start()
    {
        shooter = GetComponentInParent<UnitShooter>();
        CellsSetUp();
    }

    private void CellsSetUp()
    {

        for (int i = 0; i < weaponChanger.Weapon.WeaponData.CellCount; i++)
        {
            var cell = Instantiate(reloadCell, transform);
            cell.ReloadTimeSetUp(weaponChanger.Weapon.WeaponData.FireRate);
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
                for (int j = i; j > -1; j--)
                {
                    reloadCells[j].Shoot();
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

}
