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

    [SerializeField]
    private GameObject lineBird;

    [SerializeField]
    private GameObject linePlayerBird;

    private float spawnRateHomingBird = 6f;
    private float spawnRateLineBird = 6f;
    private float spawnRateLinePlayerBird = 6f;
    List<Coroutine> activeSpawners = new List<Coroutine>();

    // (x1, x2, y1, y2) 
    private (int, int, int, int)[] spawnerBoundaries = new[] { (-20, 40, 24, 26), (43, 45, -20, 20), (-18, 38, -26, -23), (-25, -23, -20, 20) };

    void Start()
    {
        // Spawn some birds on game start right away
        Instantiate(homingBird, new Vector3(9, 8, 0.0f), Quaternion.identity);
        Instantiate(lineBird, new Vector3(43, 10, 0.0f), Quaternion.identity);
        Instantiate(linePlayerBird, new Vector3(-20, -20, 0.0f), Quaternion.identity);
        AddAllBirdSpawnersOnce();
    }

    public void AddAllBirdSpawnersOnce()
    {
        AddHomingBirdSpawner();
        AddLineBirdSpawner();
        AddLinePLayerBirdSpawner();
    }

    public void AddHomingBirdSpawner()
    {
        activeSpawners.Add(StartCoroutine(BirdSpawner(homingBird, spawnRateHomingBird)));
    }

    public void AddLineBirdSpawner()
    {
        activeSpawners.Add(StartCoroutine(BirdSpawner(lineBird, spawnRateLineBird)));
    }

    public void AddLinePLayerBirdSpawner()
    {
        activeSpawners.Add(StartCoroutine(BirdSpawner(linePlayerBird, spawnRateLinePlayerBird)));
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
