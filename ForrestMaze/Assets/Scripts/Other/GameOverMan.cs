using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene(0);
    }
    public void LoadControllScene()
    {
        // Load the main menu scene
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}