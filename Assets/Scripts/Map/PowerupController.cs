using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [SerializeField] private Powerup[] powerups;
    [SerializeField] private int minTime = 3;
    [SerializeField] private int maxTime = 6;

    private PointsOfInterest pointsOfInterest;

    private void Start()
    {
        pointsOfInterest = GetComponent<PointsOfInterest>();
        GameManager.Instance.OnGameStart += () => StartCoroutine(PlacePowerup());
        GameManager.Instance.OnGameEnd += () => StopAllCoroutines();
    }

    private IEnumerator PlacePowerup()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime + 1));
        pointsOfInterest.PowerupSpawn(powerups[Random.Range(0, powerups.Length)]);
        StartCoroutine(PlacePowerup());
    }
}
