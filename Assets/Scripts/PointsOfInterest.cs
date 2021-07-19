using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointsOfInterest : MonoBehaviour
{
    public static PointsOfInterest Instance;

    private List<Vector3> points;

    public Vector3 GetPoint(Vector3 point)
    {
        var anotherPoints = points.Where(x => x != point).ToList();
        return anotherPoints[Random.Range(0, anotherPoints.Count)];
    }

    private void Awake()
    {
        points = GetComponentsInChildren<Transform>()
            .Select(x => x.position)
            .ToList();

        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
}
