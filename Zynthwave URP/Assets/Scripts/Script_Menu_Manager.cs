using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_Menu_Manager : MonoBehaviour
{
    public GameObject logoImg, whitePanel;                                                                                  // Background Elements
    public GameObject mainMenu, settingsMenu, helpMenu, creditsMenu;                                                        // Menu Elements
    public GameObject playBtn, settingsBtn, settingsBackBtn, helpBtn, helpBackBtn, creditsBtn, creditsBackBtn, quitBtn;     // Button Elements

    public void MainMenuOn() => mainMenu.SetActive(true);
    public void MainMenuOff() => mainMenu.SetActive(false);
    public void NoSelect() => EventSystem.current.SetSelectedGameObject(null);

    void Start()
    {
        LeanTween.alpha(logoImg.GetComponent<RectTransform>(), 1f, 3f).setDelay(0.5f);
        NoSelect();
        EventSystem.current.SetSelectedGameObject(playBtn);
    }

    public void StartGame() => LeanTween.alpha(whitePanel.GetComponent<RectTransform>(), 1f, 1f).setOnComplete(PlayClicked);
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

    public void QuitGame() => Debug.Log("I quit the game.");
    // {
    //     Application.Quit();
    // }
   
}
