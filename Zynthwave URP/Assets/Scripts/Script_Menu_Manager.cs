using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_Menu_Manager : MonoBehaviour
{
    public GameObject logoImg, groupImg, transitionPanel, splashscreenPanel, controllerImg, prodImg;                        // Background Elements
    public GameObject mainMenu, settingsMenu, helpMenu, creditsMenu;                                                        // Menu Elements
    public GameObject playBtn, settingsBtn, settingsBackBtn, helpBtn, helpBackBtn, creditsBtn, creditsBackBtn, quitBtn;     // Button Elements
    public GameObject firstRow, secondRow, thirdRow;

    public void MainMenuOn() => mainMenu.SetActive(true);
    public void MainMenuOff() => mainMenu.SetActive(false);
    public void NoSelect() => EventSystem.current.SetSelectedGameObject(null);
    public void ButtonsOut()
    {
        LeanTween.moveLocal(playBtn, new Vector3(-1200f, 120f, 0f), 0.2f).setEase(LeanTweenType.easeInCubic);
        LeanTween.moveLocal(settingsBtn, new Vector3(-1200f, 20f, 0f), 0.3f).setEase(LeanTweenType.easeInCubic);
        LeanTween.moveLocal(helpBtn, new Vector3(-1200f, -80f, 0f), 0.4f).setEase(LeanTweenType.easeInCubic);
        LeanTween.moveLocal(creditsBtn, new Vector3(-1200f, -180f, 0f), 0.5f).setEase(LeanTweenType.easeInCubic);
        LeanTween.moveLocal(quitBtn, new Vector3(-1200f, -280f, 0f), 0.6f).setEase(LeanTweenType.easeInCubic);
    }
    public void ButtonsIn()
    {
        LeanTween.moveLocal(playBtn, new Vector3(0f, 120f, 0f), 0.2f).setDelay(0.6f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocal(settingsBtn, new Vector3(0f, 20f, 0f), 0.3f).setDelay(0.6f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocal(helpBtn, new Vector3(0f, -80f, 0f), 0.4f).setDelay(0.6f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocal(creditsBtn, new Vector3(0f, -180f, 0f), 0.5f).setDelay(0.6f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocal(quitBtn, new Vector3(0f, -280f, 0f), 0.6f).setDelay(0.6f).setEase(LeanTweenType.easeOutCubic);
    }

    void Start()
    {
        LeanTween.moveLocal(groupImg, new Vector3(0f, 155f, 0f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(groupImg, new Vector3(1400f, 155f, 0f), 1f).setDelay(2.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.moveLocal(prodImg, new Vector3(0f, -180f, 0f), 1f).setDelay(1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(prodImg, new Vector3(-1320f, -180f, 0f), 1f).setDelay(3f).setEase(LeanTweenType.easeInBack);

        LeanTween.scale(logoImg, new Vector3(1f, 1f, 1f), 1.5f).setDelay(4f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocal(logoImg, new Vector3(0f, 520f, 0f), 1f).setDelay(6f).setEase(LeanTweenType.easeInCubic);
        LeanTween.scale(logoImg, new Vector3(0.6f, 0.6f, 0.6f), 1f).setDelay(6f).setEase(LeanTweenType.easeInCubic);

        LeanTween.alpha(splashscreenPanel.GetComponent<RectTransform>(), 0f, 3.5f).setDelay(6.1f);

        LeanTween.moveLocal(playBtn, new Vector3(0f, 120f, 0f), 1.2f).setDelay(6.8f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(settingsBtn, new Vector3(0f, 20f, 0f), 1.2f).setDelay(7.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(helpBtn, new Vector3(0f, -80f, 0f), 1.2f).setDelay(7.4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(creditsBtn, new Vector3(0f, -180f, 0f), 1.2f).setDelay(7.7f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(quitBtn, new Vector3(0f, -280f, 0f), 1.2f).setDelay(8f).setEase(LeanTweenType.easeOutElastic).setOnComplete(SplashScreenDone);   
    }

    void SplashScreenDone()
    {
        NoSelect();
        EventSystem.current.SetSelectedGameObject(playBtn);
    }

    public void StartGame() => LeanTween.alpha(transitionPanel.GetComponent<RectTransform>(), 1f, 1f).setOnComplete(PlayClicked);
    void PlayClicked() => SceneManager.LoadScene("Arcade");

    public void OpenSettings()
    {
        ButtonsOut();
        LeanTween.moveLocal(settingsBackBtn, new Vector3(-800f, -450f, 0f), 0.8f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        
        NoSelect();
        EventSystem.current.SetSelectedGameObject(settingsBackBtn);
    }

    public void CloseSettings()
    {
        ButtonsIn();
        LeanTween.moveLocal(settingsBackBtn, new Vector3(-1110f, -450f, 0f), 0.3f).setEase(LeanTweenType.easeInCubic);
        
        NoSelect();
        EventSystem.current.SetSelectedGameObject(settingsBtn);
    }

    public void OpenHelp()
    {
        ButtonsOut();
        LeanTween.moveLocal(helpBackBtn, new Vector3(-800f, -450f, 0f), 0.8f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(controllerImg, new Vector3(0f, 0f, 0f), 0.8f).setDelay(0.5f).setEase(LeanTweenType.easeOutCubic);
        
        NoSelect();
        EventSystem.current.SetSelectedGameObject(helpBackBtn);
    }

    public void CloseHelp()
    {
        ButtonsIn();
        LeanTween.moveLocal(helpBackBtn, new Vector3(-1110f, -450f, 0f), 0.3f).setEase(LeanTweenType.easeInCubic);
        LeanTween.moveLocal(controllerImg, new Vector3(900f, 0f, 0f), 0.3f).setEase(LeanTweenType.easeInCubic);
        
        NoSelect();
        EventSystem.current.SetSelectedGameObject(helpBtn);
    }

    public void OpenCredits()
    {
        ButtonsOut();
        LeanTween.alpha(splashscreenPanel.GetComponent<RectTransform>(), 0.9f, 1f).setDelay(0.2f);
        LeanTween.scale(firstRow, new Vector3(1f, 1f, 1f), 1.5f).setDelay(0.4f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.scale(secondRow, new Vector3(1f, 1f, 1f), 1.5f).setDelay(0.6f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.scale(thirdRow, new Vector3(1f, 1f, 1f), 1.5f).setDelay(0.8f).setEase(LeanTweenType.easeOutCubic).setOnComplete(CreditsOpened);
    }

    void CreditsOpened()
    {
        LeanTween.moveLocal(creditsBackBtn, new Vector3(-800f, -450f, 0f), 0.8f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        NoSelect();
        EventSystem.current.SetSelectedGameObject(creditsBackBtn);
    }

    public void CloseCredits()
    {
        
        LeanTween.alpha(splashscreenPanel.GetComponent<RectTransform>(), 0f, 1f).setDelay(0.2f);
        LeanTween.moveLocal(creditsBackBtn, new Vector3(-1110f, -450f, 0f), 0.3f).setEase(LeanTweenType.easeInCubic);

        LeanTween.scale(firstRow, new Vector3(1f, 0f, 1f), 0.6f).setEase(LeanTweenType.easeInCubic);
        LeanTween.scale(secondRow, new Vector3(1f, 0f, 1f), 0.4f).setEase(LeanTweenType.easeInCubic);
        LeanTween.scale(thirdRow, new Vector3(1f, 0f, 1f), 0.2f).setEase(LeanTweenType.easeInCubic);

        ButtonsIn();
        NoSelect();
        EventSystem.current.SetSelectedGameObject(creditsBtn);
    }

    public void QuitGame() => Application.Quit();
   
}
