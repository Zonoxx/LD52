using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    public int lives;

    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioSource explosionAudio;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
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
        explosionAudio.Play();
        animator.SetTrigger("PlayerDeath");
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        Invoke("ChangeToEndScreen", 2);
    }

    private void ChangeToEndScreen()
    {
        SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
    }

    private void UpdatePlayerLivesText()
    {
        livesText.text = "Lives: " + lives;
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
