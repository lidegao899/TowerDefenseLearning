using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI;

    public GameObject WinLevelUI;

    public SceneFader sceneFader;

    private bool gameEnd = false;

    public int CurrrentSceneIndex;

    public string NextSceneName;

    // Update is called once per frame
    private void Update()
    {
        if (gameEnd)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
            return;
        }

        if (Input.GetKeyDown("q"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnd = true;
        Debug.Log("Game Over");
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinLevel()
    {
        Debug.Log("win level");

        if (NextSceneName.Length == 0)
        {
            return;
        }

        int iCurrentReachedLevel = PlayerPrefs.GetInt("levelReached", 1);
        if (iCurrentReachedLevel == CurrrentSceneIndex)
        {
            PlayerPrefs.SetInt("levelReached", CurrrentSceneIndex + 1);
        }

        WinLevelUI.SetActive(true);
    }
}