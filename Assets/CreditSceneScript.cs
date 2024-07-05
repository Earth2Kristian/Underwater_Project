using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSceneScript : MonoBehaviour
{
    public Animator transitionScene;

    void Start()
    {
        Time.timeScale = 1.0f;
        transitionScene.SetTrigger("startScene");
    }

}
