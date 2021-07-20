using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [SerializeField] private GameObject[] powerups;
    [SerializeField] private int minTime = 3;
    [SerializeField] private int maxTime = 6;

    private Transform[] points;

    private void Awake()
    {
        points = GetComponentsInChildren<Transform>();
        StartCoroutine(PlacePowerup());
    }

    private IEnumerator PlacePowerup()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime + 1));
        var powerup = Instantiate(
            powerups[Random.Range(0, powerups.Length)],
            points[Random.Range(0, points.Length)].position,
            Quaternion.identity);
        StartCoroutine(PlacePowerup());
    }
}
