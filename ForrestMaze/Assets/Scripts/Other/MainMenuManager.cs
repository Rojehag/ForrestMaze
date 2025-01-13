using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}