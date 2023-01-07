using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    public int lives;

    [SerializeField]
    private Text livesText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            //implement hit animation
            DecreaseLives();
            UpdatePlayerLivesText();

            if (lives <= 0)
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        gameObject.isStatic = true;
        //implement death animation
        SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
    }

    private void UpdatePlayerLivesText()
    {
        livesText.text = "Player Lives: " + lives;
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
