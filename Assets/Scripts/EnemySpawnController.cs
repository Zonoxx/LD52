using System;
using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] homingBirdSpawnPoints;
    private Transform spawnPoint;
    [SerializeField]
    private GameObject homingBird;

    float delayAndSpawnRate = 2;
    float timeUntilSpawnRateIncrease = 30;

    void Start()
    {
        // Start spawning homing birds
        StartCoroutine(SpawnEnemy(delayAndSpawnRate, homingBird, homingBirdSpawnPoints));
    }

    IEnumerator SpawnEnemy(float firstDelay, GameObject birdtype, Transform[] homingBirdSpawnPoints)
    {
        float spawnRateCountdown = timeUntilSpawnRateIncrease;
        float spawnCountdown = firstDelay;
        while (true)
        {
            yield return null;
            spawnRateCountdown -= Time.deltaTime;
            spawnCountdown -= Time.deltaTime;

            // Should a new object be spawned?
            if (spawnCountdown < 0)
            {
                spawnCountdown += delayAndSpawnRate;
                var randomSpawnPoint = PickSpawnPoint(homingBirdSpawnPoints);
                Instantiate(homingBird, randomSpawnPoint.position, randomSpawnPoint.rotation);
            }

            // Should the spawn rate increase?
            if (spawnRateCountdown < 0 && delayAndSpawnRate > 1)
            {
                spawnRateCountdown += timeUntilSpawnRateIncrease;
                delayAndSpawnRate -= 0.1f;
            }
        }
    }

    private Transform PickSpawnPoint(Transform[] spawnPoints)
    {
        int randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomSpawnPoint];
    }

}
