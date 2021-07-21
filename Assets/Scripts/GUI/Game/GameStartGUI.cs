using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartGUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private int count = 1;

    public void UpdateText()
    {
        count++;
        text.text = count.ToString();
    }

    public void GameStart()
    {
        GameManager.Instance.GameStart();
        Destroy(gameObject);
    }
}
