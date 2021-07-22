using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsGameEnd { get; private set; }

    public event Action OnPlayerLoose;
    public event Action OnGameEnd;
    public event Action OnGameStart;

    public void GameStart() => OnGameStart?.Invoke();

    public void PlayerDeath()
    {
        IsGameEnd = true;
        OnPlayerLoose?.Invoke();

    }

    public void GameEnd()
    {
        IsGameEnd = true;
        OnGameEnd?.Invoke();
    }

    private void Awake()
    {
        Instance = this;

        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
