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
        GameManager.Instance.OnGameLoose += () => GameEnd(false);
        GameManager.Instance.OnGameWin += () => GameEnd(true);
    }

    private void GameEnd(bool isWin)
    {
        resultText.text = isWin ? "YOU WON" : "YOU LOOSE";
        GetComponent<Animation>().Play();
    }
}
