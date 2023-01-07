using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] spawnPoints;
    private Transform spawnPoint;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject enemyPrefab;
    private float enemyMovementSpeed = 10f;

    [SerializeField]
    private float timeElapsed = 0f;
    private float timeToSpawn = 0f;
    [SerializeField]
    private float spawnRate = 2f;

    private GameObject SpawnEnemyBird()
    {
        timeElapsed += Time.deltaTime;
        timeToSpawn = timeElapsed - spawnRate;
        if (timeToSpawn >= 0)
        {
            Debug.Log("Spawn");
            var randomSpawnPoint = PickSpawnPoint();
            timeElapsed = 0;
            return Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }
        return null;
    }

    private Transform PickSpawnPoint()
    {
        int randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomSpawnPoint];
    }

    private void Update()
    {
        var enemy = SpawnEnemyBird();
        if (enemy != null)
        {
            MoveEnemyTowardsPlayer(enemy);
        }
    }

    private void MoveEnemyTowardsPlayer(GameObject enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(transform.position, playerPrefab.transform.position, 0.1f) * enemyMovementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Confiner")
        {
            Destroy(enemyPrefab);
        }

        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerLife>().DecreaseLives();
        }
    }
}
