using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerShooter : UnitShooter
{
	[SerializeField] private VariableJoystick shooterJoystick;

	private Animator animator;

    public override bool IsShooting => false;

    protected void Start()
    {
		animator = GetComponent<Animator>();

		shooterJoystick.OnTouchEnd += Shoot; 
	}

	private void Shoot(Vector3 direction)
    {
		if (!weaponReload.Shoot() || !canShoot) return;
		if(direction == new Vector3(0,0,0))
        {
			GetEnemy();
			if(HaveEnemy)
            {
				transform.LookAt(target.position);
            }
        }
		weaponChanger.Weapon.Shoot();
    }
}
