using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UnitShooter : MonoBehaviour
{
	public abstract bool IsShooting { get; }
	public bool HaveEnemy => target != null;

	public Weapon Weapon => weaponChanger.Weapon;
	public Transform Target => target;

	[Header("Settings")]
	[SerializeField] protected float visibleRange = 20f;
	[Header("Layers")]
	[SerializeField] protected LayerMask enemyLayer;
	[SerializeField] protected LayerMask bulletLayer;
	[SerializeField] private LayerMask obstaclesLayer;

	protected WeaponChanger weaponChanger;
	protected Transform target;
	protected Health health;
	protected WeaponReloadGUI weaponReload;

	protected float turnSmoothVelocity;
	protected bool canShoot;

	protected virtual void Start()
	{
		SetComponents();
		EventSubscribe();
	}

	protected virtual void GetEnemy()
	{
		var targets = Physics.OverlapSphere(transform.position, visibleRange, enemyLayer.value)
			.Where(x => x.transform != transform)
			.Select(x => x.transform)
			.ToArray();

		if (targets.Length == 0)
		{
			target = null;
			return;
		}

		target = CalculateNearestTarget(targets);
	}

	protected Transform CalculateNearestTarget(Transform[] targets)
    {
		Transform result = null;
		var minDistance = float.MaxValue;

		for (int i = 0; i < targets.Length; i++)
		{
			
			var distance = Vector3.Distance(transform.position, targets[i].position);
			if (distance < minDistance)
			{
				result = targets[i];
				minDistance = distance;
			}
		}

		return result;
	}

	protected bool CanSeeEnemy()
	{
		if (target == null) return true;
		RaycastHit hit;
		return !Physics.Linecast(transform.position, target.position, out hit, obstaclesLayer.value);
	}

	private void SetComponents()
    {
		weaponReload = GetComponentInChildren<WeaponReloadGUI>();
		weaponChanger = GetComponentInChildren<WeaponChanger>();
		health = GetComponent<Health>();
	}

	private void EventSubscribe()
	{
		GetComponent<Health>().OnDeath += () => canShoot = false;
		GameManager.Instance.OnGameStart += () => canShoot = true;
		GameManager.Instance.OnGameLoose += () => canShoot = false;
		GameManager.Instance.OnGameWin += () => canShoot = false;
	}

	private void OnDestroy()
	{
		GetComponent<Health>().OnDeath -= () => canShoot = false;
		GameManager.Instance.OnGameStart -= () => canShoot = true;
		GameManager.Instance.OnGameLoose -= () => canShoot = false;
		GameManager.Instance.OnGameWin -= () => canShoot = false;
	}
}