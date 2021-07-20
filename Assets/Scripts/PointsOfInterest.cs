using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointsOfInterest : MonoBehaviour
{
    public static PointsOfInterest Instance;

    [SerializeField] private int powerupCount = 4;

    private Dictionary<Vector3, bool> pointsDictioanry;
    private List<Vector3> points;

    public Vector3 GetPoint(Vector3 point, bool needPowerup = false)
    {
        var result = new Vector3();
        if (needPowerup)
        {
            result = GetPointWithPowerup(point);
        }
        else if (!needPowerup || result == new Vector3())
        {
            var anotherPoints = pointsDictioanry.Where(x => x.Key != point).ToList();
            result = anotherPoints[Random.Range(0, anotherPoints.Count)].Key;
        }
        return result;
    }

    public void PowerupSpawn(Powerup powerupPrefab)
    {
        var pointsWithouPowerup = points
            .Where(x => !pointsDictioanry[x])
            .ToList();
        if (points.Count == powerupCount)
            return;

        var point = pointsWithouPowerup[Random.Range(0, pointsWithouPowerup.Count)];
        var powerup = Instantiate(powerupPrefab, point, Quaternion.identity);

        pointsDictioanry[point] = true;
        powerup.OnPickup += () => pointsDictioanry[point] = false;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        SetData();
    }

    private void SetData()
    {
        points = GetComponentsInChildren<Transform>()
            .Select(x => x.position)
            .ToList();

        pointsDictioanry = points.ToDictionary(x => x, y => false);
    }

    private Vector3 GetPointWithPowerup(Vector3 point)
    {
        var anotherPoints = pointsDictioanry.Where(x => x.Key != point && x.Value).ToList();
        if (anotherPoints.Count == 0) return new Vector3();
        return anotherPoints[Random.Range(0, anotherPoints.Count)].Key;
    }
}
