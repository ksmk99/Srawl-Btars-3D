using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimations : MonoBehaviour
{
	private Movement movement;
	private Animator animator;

	public void Start()
	{
		movement = GetComponentInParent<Movement>();
		animator = GetComponent<Animator>();
	}

	private void LateUpdate()
	{
		animator.SetBool("IsMoving", movement.IsMoving);
	}
}
