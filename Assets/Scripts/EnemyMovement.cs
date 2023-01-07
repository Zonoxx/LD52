using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    private float enemyMovementSpeed = 10f;

    void Start()
    {
        //Rotate enemy towards player
        Vector3 direction = playerPrefab.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, direction);

    }

    // Update is called once per frame
    private void Update()
    {
        MoveEnemyTowardsPlayer();
    }

    private void MoveEnemyTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPrefab.transform.position, 0.1f) * enemyMovementSpeed * Time.deltaTime;
    }
}
