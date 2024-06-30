using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePausedScript : MonoBehaviour
{
    public void Resume()
    {
        GameManager.Instance.gamePaused = false;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.gameOver = false;
        GameManager.Instance.gamePaused = false;
        Time.timeScale = 1f;
    }
}
