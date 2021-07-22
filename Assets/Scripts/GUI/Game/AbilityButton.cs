using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private PlayerShooter player;

    private Unit unit;
    private Button button;
    private Image timerImage;

    private void Start()
    {
        unit = player.GetComponent<Unit>();
        button = GetComponent<Button>();
        timerImage = GetComponent<Image>();
        button.onClick.AddListener(UseAbility);
    }

    public void UseAbility()
    {
        unit.MakeAction();
        StartCoroutine(ReloadCell(unit.ReloadTime));
    }

    private IEnumerator ReloadCell(float reloadTime)
    {
        button.interactable = false;
        var startTime = Time.time;
        timerImage.fillAmount = 0;
        while(timerImage.fillAmount < 1)
        {
            timerImage.fillAmount = (Time.time - startTime) / reloadTime;
            yield return new WaitForEndOfFrame();
        }

        timerImage.fillAmount = 1;
        button.interactable = true;
    }
}
