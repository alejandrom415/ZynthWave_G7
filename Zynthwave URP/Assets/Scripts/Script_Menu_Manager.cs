using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_Menu_Manager : MonoBehaviour
{
    
    public GameObject mainMenu, settingsMenu, helpMenu, creditsMenu, logoImg, whitePanel;
    public GameObject playBtn, settingsBtn, settingsBackBtn, helpBtn, helpBackBtn, creditsBtn, creditsBackBtn, quitBtn;

    public void MainMenuOn()
    {
        mainMenu.SetActive(true);
    }

    public void MainMenuOff()
    {
        mainMenu.SetActive(false);
    }

    public void NoSelection()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    void Start()
    {
        LeanTween.alpha(logoImg.GetComponent<RectTransform>(), 1f, 3f).setDelay(0.5f);

        //Deselecting all buttons as protocol
        NoSelection();

        //Making the Play Button the first selected button
        EventSystem.current.SetSelectedGameObject(playBtn);
    }

    public void StartGame() => LeanTween.alpha(whitePanel.GetComponent<RectTransform>(), 1f, 1f).setOnComplete(PlayClick);

    void PlayClick() => SceneManager.LoadScene("Arcade");

    public void OpenSettings()
    {
        MainMenuOff();
        settingsMenu.SetActive(true);
        NoSelection();
        EventSystem.current.SetSelectedGameObject(settingsBackBtn);
    }

    public void CloseSettings()
    {
        MainMenuOn();
        settingsMenu.SetActive(false);
        NoSelection();
        EventSystem.current.SetSelectedGameObject(settingsBtn);
    }

    public void OpenHelp()
    {
        MainMenuOff();
        helpMenu.SetActive(true);
        NoSelection();
        EventSystem.current.SetSelectedGameObject(helpBackBtn);
    }

    public void CloseHelp()
    {
        MainMenuOn();
        helpMenu.SetActive(false);
        NoSelection();
        EventSystem.current.SetSelectedGameObject(helpBtn);
    }

    public void OpenCredits()
    {
        MainMenuOff();
        creditsMenu.SetActive(true);
        NoSelection();
        EventSystem.current.SetSelectedGameObject(creditsBackBtn);
    }

    public void CloseCredits()
    {
        MainMenuOn();
        creditsMenu.SetActive(false);
        NoSelection();
        EventSystem.current.SetSelectedGameObject(creditsBtn);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("I quit the game.");
    }
   
}
