using UnityEngine;
using UnityEngine.SceneManagement;

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
                gameObject.isStatic = true;
                //implement death animation
                SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
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
