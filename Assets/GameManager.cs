using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    // Paused Variables
    public bool gamePaused;
    public GameObject pausedUI;

    // Win Condition Variables
    public bool gameOver;
    public bool playerLost;
    public GameObject lostUI;
    public bool playerWin;
    public GameObject winUI;

    // Time Variables
    public float timerCounter;
    public TMP_Text timerText;

    // Oxygen Level Variable
    public float oxygenLevelCounter;
    public TMP_Text oxygenLevelText;

    // Able to Click Variables
    public bool ableToClick;

    // Sound Effect and Music Background Variables
    public AudioSource musicBackground;
    public AudioSource jumpScareSoundEffect;
    public bool jumpScareSoundEffectPlayed;

    void Start()
    {
        // The gameplay will play once the player has enter the level
        Time.timeScale = 1f;
        gamePaused = false;
        gameOver = false;
        playerLost = false;
        playerWin = false;

        pausedUI.SetActive(false);
        lostUI.SetActive(false) ;
        winUI.SetActive(false);

        // Time Counter set as 0
        timerCounter = 0;
        timerText.text = "TIMER: " + Mathf.Round(timerCounter);

        // Oxygen Level Counter set as 30
        oxygenLevelCounter = 60;
        oxygenLevelText.text = "OXYGEN: " + Mathf.Round(oxygenLevelCounter);

        ableToClick = false;

        jumpScareSoundEffectPlayed = false;
    }
    void Update()
    {
        // Timer Counter will increase by time during the gameplay
        timerCounter += Time.deltaTime;
        timerText.text = "TIMER: " + Mathf.Round(timerCounter);

        // Oxygen Level counter will decrease by time during the gameplay
        oxygenLevelCounter -= Time.deltaTime;
        oxygenLevelText.text = "OXYGEN: " + Mathf.Round(oxygenLevelCounter);

        if (oxygenLevelCounter <= 0)
        {
            gameOver = true;
            playerLost = true;
        }
        if (oxygenLevelCounter > 60)
        {
            oxygenLevelCounter = 60;
        }

        if (gamePaused == true)
        {
            Time.timeScale = 0f;
            pausedUI.SetActive(true);
            ableToClick = true;
        }
        if (gamePaused == false)
        {
            Time.timeScale = 1f;
            pausedUI.SetActive(false);
            ableToClick = false;
        }

        if (gameOver == true)
        {
            // The gameplay will pause/freeze once the game is over
            ableToClick = true;
            Time.timeScale = 0f;
            Debug.Log("Game Over");

            musicBackground.Stop();

            // Condition whenever if the player has win or not
            if (playerLost == true)
            {
                // UI will be showing that the player has lost
                Debug.Log("Player has lost");
                lostUI.SetActive (true);

                if (jumpScareSoundEffectPlayed == false)
                {
                    jumpScareSoundEffect.Play();
                    jumpScareSoundEffectPlayed = true;
                }
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
