using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitShooter : MonoBehaviour
{
	public bool IsShooting { get;set; }

	[Header("Settings")]
	[SerializeField] protected float turnSmoothTime = 0.2f;
	[SerializeField] protected LayerMask enemyLayer;
	[SerializeField] protected LayerMask bulletLayer;
	[SerializeField] protected float visibleRange = 20f;

	protected Weapon weapon;
	protected Transform target;
	protected Health health;

	protected float turnSmoothVelocity;
	protected bool haveEnemy;

	public void UpdateWeapon(Weapon data)
	{
		weapon = data;
	}

	protected virtual void Start()
    {
		weapon = GetComponentInChildren<WeaponChanger>().Weapon;
		health = GetComponent<Health>();
    }

    protected virtual void Update()
	{
		if (IsShooting && !health.IsDead)
		{
			if (!haveEnemy || target == null)
				haveEnemy = GetEnemy();
			else
				LookAtTarget();
		}
	}

	protected virtual void LateUpdate()
	{
		if (haveEnemy && IsShooting && !health.IsDead)
		{
			weapon.Shoot((int)Mathf.Log(bulletLayer.value, 2));
		}
	}

	protected void LookAtTarget()
	{
		var direction = target.transform.position - transform.position;
		var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
			ref turnSmoothVelocity, turnSmoothTime);
		transform.rotation = Quaternion.Euler(0f, angle, 0f);
	}

	private bool GetEnemy()
	{
		var targets = Physics.OverlapSphere(transform.position, visibleRange, enemyLayer);
		if (targets.Length == 0)
			return false;
		target = targets[Random.Range(0, targets.Length)].transform;
		return target != null;
	}

	//protected bool CanSeeEnemy(Vector3 position)
	//{
	//	RaycastHit hit;
	//	if (Physics.Linecast(transform.position, position, out hit, 1 << 6))
	//	{
	//		Debug.DrawLine(transform.position, position, Color.yellow);
	//		var sas = hit.collider.gameObject.layer != 6;
	//		return hit.collider.gameObject.layer != 6;
	//	}
	//	return true;
	//}
}
