using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
