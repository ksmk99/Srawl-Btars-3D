using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Movement : MonoBehaviour
{
	public abstract bool IsMoving { get; }
	public float Speed => speed;

	[SerializeField] protected float speed = 5f;

	protected NavMeshAgent agent;
	protected bool canMove = true;

	private float startSpeed;

	public void UpdateSpeed(float speed, bool resetSpeed = false)
	{
		this.speed = resetSpeed ? startSpeed : speed;
	}

	protected virtual void Awake()
    {
		startSpeed = speed;
		SetComponents();
		GetComponent<Health>().OnDeath += () => canMove = false;
	}

	protected virtual void Update()
    {
		if (canMove)
		{
			Move();
		}
		else
        {
			agent.velocity = Vector3.zero;
			agent.isStopped = true;
		}
    }

	protected abstract void Move();

	protected virtual void SetComponents()
    {
		agent = GetComponent<NavMeshAgent>();
	}
}
