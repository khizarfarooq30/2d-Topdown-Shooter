using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
   [System.Serializable]
    public class Wave
    {
        public Enemy[] enemy;
        public int count;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    public Wave currentWave;
    public int currentWaveIndex;
    private Transform player;

    bool finishedSpawning;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        for(int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            Enemy randomEnemy = currentWave.enemy[Random.Range(0, currentWave.enemy.Length)];
            Transform randomPoints = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoints.position, randomPoints.rotation);

            if (i == currentWave.count - 1)
            {
                finishedSpawning = true;
            } else
            {
                finishedSpawning = false;
            }

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }

        
      
    }
}
