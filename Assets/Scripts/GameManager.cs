using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsGameEnd { get; private set; }

    public event Action OnGameLoose;
    public event Action OnGameWin;
    public event Action OnGameStart;

    public void GameStart() => OnGameStart?.Invoke();

    public void GameLoose()
    {
        IsGameEnd = true;
        OnGameLoose?.Invoke();

    }

    public void GameWin()
    {
        IsGameEnd = true;
        OnGameWin?.Invoke();
    }

    private void Awake()
    {
        Instance = this;

        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
