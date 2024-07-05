using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator transitionScene;

    public AudioSource playButtonSoundEffect;
    

    void Start()
    {
        Time.timeScale = 1.0f;
        transitionScene.SetTrigger("startScene");   
    }

    public void PlayButton()
    {
        playButtonSoundEffect.Play();
        transitionScene.SetTrigger("endScene");
        StartCoroutine(TransitionPlay());
        //SceneManager.LoadScene(3);

    }

    public void AboutButton()
    {
        SceneManager.LoadScene(2);
    }
    public void ControlButton()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditButton()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    private IEnumerator TransitionPlay() 
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}
