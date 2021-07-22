using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class GameEndGUI : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;

    private void Start()
    {
        GameManager.Instance.OnPlayerLoose += () => GameEnd(false);
        GameManager.Instance.OnGameEnd += () => GameEnd(true);
    }

    private void GameEnd(bool isWin)
    {
        GameManager.Instance.OnPlayerLoose -= () => GameEnd(false);
        GameManager.Instance.OnGameEnd -= () => GameEnd(true);

        resultText.text = isWin ? "YOU WON" : "YOU LOOSE";
        GetComponent<Animation>().Play();
    }
}
