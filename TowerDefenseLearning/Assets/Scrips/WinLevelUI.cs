using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLevelUI : MonoBehaviour
{
    public SceneFader sceneFader;

    public Text RoundsText;

    public string nextLevel = "Level2";
    public int levleToUnlock = 2;

    public void OnEnable()
    {
        RoundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Continue()
    {
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }
}
