using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuScript : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.gameOver = false;
        GameManager.Instance.playerWin = false;
        GameManager.Instance.playerLost = false;
        Time.timeScale = 1f;
    }
}
