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
	protected bool canMove;

	private float startSpeed;

	public void UpdateSpeed(float speed, bool resetSpeed = false)
	{
		this.speed = resetSpeed ? startSpeed : speed;
		agent.speed = this.speed;
	}

	protected virtual void Start()
    {
		startSpeed = speed;
		SetComponents();
		EventSubscribe();
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

	private void EventSubscribe()
    {
		GameManager.Instance.OnGameStart += () =>
		{
			agent.isStopped = false;
			canMove = true;
		};
		GameManager.Instance.OnGameLoose += () => canMove = false;
		GameManager.Instance.OnGameWin += () => canMove = false;
		GetComponent<Health>().OnDeath += () => canMove = false;
	}

    private void OnDestroy()
    {
		GameManager.Instance.OnGameStart -= () =>
		{
			agent.isStopped = false;
			canMove = true;
		};
		GameManager.Instance.OnGameLoose -= () => canMove = false;
		GameManager.Instance.OnGameWin -= () => canMove = false;
		GetComponent<Health>().OnDeath -= () => canMove = false;
	}
}
