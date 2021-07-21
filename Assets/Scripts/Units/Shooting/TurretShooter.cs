using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretShooter : UnitShooter
{
	public override bool IsShooting => HaveEnemy && CanSeeEnemy();

	public Transform Owner { get; private set; }

	public void SetOwner(Transform owner) => Owner = owner;

	private void Update()
	{
		if (health.IsDead) return;

		GetEnemy();
		LookAtTarget();
	}

	private void LateUpdate()
	{
		if (HaveEnemy && !health.IsDead && CanSeeEnemy())
		{
			weaponChanger.Weapon.Shoot();
		}
	}

	protected void LookAtTarget()
	{
		if (!HaveEnemy) return;
		transform.LookAt(target.position);
	}

	protected override void GetEnemy()
	{
		var targets = Physics.OverlapSphere(transform.position, visibleRange, enemyLayer.value)
			.Where(x => x.transform != transform
			    && x.transform != Owner
			    && x.GetComponent<TurretShooter>()?.Owner != Owner)
			.Select(x => x.transform)
			.ToArray();

		if (targets.Length == 0)
		{
			target = null;
			return;
		}

		target = CalculateNearestTarget(targets);
	}
}
