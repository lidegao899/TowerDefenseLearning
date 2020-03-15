using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text RoundsText;

    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";



    private void OnEnable()
    {
        RoundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}