using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Text textCountDown;

    public GameObject enemyPrefeb;

    public Transform spawnPos;

    public float spawnWaveTimeGap = 5f;

    public float countDownTime = 2f;

    public int spawnCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.Lives <= 0)
        {
            return;
        }

        if (countDownTime <= 0)
        {
            countDownTime = spawnWaveTimeGap;
            StartCoroutine(SpawnWave());
        }
        else
        {
            countDownTime -= Time.deltaTime;
            countDownTime = Mathf.Clamp(countDownTime, 0f, Mathf.Infinity);

            textCountDown.text = string.Format("{0:00:00}", countDownTime);
        }
    }

    IEnumerator SpawnWave()
    {
        spawnCount++;
        PlayerStats.Rounds++;

        for (int i = 0; i < spawnCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefeb, spawnPos.position, spawnPos.rotation);
    }
}
