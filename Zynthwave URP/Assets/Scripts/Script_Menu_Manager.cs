using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_Menu_Manager : MonoBehaviour
{
    public GameObject logoImg, groupImg, transitionPanel, splashscreenPanel;                                                // Background Elements
    public GameObject mainMenu, settingsMenu, helpMenu, creditsMenu;                                                        // Menu Elements
    public GameObject playBtn, settingsBtn, settingsBackBtn, helpBtn, helpBackBtn, creditsBtn, creditsBackBtn, quitBtn;     // Button Elements

    public void MainMenuOn() => mainMenu.SetActive(true);
    public void MainMenuOff() => mainMenu.SetActive(false);
    public void NoSelect() => EventSystem.current.SetSelectedGameObject(null);

    void Start()
    {
        LeanTween.moveLocal(groupImg, new Vector3(0f, 155f, 0f), 1f).setDelay(1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.moveLocal(groupImg, new Vector3(1400f, 155f, 0f), 1f).setDelay(3f).setEase(LeanTweenType.easeInBack);

        LeanTween.scale(logoImg, new Vector3(1f, 1f, 1f), 1.5f).setDelay(4.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.moveLocal(logoImg, new Vector3(0f, 500f, 0f), 1f).setDelay(6.5f).setEase(LeanTweenType.easeInCubic);
        LeanTween.scale(logoImg, new Vector3(0.6f, 0.6f, 0.6f), 1f).setDelay(6.5f).setEase(LeanTweenType.easeInCubic);

        LeanTween.alpha(splashscreenPanel.GetComponent<RectTransform>(), 0f, 3.5f).setDelay(6.6f);

        LeanTween.moveLocal(playBtn, new Vector3(0f, 120f, 0f), 1.5f).setDelay(7.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(settingsBtn, new Vector3(0f, 20f, 0f), 1.5f).setDelay(7.8f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(helpBtn, new Vector3(0f, -80f, 0f), 1.5f).setDelay(8.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(creditsBtn, new Vector3(0f, -180f, 0f), 1.5f).setDelay(8.4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(quitBtn, new Vector3(0f, -280f, 0f), 1.5f).setDelay(8.7f).setEase(LeanTweenType.easeOutElastic).setOnComplete(SplashScreenDone);   
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
        MainMenuOff();
        settingsMenu.SetActive(true);
        NoSelect();
        EventSystem.current.SetSelectedGameObject(settingsBackBtn);
    }

    public void CloseSettings()
    {
        MainMenuOn();
        settingsMenu.SetActive(false);
        NoSelect();
        EventSystem.current.SetSelectedGameObject(settingsBtn);
    }

    public void OpenHelp()
    {
        MainMenuOff();
        helpMenu.SetActive(true);
        NoSelect();
        EventSystem.current.SetSelectedGameObject(helpBackBtn);
    }

    public void CloseHelp()
    {
        MainMenuOn();
        helpMenu.SetActive(false);
        NoSelect();
        EventSystem.current.SetSelectedGameObject(helpBtn);
    }

    public void OpenCredits()
    {
        MainMenuOff();
        creditsMenu.SetActive(true);
        NoSelect();
        EventSystem.current.SetSelectedGameObject(creditsBackBtn);
    }

    public void CloseCredits()
    {
        MainMenuOn();
        creditsMenu.SetActive(false);
        NoSelect();
        EventSystem.current.SetSelectedGameObject(creditsBtn);
    }

    public void QuitGame() => Application.Quit();
   
}
