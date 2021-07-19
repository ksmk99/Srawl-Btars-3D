using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimations : MonoBehaviour
{
	private UnitShooter shooter;
	private Movement movement;
	private Animator animator;

	public void Start()
	{
		shooter = GetComponent<UnitShooter>();
		movement = GetComponent<Movement>();
		animator = GetComponent<Animator>();

		GetComponent<Health>().OnDeath += () => animator.SetBool("IsDead", true);
	}

	private void LateUpdate()
	{
		animator.SetBool("IsMoving", movement.IsMoving);
		animator.SetBool("IsShooting", shooter.IsShooting);
	}
}
