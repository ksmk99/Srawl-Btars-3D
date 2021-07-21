using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : Movement
{
	public Vector3 MoveDirection { get; private set; }

	public override bool IsMoving => MoveDirection.sqrMagnitude != 0;

	[SerializeField] private VariableJoystick movementJoystick;
	[SerializeField] private VariableJoystick shooterJoystick;

	protected override void Start()
	{
		base.Start();
		agent.updateRotation = true;
	}

	protected override void Move()
	{
		MoveDirection = new Vector3(movementJoystick.Horizontal, 0, movementJoystick.Vertical);
		agent.Move(MoveDirection * speed * Time.deltaTime);
		UpdateRotation();
	}

	private void UpdateRotation()
    {
		if(shooterJoystick.Direction.sqrMagnitude != 0)
        {
			var shootingDirection = new Vector3(shooterJoystick.Horizontal, 0, shooterJoystick.Vertical);
			transform.LookAt(transform.position + shootingDirection);
		}
		else
        {
			transform.LookAt(transform.position + MoveDirection);
		}
    }
}
