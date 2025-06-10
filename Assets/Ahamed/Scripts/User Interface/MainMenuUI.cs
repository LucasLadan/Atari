using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
     void Awake()
     {
        Time.timeScale = 0f;
     }
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
