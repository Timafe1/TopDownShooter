using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public void EndGame()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; // This freezes the game when the game over screen appears
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // This resumes the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}