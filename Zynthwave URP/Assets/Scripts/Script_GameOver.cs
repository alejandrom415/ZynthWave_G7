using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Script_GameOver : MonoBehaviour
{
    
    public GameObject mainmenuBtn, quitBtn;

    void Awake()
    {
        LeanTween.moveLocal(mainmenuBtn, new Vector3(0f, -100f, 0f), 1f).setDelay(1.8f).setEase(LeanTweenType.easeInCubic);
        LeanTween.moveLocal(quitBtn, new Vector3(0f, -300f, 0f), 1.2f).setDelay(1.8f).setEase(LeanTweenType.easeInCubic).setOnComplete(FreezeGame);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainmenuBtn);
    }

    void FreezeGame()
    {
        Time.timeScale = 0;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    
    public void QuitGame() => Application.Quit();

    
}
