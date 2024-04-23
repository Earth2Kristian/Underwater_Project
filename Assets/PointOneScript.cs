using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shark"))
        {
            SharkAIScript.Instance.SetOne = false;
            SharkAIScript.Instance.SetTwo = true;
            SharkAIScript.Instance.SetThree = false;
            SharkAIScript.Instance.SetFour = false;
            SharkAIScript.Instance.SetFive = false;
        }
    }
}
