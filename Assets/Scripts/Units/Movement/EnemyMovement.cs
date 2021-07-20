using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyShooter))]
public class EnemyMovement : Movement
{
    public override bool IsMoving => agent.stoppingDistance <= distanceToTarget;

    private EnemyShooter shooter;
    private Transform target;

    private float maxWalkDistance = 50f;
    private float distanceToTarget;
    private float stoppingDistance;
    private bool needPowerup;

    private void Start()
    {
        stoppingDistance = agent.stoppingDistance;
        target = transform;
        shooter = GetComponent<EnemyShooter>();
        GetTarget();

        GetComponent<Health>().OnDamage += () =>
        {
            if (Random.Range(0, 4) == 0)
            {
                needPowerup = true;
                agent.stoppingDistance = 0.1f;
                GetTarget(true);
            }
        };
    }

    protected override void Move()
    {
        if (shooter.HaveEnemy && !needPowerup)
        {
            distanceToTarget = Vector3.Distance(transform.position, shooter.Target.position);
            if (agent.stoppingDistance * 1.2f < distanceToTarget)
            {
                agent.SetDestination(shooter.Target.position);
            }
        }
        else
        {
            distanceToTarget = Vector3.Distance(transform.position, agent.destination);
            if (agent.stoppingDistance > distanceToTarget)
            {
                needPowerup = false;
                agent.stoppingDistance = stoppingDistance;
                GetTarget();
            }
        }
    }


    private void GetTarget(bool needPowerup = false)
    {
        var position = PointsOfInterest.Instance.GetPoint(target.position, needPowerup);
        agent.SetDestination(position);
    }
}
