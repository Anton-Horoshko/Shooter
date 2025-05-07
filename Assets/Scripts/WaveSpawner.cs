using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float spawnDelay = 0.5f;

    private int waveNumber = 1;
    private bool spawning = false;

    void Start()
    {
        StartCoroutine(SpawnWaveLoop());
    }

    IEnumerator SpawnWaveLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            StartCoroutine(SpawnWave(waveNumber));
            waveNumber++;
        }
    }

    IEnumerator SpawnWave(int enemiesToSpawn)
    {
        spawning = true;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }

        spawning = false;
    }
}