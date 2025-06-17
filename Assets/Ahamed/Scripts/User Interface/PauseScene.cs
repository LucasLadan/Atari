using JetBrains.Annotations;
using UnityEngine;

public class PauseScene : MonoBehaviour
{

    [SerializeField] public Canvas pauseMenu;
    public bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GamePause();
        }
    }

    public void GamePause()
           {
             isPaused = !isPaused;

             if (!isPaused)
             {
              pauseMenu.enabled = true;
              Time.timeScale = 0;
             }
             else
             {
               pauseMenu.enabled = false;
               Time.timeScale = 1;
             }
           }

}
