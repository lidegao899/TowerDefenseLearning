using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiseAlive = 0;

    public Text textCountDown;

    public GameObject enemyPrefeb;

    public Transform spawnPos;

    public float spawnWaveTimeGap = 5f;

    public float countDownTime = 2f;

    public int spawnCount = 0;

    private int waveIndex = 0;

    public Wave[] waves;

    // Update is called once per frame
    private void Update()
    {
        if (PlayerStats.Lives <= 0)
        {
            return;
        }

        if (EnemiseAlive > 0)
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

    private IEnumerator SpawnWave()
    {
        spawnCount++;
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefeb);
            yield return new WaitForSeconds(1 / wave.spawnRate);
        }
        waveIndex++;

        if (waveIndex > waves.Length)
        {
            Debug.Log("you won");
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemyPrefeb)
    {
        Instantiate(enemyPrefeb, spawnPos.position, spawnPos.rotation);
        EnemiseAlive++;
    }
}