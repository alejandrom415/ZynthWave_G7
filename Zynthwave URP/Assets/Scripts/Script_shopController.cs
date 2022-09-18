using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_shopController : MonoBehaviour
{
    public GameObject healthBtn, speedBtn, accuracyBtn, firerateBtn;

    //Rigidbody rb;
    
    void Awake()
    {
        //Script_Player_Controller player = gameObject.GetComponent<Script_Player_Controller>();
        //rb.constraints = RigidbodyConstraints.FreezePosition;
        //Time.timeScale = 0;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(healthBtn);
    }

    public void BuffHealth()
    {
        Script_Player_Controller player = gameObject.GetComponent<Script_Player_Controller>();
        if (player.currentHearts < 4)
        {
            player.ChangeHearts(+1);
        }
        player.ChangeHearts(+1);
        Script_Enemy_Wave_Spawner spawner = gameObject.GetComponent<Script_Enemy_Wave_Spawner>();
        spawner.StartNextWave();
    }

    public void BuffSpeed()
    {
        Script_Enemy_Wave_Spawner spawner = gameObject.GetComponent<Script_Enemy_Wave_Spawner>();
        spawner.StartNextWave(); //
    }

    public void BuffAccuracy()
    {
        Script_Enemy_Wave_Spawner spawner = gameObject.GetComponent<Script_Enemy_Wave_Spawner>();
        spawner.StartNextWave(); //
    }

    public void BuffFireRate()
    {
        Script_Enemy_Wave_Spawner spawner = gameObject.GetComponent<Script_Enemy_Wave_Spawner>();
        spawner.StartNextWave(); //
    }
}
