using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private void Update()
    {
        //Debug.Log("GameManage");
        if (countdown <= 0)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    private void SpawnWave()
    {
        Debug.Log("Wave Spwaning!!!");

    }
}
