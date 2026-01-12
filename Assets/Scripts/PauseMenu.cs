using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

    private bool isPaused = false;

    void Start()
    {
        if (pauseCanvas)
            pauseCanvas.SetActive(false);
    }

    void Update()
    {
        // ESC ile aç / kapa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ContinueGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
