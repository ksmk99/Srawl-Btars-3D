using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool IsDead { get; private set; }
    public bool CanDie { get; set; }

    private void Awake()
    {
        CanDie = true;
    }

    public void Damage()
    {
        //if (!IsDead && !GameManager.Instance.IsGameEnd && CanDie)
        //{
        //    IsDead = true;
        //    GetComponent<Unit>().Death();
        //}
    }
}
