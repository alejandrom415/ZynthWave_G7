using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Script_PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, resumeBtn, mainmenuBtn, quitBtn;

    public static bool isPaused;

    void Awake()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeBtn);
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        isPaused = false;
    }
    
    public void QuitGame() => Application.Quit();
}
