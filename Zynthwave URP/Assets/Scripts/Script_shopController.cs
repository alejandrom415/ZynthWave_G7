using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_shopController : MonoBehaviour
{
    public GameObject healthBtn, speedBtn, accuracyBtn, firerateBtn, playerController, spawnerController;
    public GameObject healthImg;

    Script_Player_Controller player;
    Script_Enemy_Wave_Spawner spawner;
    
    void Awake()
    {
        player = playerController.GetComponent<Script_Player_Controller>();
        spawner = spawnerController.GetComponent<Script_Enemy_Wave_Spawner>();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(healthBtn);
    }

    public void BuffHealth()
    {
        player.ChangeHealthBuff();
        spawner.StartNextWave();
        LeanTween.alpha(healthImg.GetComponent<RectTransform>(), 1f, 0.2f);
        LeanTween.moveLocal(healthImg, new Vector3(160f, 0f, 0f), 1f).setDelay(1f).setEase(LeanTweenType.easeOutExpo);
        LeanTween.alpha(healthImg.GetComponent<RectTransform>(), 0f, 0.2f).setDelay(2f);
    }

    public void BuffSpeed()
    {
        
        spawner.StartNextWave();
    }

    public void BuffAccuracy()
    {
        
        spawner.StartNextWave();
    }

    public void BuffFireRate()
    {
        
        spawner.StartNextWave();
    }
}
