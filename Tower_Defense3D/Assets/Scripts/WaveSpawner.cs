using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine.UI;
using TMPro;
using System;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TMP_Text waveCountdownText;
    private int waveIndex = 0;

    private void Update()
    {
        //Debug.Log("GameManage");
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;
        for(int i = 0; i < waveIndex;i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);

    }
}
