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
            GameManager.Instance.oxygenLevelCounter += 10;
            GameManager.Instance.oxygenLevelText.text = "OXYGEN: " + Mathf.Round(GameManager.Instance.oxygenLevelCounter);  
            breatheSoundEffect.Play();
        }
    }
}
