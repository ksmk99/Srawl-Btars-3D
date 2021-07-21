using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MainMenuGUI : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(0));
    }
}
