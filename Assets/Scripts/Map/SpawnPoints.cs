using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public int PointsCount => points.Length;

    private Transform[] points;

    public Vector3 GetPositionByIndex(int index)
    {
        if (index >= points.Length)
            throw new ArgumentException();
        return points[index].position;
    }

    private void Awake()
    {
        points = GetComponentsInChildren<Transform>();
    }
}
