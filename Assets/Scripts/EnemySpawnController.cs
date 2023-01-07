using System;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] spawnPoints;
    private Transform spawnPoint;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float timeElapsed = 0f;
    private float timeToSpawn = 0f;
    [SerializeField]
    private float spawnRate = 2f;

    private void Update()
    {
        SpawnEnemyBird();
    }

    private void SpawnEnemyBird()
    {
        timeElapsed += Time.deltaTime;
        timeToSpawn = timeElapsed - spawnRate;
        if (timeToSpawn >= 0)
        {
            var randomSpawnPoint = PickSpawnPoint();
            timeElapsed = 0;
            Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }
    }

    private Transform PickSpawnPoint()
    {
        int randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomSpawnPoint];
    }
}
