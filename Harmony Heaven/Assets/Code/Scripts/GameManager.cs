using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverText;
    public float gameOverDisplayTime = 5f;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        // Display game over text
        gameOverText.SetActive(true);

        // Wait for a few seconds before returning to the main menu
        Invoke("ReturnToMainMenu", gameOverDisplayTime);
    }

    void ReturnToMainMenu()
    {
        // Load the main menu scene (replace "MainMenu" with your actual main menu scene name)
        SceneManager.LoadScene("Main Menu");
    }
}
