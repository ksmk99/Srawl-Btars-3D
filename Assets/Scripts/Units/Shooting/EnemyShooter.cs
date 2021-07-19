using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : UnitShooter
{
	protected override void Start()
	{
		base.Start();
		GameManager.Instance.OnGameLoose += () => IsShooting = false;
	}
}
