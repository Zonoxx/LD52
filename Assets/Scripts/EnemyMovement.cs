using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float enemyMovementSpeed = 2f;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMovementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name + "With tag " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Outer Confiner"))
        {
            Destroy(gameObject);
        }
    }
}
