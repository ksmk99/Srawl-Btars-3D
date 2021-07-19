using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int Count => LoadManager.Money;
    public static Money Instance { get; private set; }

    [SerializeField] private Text moneyText;

    private void Awake()
    {
        Instance = this;
        GUIUpdate(LoadManager.Money);
    }

    public void AddMoney(int count)
    {
        var money = LoadManager.Money + count;
        SaveManager.Money(money);
        GUIUpdate(money);
    }

    public void Buy(int count)
    {
        var money = LoadManager.Money - count;
        SaveManager.Money(money);
        GUIUpdate(money);
    }

    private void GUIUpdate(int count)
    {
        moneyText.text = count.ToString();
    }
}
