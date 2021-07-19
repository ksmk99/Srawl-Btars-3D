using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BrainMovement : Movement
{
	public static BrainMovement Instance { get; private set; }

	public Vector3 MoveDirection { get; private set; }

	public override bool IsMoving => MoveDirection.sqrMagnitude != 0;

	[SerializeField] private VariableJoystick joystick;

	private bool canMove = true;

	private void Start()
	{
		Instance = this;
		agent.updateRotation = true;
	}

	protected override void Move()
	{
		if (canMove)
		{
			MoveDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
			agent.Move(MoveDirection * speed * Time.deltaTime);
			transform.LookAt(transform.position + MoveDirection);
		}
	}
}
