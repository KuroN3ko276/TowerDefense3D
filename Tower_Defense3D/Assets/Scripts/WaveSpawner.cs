using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine.UI;
using TMPro;
using System;

public class WaveSpawner : MonoBehaviour
{
    public static int EnmiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TMP_Text waveCountdownText;
    private int waveIndex = 0;

    private void Update()
    {
        if(EnmiesAlive > 0)
        {
            return;
        }
        //Debug.Log("GameManage");
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }

    private IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        for(int i = 0; i < wave.count;i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveIndex++;
        if(waveIndex == waves.Length)
        {
            Debug.Log("LEVEL WON!!!");
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
        EnmiesAlive++;
    }
}
