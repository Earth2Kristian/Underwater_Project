using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public bool gameOver;
    public bool playerLost;
    public GameObject lostUI;
    public bool playerWin;
    public GameObject winUI;

    public float timerCounter;
    public TMP_Text timerText;

    void Start()
    {
        Time.timeScale = 1f;
        gameOver = false;
        playerLost = false;
        playerWin = false;

        lostUI.SetActive(false) ;
        winUI.SetActive(false);

        timerCounter = 0;
        timerText.text = "TIMER: " + Mathf.Round(timerCounter);
    }
    void Update()
    {

        timerCounter += Time.deltaTime;
        timerText.text = "TIMER: " + Mathf.Round(timerCounter);

        if (gameOver == true)
        {
            Time.timeScale = 0f;
            Debug.Log("Game Over");

            // Condition whenever if the player has win or not
            if (playerLost == true)
            {
                // UI will be showing that the player has lost
                Debug.Log("Player has lost");
                lostUI.SetActive (true);
            }
            if (playerWin == true)
            {
                // UI will be showing that the player has won
                Debug.Log("Player has win");
                winUI.SetActive (true);
            }

        }
    }

    void Awake()
    {
        instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
}
