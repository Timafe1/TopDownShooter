using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("NextScene"); // Replace "NextScene" with the name of your next scene
    }

    public void QuitGame()
    {
        Application.Quit(); // This will quit the application
    }
}
