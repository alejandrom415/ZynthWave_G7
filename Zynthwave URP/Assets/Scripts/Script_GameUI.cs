using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_GameUI : MonoBehaviour
{
    public GameObject whitePanel, hpBack, hpFill, hpBord, xpBack, xpFill, xpBord,
    healthTokenPop, speedTokenPop, rofTokenPop, invincibleTokenPop, sonicTokenPop;
    public GameObject playerController;
    Script_Player_Controller player;

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

    public void HealTokenPop()
    {
        LeanTween.moveLocal(healthTokenPop, new Vector3(-750f, 200f, 0f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeInCirc);
        LeanTween.moveLocal(healthTokenPop, new Vector3(-1160f, 200f, 0f), 1f).setDelay(4.5f).setEase(LeanTweenType.easeOutCirc);
    }

    public void SpeedTokenPop()
    {
        LeanTween.moveLocal(speedTokenPop, new Vector3(-750f, 130f, 0f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeInCirc);
        LeanTween.moveLocal(speedTokenPop, new Vector3(-1160f, 130f, 0f), 1f).setDelay(4.5f).setEase(LeanTweenType.easeOutCirc);
    }

    public void RoFTokenPop()
    {
        LeanTween.moveLocal(rofTokenPop, new Vector3(-730f, 60f, 0f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeInCirc);
        LeanTween.moveLocal(rofTokenPop, new Vector3(-1180f, 60f, 0f), 1f).setDelay(4.5f).setEase(LeanTweenType.easeOutCirc);
    }

    public void InvincibilityTokenPop()
    {
        LeanTween.moveLocal(invincibleTokenPop, new Vector3(-750f, -10f, 0f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeInCirc);
        LeanTween.moveLocal(invincibleTokenPop, new Vector3(-1160f, -10f, 0f), 1f).setDelay(4.5f).setEase(LeanTweenType.easeOutCirc);
    }

    public void SonicBlastTokenPop()
    {
        LeanTween.moveLocal(sonicTokenPop, new Vector3(-670f, -80f, 0f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeInCirc);
        LeanTween.moveLocal(sonicTokenPop, new Vector3(-1230f, -80f, 0f), 1f).setDelay(4.5f).setEase(LeanTweenType.easeOutCirc);
    }
    
}
