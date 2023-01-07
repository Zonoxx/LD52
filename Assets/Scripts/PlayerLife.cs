using Unity.VisualScripting;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DecreaseLives();
            if (lives <= 0)
            {
                Destroy(gameObject);
                //implement death animation
                //transition to game over screen
            }
        }
        if (other.gameObject.CompareTag("Confiner"))
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseLives()
    {
        lives++;
    }

    public void DecreaseLives()
    {
        lives--;
    }
}
