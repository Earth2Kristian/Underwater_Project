using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryScript : MonoBehaviour
{
    public AudioSource bombExplosionSoundEffect;
    void Update()
    {
        Destroy(this.gameObject, 30);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Shark"))
        {
             Debug.Log("Shark has been hit by a bomb");
             SharkHealth.Instance.sharkCurrentHealth -= 10;
             SharkHealth.Instance.sharkHealthText.text = "" + Mathf.RoundToInt(SharkHealth.Instance.sharkCurrentHealth);
            bombExplosionSoundEffect.Play();
             Destroy(this.gameObject);
            
            
        }
    }


}
