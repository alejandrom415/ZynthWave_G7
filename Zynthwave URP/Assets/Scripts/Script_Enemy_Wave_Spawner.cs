using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Wave_Spawner : MonoBehaviour
{
    //[System Serializable]

    public class Wave
    {
        public string name;

        public Transform enemy;

        public int count;

        public float rate;
    }
    
    public Wave[] waves;

    private int nextWave = 0;

    public float timeBetweenWaves = 15f;

    public float waveCountdown;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (waveCountdown <= 0)
        {

        }
    }
}
