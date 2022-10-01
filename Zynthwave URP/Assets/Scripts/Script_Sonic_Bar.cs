using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Sonic_Bar : MonoBehaviour
{
    public GameObject playerController;
    public Slider SonicSlider;

    
    public void SetMaxXP(int XP)
    {
        SonicSlider.maxValue = XP;
        SonicSlider.value = XP;
    }

    public void SetXP(int XP)
    {
        SonicSlider.value = XP;
    }
    
}
