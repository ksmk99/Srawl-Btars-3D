using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : Movement
{
    private float maxWalkDistance = 50f;

    public override bool IsMoving => agent.speed != 0;

    private void Start()
    {
        GetTarget();
    }

    protected override void Move()
    {
        var distance = Vector3.Distance(transform.position, agent.destination);
        if (agent.stoppingDistance > distance)
        {
            GetTarget();
        }
    }

    private void GetTarget()
    {
        var direction = Random.insideUnitSphere * maxWalkDistance;
        direction += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(direction, out hit, Random.Range(20f, float.MaxValue), 1);

        agent.SetDestination(hit.position);
    }
}
