using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class GameEndGUI : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;

    private bool isFirstTime = true;

    private void Start()
    {
        GameManager.Instance.OnPlayerLoose += () => GameEnd(false);
        GameManager.Instance.OnGameEnd += () => GameEnd(true);
    }

    private void GameEnd(bool isWin)
    {
        if (isFirstTime)
        {
            isFirstTime = false;
            resultText.text = isWin ? "YOU WON" : "YOU LOOSE";
            GetComponent<Animation>().Play();
        }
    }
}
