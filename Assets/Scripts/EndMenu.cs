using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
