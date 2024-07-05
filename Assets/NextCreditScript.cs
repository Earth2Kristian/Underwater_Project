using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextCreditScript : MonoBehaviour
{
    public void CreditButton()
    {
        SceneManager.LoadScene(4);
    }
}
