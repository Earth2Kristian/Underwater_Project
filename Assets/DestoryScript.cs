using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryScript : MonoBehaviour
{
    void Update()
    {
        Destroy(this.gameObject, 30);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Shark"))
        {
            Destroy(this.gameObject );
        }
    }


}
