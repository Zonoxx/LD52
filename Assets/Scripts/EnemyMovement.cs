using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float enemyMovementSpeed = 2f;
    private Animator animator;

    private bool isFlipped;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        if (player.transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isFlipped = true;
        }
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMovementSpeed * Time.deltaTime);
        if (player.transform.position.x < transform.position.x)
        {
            if (!isFlipped)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                isFlipped = true;
            }
        }
        else
        {
            if (isFlipped)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                isFlipped = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Death");
            gameObject.GetComponent<Collider2D>().enabled = false;
            Invoke("RemoveGameObject", 0.5f);
        }
    }

    private void RemoveGameObject()
    {
        Destroy(gameObject);
    }
}
