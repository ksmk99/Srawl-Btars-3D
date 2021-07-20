using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIShooter : UnitShooter
{
	public override bool IsShooting => HaveEnemy && CanSeeEnemy(target.position);

	private NavMeshAgent agent;

    private void Start()
    {
		agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
	{
		if (health.IsDead) return;

		GetEnemy();
		LookAtTarget();
	}

	private void LateUpdate()
	{
		if (HaveEnemy && !health.IsDead &&
			CanSeeEnemy(target.position))
		{
			weaponChanger.Weapon.Shoot();
		}
	}

	protected void LookAtTarget()
	{
		var direction = !HaveEnemy ?
			transform.position + agent.velocity :
			target.position;
		transform.LookAt(direction);
	}
}
