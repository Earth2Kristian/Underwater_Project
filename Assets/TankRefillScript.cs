using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRefillScript : MonoBehaviour
{
    public AudioSource breatheSoundEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.oxygenLevelCurrent += 10;
            GameManager.Instance.oxygenLevelText.text = "" + Mathf.Round(GameManager.Instance.oxygenLevelCurrent);  
            GameManager.Instance.oxygenBar.UpdateOxygenBar(GameManager.Instance.oxygenLevelCurrent, GameManager.Instance.oxygenLevelMax);
            breatheSoundEffect.Play();
        }
    }
}
