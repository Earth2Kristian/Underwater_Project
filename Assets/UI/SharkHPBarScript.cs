using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkHPBarScript : MonoBehaviour
{
    public Image sharkHPBarImage;

    public void UpdateSharkHPBar(float currentSharkHP, float maxSharkHP)
    {
        sharkHPBarImage.fillAmount = currentSharkHP / maxSharkHP;
    }
}
