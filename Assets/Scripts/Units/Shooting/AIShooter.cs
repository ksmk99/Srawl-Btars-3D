using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AIShooter : UnitShooter
{
	public override bool IsShooting => HaveEnemy && CanSeeEnemy();

	private NavMeshAgent agent;

    protected override void Start()
    {
		base.Start();
		agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
	{
		if (canShoot)
		{
			GetEnemy();
			LookAtTarget();
		}
	}

	private void LateUpdate()
	{
		if (canShoot && HaveEnemy && CanSeeEnemy())
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

	protected override void GetEnemy()
	{
		var targets = Physics.OverlapSphere(transform.position, visibleRange, enemyLayer.value)
			.Where(x => x.transform != transform
			&& x.GetComponent<TurretShooter>()?.Owner != transform)
			.Select(x => x.transform)
			.ToArray();

		target = targets.Length == 0 ? null : CalculateNearestTarget(targets);
	}
}
