using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_GameUI : MonoBehaviour
{
    public GameObject whitePanel, hpBack, hpFill, hpBord, xpBack, xpFill, xpBord;

    void Start()
    {
        LeanTween.alpha(whitePanel.GetComponent<RectTransform>(), 0f, 1.5f);
        LeanTween.alpha(hpBack.GetComponent<RectTransform>(), 1f, 1f).setDelay(1.8f);
        LeanTween.alpha(hpFill.GetComponent<RectTransform>(), 1f, 1f).setDelay(1.8f);
        LeanTween.alpha(hpBord.GetComponent<RectTransform>(), 1f, 1f).setDelay(1.8f);
        LeanTween.alpha(xpBack.GetComponent<RectTransform>(), 1f, 1f).setDelay(2.2f);
        LeanTween.alpha(xpFill.GetComponent<RectTransform>(), 0.3f, 1f).setDelay(2.2f);
        LeanTween.alpha(xpBord.GetComponent<RectTransform>(), 1f, 1f).setDelay(2.2f);
    }

    
}
