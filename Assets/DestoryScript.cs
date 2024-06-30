using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryScript : MonoBehaviour
{
    public AudioSource bombExplosionSoundEffect;
    public GameObject bombExplosionParticlesEffects;
    public Transform bombExplosionPostion;
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
            SharkHealth.Instance.sharkHPBar.UpdateSharkHPBar(SharkHealth.Instance.sharkCurrentHealth, SharkHealth.Instance.sharkMaxHealth);
            bombExplosionSoundEffect.Play();
            Instantiate(bombExplosionParticlesEffects, bombExplosionPostion.position, Quaternion.identity);
            Destroy(this.gameObject);
            
            
        }
    }


}
