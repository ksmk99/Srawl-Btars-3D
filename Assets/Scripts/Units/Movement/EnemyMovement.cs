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

    private void Start()
    {
        target = transform;
        shooter = GetComponent<EnemyShooter>();
        GetTarget();
    }

    protected override void Move()
    {
        if (shooter.HaveEnemy)
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
                GetTarget();
            }
        }
    }


    private void GetTarget()
    {
        var direction = Random.insideUnitSphere * maxWalkDistance;
        direction += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(direction, out hit, Random.Range(20f, float.MaxValue), 1);

        var position = PointsOfInterest.Instance.GetPoint(target.position);
        agent.SetDestination(position);
    }
}
