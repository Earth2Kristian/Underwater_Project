using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SharkHealth : MonoBehaviour
{
    private static SharkHealth instance = null;

    public float sharkMaxHealth = 100;
    public float sharkCurrentHealth;
    public TMP_Text sharkHealthText;
    public SharkHPBarScript sharkHPBar;
    void Start()
    {
        sharkCurrentHealth = sharkMaxHealth;

        sharkHealthText.text = "" + Mathf.RoundToInt(sharkCurrentHealth);
        sharkHPBar.UpdateSharkHPBar(sharkCurrentHealth, sharkMaxHealth);
    }

    
    void Update()
    {
         if (sharkCurrentHealth <= 0)
         {
            Debug.Log("Shark has died");
            GameManager.Instance.gameOver = true;
            GameManager.Instance.playerWin = true;
            sharkHealthText.text = "" + Mathf.RoundToInt(sharkCurrentHealth);
            sharkHPBar.UpdateSharkHPBar(sharkCurrentHealth, sharkMaxHealth);
         }
         
    }

    void Awake()
    {
        instance = this;
    }

    public static SharkHealth Instance
    {
        get
        {
            return instance;
        }
    }
}
