using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] homingBirdSpawnPoints;
    private Transform spawnPoint;
    [SerializeField]
    private GameObject homingBird;

    public float currentSpawnRate = 5.0f;
    public float timeUntilSpawnRateIncrease = 30f;
    private float spawnRateHomingBird = 6f;
    public float newSpawnerRate = 5.0f;
    List<Coroutine> activeSpawners = new List<Coroutine>();

    // (x1, x2, y1, y2) 
    private (int, int, int, int)[] spawnerBoundaries = new[] { (-35, 40, 24, 26), (-15, -12, -25, 22), (-80, -15, -28, -25), (-25, -23, -25, 22) };

    void Start()
    {
        // Spawn some birds on game start right away
        Instantiate(homingBird, new Vector3(9, 8, 0.0f), Quaternion.identity);
        Instantiate(homingBird, new Vector3(43, 10, 0.0f), Quaternion.identity);
        Instantiate(homingBird, new Vector3(-20, -20, 0.0f), Quaternion.identity);

        AddHomingBirdSpawner();
        AddHomingBirdSpawner();
        AddHomingBirdSpawner();
    }

    public void AddHomingBirdSpawner()
    {
        activeSpawners.Add(StartCoroutine(BirdSpawner(homingBird, spawnRateHomingBird)));
    }

    private Vector3 getRandomSpawnPoint()
    {
        int idx = UnityEngine.Random.Range(0, this.spawnerBoundaries.Length);
        var boundaries = this.spawnerBoundaries[idx];
        float xVal = UnityEngine.Random.Range(boundaries.Item1, boundaries.Item2);
        float yVal = UnityEngine.Random.Range(boundaries.Item3, boundaries.Item4);
        return new Vector3(xVal, yVal, 0.0f);
    }

    private IEnumerator BirdSpawner(GameObject birdtype, float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(birdtype, getRandomSpawnPoint(), Quaternion.identity);
        }
    }

}
