using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
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

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
