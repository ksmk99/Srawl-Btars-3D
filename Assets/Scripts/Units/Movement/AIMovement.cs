using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AIShooter))]
public class AIMovement : Movement
{
    public override bool IsMoving => agent.stoppingDistance <= distanceToTarget;

    private AIShooter shooter;
    private Transform pointOfInterest;
    private Transform target;

    private float maxWalkDistance = 50f;
    private float distanceToTarget;
    private float stoppingDistance;
    private bool needPowerup;

    protected override void Start()
    {
        base.Start();
        stoppingDistance = agent.stoppingDistance;
        pointOfInterest = transform;
        shooter = GetComponent<AIShooter>();

        GetComponent<Health>().OnDamage += () =>
        {
            if (Random.Range(0, 10) == 0)
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
            if (agent.stoppingDistance * 1.5f < distanceToTarget)
            {
                agent.SetDestination(shooter.Target.position);
            }
        }
        else
        {
            if (target == null) GetTarget();
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
        var position = PointsOfInterest.Instance.GetPoint(pointOfInterest.position, needPowerup);
        agent.SetDestination(position);
    }
}
