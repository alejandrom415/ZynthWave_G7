using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_Enemy_Wave_Spawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    public GameObject shopBackground, waveStartImg, waveEndImg;

    [System.Serializable]

    public class Wave
    {
        public string name;

        public GameObject enemy;

        public int count;

        public float rate;
    }
    
    public Wave[] waves;

    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 15f;

    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    { 
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("NO SPAWN POINTS REFERENCED");
        }

        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }

            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave ( waves[nextWave] ) );
                waveStartImg.SetActive(true);
            }
        }

        else
        {
            waveCountdown -= Time.deltaTime;
        }

        transform.Rotate (new Vector3 (0,15,0) * Time.deltaTime);
    }

    void WaveCompleted()
    {
        Debug.Log ("WAVE COMPLETED");

        state = SpawnState.COUNTING;

        waveCountdown = timeBetweenWaves;

        waveStartImg.SetActive(false);
        waveEndImg.SetActive(true);
        shopBackground.SetActive(true);
        Time.timeScale = 0;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;

            Debug.Log ("ALL WAVES COMPLETE! LOOPING...");
        }

        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log ("SPAWNING WAVE: " + _wave.name);

        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);

            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(GameObject _enemy)
    {
        Debug.Log ("SPAWNING ENEMY: " + _enemy.name);

        Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];

        Instantiate (_enemy, _sp.position, _sp.rotation);
    }

    public void StartNextWave()
    {
        shopBackground.SetActive(false);
        Time.timeScale = 1;
        waveEndImg.SetActive(false);
        //waveStartImg.SetActive(true);
        waveCountdown = 1;
        return;
    }
}
