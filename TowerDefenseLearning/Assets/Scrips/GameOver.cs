using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject ui;

    public Text RoundsText;

    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        RoundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        ui.SetActive(false);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(menuSceneName);
    }


}