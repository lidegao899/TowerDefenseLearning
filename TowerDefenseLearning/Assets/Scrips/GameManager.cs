using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI;

    private bool gameEnd = false;

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
    }
}