using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Health_Bar : MonoBehaviour
{

    public GameObject playerController;
    public Slider HpSlider;

    
    public void SetMaxHealth(int hearts)
    {
        HpSlider.maxValue = hearts;
        HpSlider.value = hearts;
    }

    public void SetHealth(int hearts)
    {
        HpSlider.value = hearts;
    }
    


}
