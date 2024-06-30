using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenLevelBarScript : MonoBehaviour
{
    public Image oxygenLevelBarImage;

    public void UpdateOxygenBar(float currentOxygen, float maxOxygen)
    {
        oxygenLevelBarImage.fillAmount = currentOxygen / maxOxygen;
    }
}
