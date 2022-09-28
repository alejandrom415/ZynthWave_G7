using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_shopController : MonoBehaviour
{
    public GameObject healthBtn, speedBtn, accuracyBtn, firerateBtn, shopBackground, playerController, spawnerController;

    public ParticleSystem bullets;

    Script_Player_Controller player;
    Script_Enemy_Wave_Spawner spawner;
    
    void Awake()
    {
        bullets = bullets.GetComponent<ParticleSystem>();
        player = playerController.GetComponent<Script_Player_Controller>();
        spawner = spawnerController.GetComponent<Script_Enemy_Wave_Spawner>();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(healthBtn);
    }

    public void BuffHealth()
    {
        Time.timeScale = 1;
        player.ChangeHealthBuff();
        LeanTween.moveLocal(shopBackground, new Vector3(0f, 1050f, 0f), 1f).setEase(LeanTweenType.easeInCirc).setOnComplete(GoToNextWave);
    }

    public void BuffSpeed()
    {
        Time.timeScale = 1;
        player.ChangeSpeedBuff();
        LeanTween.moveLocal(shopBackground, new Vector3(0f, 1050f, 0f), 1f).setEase(LeanTweenType.easeInCirc).setOnComplete(GoToNextWave); 
    }

    public void BuffAccuracy()
    {
        Time.timeScale = 1;
        player.ChangeArc();
        LeanTween.moveLocal(shopBackground, new Vector3(0f, 1050f, 0f), 1f).setEase(LeanTweenType.easeInCirc).setOnComplete(GoToNextWave);
    }

    public void BuffFireRate()
    {
        Time.timeScale = 1;
        player.ChangeROF();
        LeanTween.moveLocal(shopBackground, new Vector3(0f, 1050f, 0f), 1f).setEase(LeanTweenType.easeInCirc).setOnComplete(GoToNextWave);
    }

    void GoToNextWave()
    {
        spawner.StartNextWave();
    }
}
