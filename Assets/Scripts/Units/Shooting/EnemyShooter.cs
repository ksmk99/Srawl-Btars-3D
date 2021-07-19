using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : UnitShooter
{
	[SerializeField] private LayerMask obstaclesLayer;

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
		//var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		//var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
		//	ref turnSmoothVelocity, turnSmoothTime);

		//transform.rotation = Quaternion.Euler(0f, angle, 0f);
	}

    private bool CanSeeEnemy(Vector3 position)
    {
        RaycastHit hit;
		return !Physics.Linecast(transform.position, position, out hit, obstaclesLayer.value);
    }
}
