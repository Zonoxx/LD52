using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    protected GameObject player;
    protected Animator animator;

    protected bool isFlipped;
    protected AudioSource audioSource;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        if (player.transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isFlipped = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
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
