using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitSpawn : MonoBehaviour
{
    [Range(5, 10)]
    [SerializeField] private int enemyCount = 7;
    [SerializeField] private SpawnPoints spawnPoints;

    private void Awake()
    {
        if (spawnPoints.PointsCount < enemyCount)
            throw new Exception("Not enough spawn points");

        var enemies = Resources.LoadAll<Unit>("Units");
        for (int i = 0; i < enemyCount; i++)
        {
            var enemy = Instantiate(enemies[Random.Range(0, enemies.Length)],
                spawnPoints.GetPositionByIndex(i), Quaternion.identity);
            enemy.transform.parent = transform;
        }
    }
}
