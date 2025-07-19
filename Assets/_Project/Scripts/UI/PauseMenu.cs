using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    // possibile utilizzo per bloccare eventi in game
    public enum GAME_STATE { PLAYING, PAUSED };
    public GAME_STATE GameState { get; private set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Resume()
    {
        if (!canvas.activeSelf)
        {
            canvas.SetActive(true);
            GameState = GAME_STATE.PAUSED;
            Time.timeScale = 0;
        }
        else
        {
            canvas.SetActive(false);
            GameState = GAME_STATE.PLAYING;
            Time.timeScale = 1;
        }
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
