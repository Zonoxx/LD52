using Unity.VisualScripting;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    public int lives;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Lives: " + lives);

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            DecreaseLives();
            Debug.Log("Lives: " + lives);
            if (lives <= 0)
            {
                Destroy(gameObject);
                //implement death animation
                //transition to game over screen
            }
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
