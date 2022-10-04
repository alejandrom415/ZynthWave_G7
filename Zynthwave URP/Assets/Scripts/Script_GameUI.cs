using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_GameUI : MonoBehaviour
{
    public GameObject whitePanel, hpBack, hpFill, hpBord, hpTxt, hpImg, xpBack, xpFill, xpBord, xpTxt, xpImg;
    public GameObject playerController;
    Script_Player_Controller player;

    void Start()
    {
        LeanTween.alpha(whitePanel.GetComponent<RectTransform>(), 0f, 1.5f);

        LeanTween.alpha(hpBack.GetComponent<RectTransform>(), 1f, 1f).setDelay(1.8f);
        LeanTween.alpha(hpFill.GetComponent<RectTransform>(), 0.9f, 1f).setDelay(1.8f);
        LeanTween.alpha(hpBord.GetComponent<RectTransform>(), 1f, 1f).setDelay(1.8f);
        LeanTween.scale(hpTxt, new Vector3(1f, 1f, 1f), 1f).setDelay(2.1f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.alpha(hpImg.GetComponent<RectTransform>(), 1f, 1f).setDelay(2.1f);
        LeanTween.moveLocal(hpImg, new Vector3(170f, -8f, 0f), 1.6f).setDelay(2.1f).setEase(LeanTweenType.easeOutCubic);

        LeanTween.alpha(xpBack.GetComponent<RectTransform>(), 1f, 1f).setDelay(2.2f);
        LeanTween.alpha(xpFill.GetComponent<RectTransform>(), 0.9f, 1f).setDelay(2.2f);
        LeanTween.alpha(xpBord.GetComponent<RectTransform>(), 1f, 1f).setDelay(2.2f);
        LeanTween.scale(xpTxt, new Vector3(1f, 1f, 1f), 1f).setDelay(2.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.alpha(xpImg.GetComponent<RectTransform>(), 1f, 1f).setDelay(2.5f);
        LeanTween.moveLocal(xpImg, new Vector3(170f, -8f, 0f), 1.6f).setDelay(2.5f).setEase(LeanTweenType.easeOutCubic);

    }
    
}
