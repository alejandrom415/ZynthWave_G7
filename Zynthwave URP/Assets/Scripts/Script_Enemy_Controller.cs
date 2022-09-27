using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Script_Enemy_Controller : MonoBehaviour
{
    //[SerializeField] private Transform playerTransform;
    public NavMeshAgent navMeshAgent;
    public int healthPoints;
    public GameObject player; 
    public float speed;
    public GameObject enemydeathparticlesPrefab;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.Find("Player");

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime; // calculate distance to move
        
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        //navMeshAgent.destination = playerTransform.position;

        navMeshAgent.SetDestination(player.transform.position);
    }

    void OnParticleCollision() 
    {
        Debug.Log("Ouch!");
        
        healthPoints--;
        
        if (healthPoints <= 0) 
        {
            Instantiate(enemydeathparticlesPrefab, rb.position + Vector3.up * 0.5f, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Script_Player_Controller player = other.gameObject.GetComponent<Script_Player_Controller>();

        if (player != null)
        {
            player.ChangeHearts(-1);
            player.TakeDamage();
        }

        if (player != null && player.currentHearts < 1)
        {
            player.GameOver();
        }

    }
}
