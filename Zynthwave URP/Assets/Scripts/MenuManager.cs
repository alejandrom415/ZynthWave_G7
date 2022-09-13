using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    
    public GameObject mainMenu, settingsMenu, helpMenu, creditsMenu;
    public GameObject playBtn, settingsBtn, settingsBackBtn, helpBtn, helpBackBtn, creditsBtn, creditsBackBtn, quitBtn;

    void Start()
    {
        //Deselecting all buttons as protocol
        EventSystem.current.SetSelectedGameObject(null);

        //Making the Start Button the first selected button
        EventSystem.current.SetSelectedGameObject(playBtn);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Arcade");
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsBackBtn);
    }

    public void CloseSettings()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsBtn);
    }

    public void OpenHelp()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(helpBackBtn);
    }

    public void CloseHelp()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(helpBtn);
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsBackBtn);
    }

    public void CloseCredits()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsBtn);
    }

    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("I quit the game.");
    }
   
}
