using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerShooter : UnitShooter
{
	[SerializeField] private VariableJoystick shooterJoystick;

	private Animator animator;

    public override bool IsShooting => false;

    protected override void Start()
    {
		base.Start();
		animator = GetComponent<Animator>();

		shooterJoystick.OnTouchEnd += Shoot; 
	}

	private void Shoot(Vector3 direction)
    {
		if (!weaponReload.Shoot() || !canShoot) return;
		if(direction == new Vector3(0,0,0) && CanSeeEnemy())
        {
			GetEnemy();
			if(HaveEnemy)
            {
				var agent = target.GetComponent<NavMeshAgent>();
				var lookTarget = target.position + 
					(agent == null ? Vector3.zero :agent.velocity.normalized);
				transform.LookAt(lookTarget);
			}
        }
		weaponChanger.Weapon.Shoot();
    }
}
