using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawnPoints;
    private int enemiesLeft;
    public List<int> enemiesPerWave;
    int wave = 0;

    [Range(0f,10f)]public float timeBetweenWaves = 10f;
    [Range(0f, 10f)]public float spawnInterval;

    public UnityEvent onSpawn;
    public UnityEvent<int> onWaveStart;
    public UnityEvent<int> onWaveEnd;
    public UnityEvent onWavesCleared;


    public void Spawn()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(prefab, point.position, point.rotation);
        onSpawn.Invoke();
    }
    async void Start()
    {
        foreach (var count in enemiesPerWave)
        {
            enemiesLeft = count;
            onWaveStart.Invoke(wave);

            // spawning

            while(enemiesLeft > 0)
            {
                await new WaitForSeconds(spawnInterval);
                Spawn();
                enemiesLeft--;
            }
            onWaveEnd.Invoke(wave);
            wave++;

            await new WaitForSeconds(timeBetweenWaves);
        }
        onWavesCleared.Invoke();
    }
}
