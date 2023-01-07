using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("StartScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScreen" && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level1");
        }

        CheckIfGameIsOver();
        EndGame();
    }

    private void EndGame()
    {
        if (SceneManager.GetActiveScene().name == "WinScreen" || SceneManager.GetActiveScene().name == "LoseScreen" && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }

    private static void CheckIfGameIsOver()
    {
        CheckWinCondition();
        CheckLoseCondition();
    }

    private static void CheckLoseCondition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player is null)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    private static void CheckWinCondition()
    {
        GameObject wheats = GameObject.FindGameObjectWithTag("Wheat");
        if (wheats is null)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
