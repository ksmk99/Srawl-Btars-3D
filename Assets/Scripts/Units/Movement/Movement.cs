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

	protected virtual void Awake()
    {
		SetComponents();
	}

	protected virtual void Update()
    {
        Move();
    }

	protected abstract void Move();

	protected virtual void SetComponents()
    {
		agent = GetComponent<NavMeshAgent>();
	}
}
