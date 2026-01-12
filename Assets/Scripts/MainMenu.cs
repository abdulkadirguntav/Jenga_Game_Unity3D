using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // PLAY butonu
    public void PlayGame()
    {
        Time.timeScale = 1f; // game over'dan geliyorsa resetler
        SceneManager.LoadScene("Jenga"); 
        // Game = oyun sahnenin adı
    }

    // EXIT butonu
    public void ExitGame()
    {
        Debug.Log("Oyun kapatıldı");
        Application.Quit();
    }
}
