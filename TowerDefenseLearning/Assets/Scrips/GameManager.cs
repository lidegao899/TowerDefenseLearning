using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI;

    private bool gameEnd = false;
    // Update is called once per frame
    void Update()
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

    void EndGame() 
    {
        gameEnd = true;
        Debug.Log("Game Over");
        GameOverUI.SetActive(true);
    }
}
