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
    //public GameObject playerController;
    public float speed;
    public GameObject enemydeathparticlesPrefab;
    Rigidbody rb;
    [Range(0f, 1f)]
    public float dropRate;
    public List<GameObject> drops;
    //public Script_Player_Controller Player;


    void Start()
    {
        //Player = playerController.GetComponent<Script_Player_Controller>();
        rb = GetComponent<Rigidbody>();

        player = GameObject.Find("Player");
        //player = gameObject.GetComponent<Script_Player_Controller>();

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
        //player.ChangeXP(+10);
        //player.GainedXP();
        Debug.Log("Ouch!");
        
        healthPoints--;
        
        if (healthPoints <= 0) 
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "blast") {
            Die();
        }
    }


    void OnCollisionEnter(Collision other)
    {
        Script_Player_Controller player = other.gameObject.GetComponent<Script_Player_Controller>();

        if (player != null)
        {
            player.ChangeHearts(-1);
            player.ChangeXP(+10);
            player.TakeDamage();
            player.GainedXP();
        }

        if (player != null && player.currentHearts < 1)
        {
            player.GameOver();
        }

    }
    
    void Drop() {
        float roll;
        roll = Random.Range(0f,1f);
        Debug.Log(roll);
        if (roll < dropRate) {
            Instantiate(drops[Random.Range(0,drops.Count-1)], transform.position, transform.rotation);
        }
    }

    void Die() {
        // Script_Player_Controller player = player.GetComponent<Script_Player_Controller>();
        // Player.ChangeXP(+10);
        // Player.GainedXP();

        Instantiate(enemydeathparticlesPrefab, rb.position + Vector3.up * 0.5f, Quaternion.identity);
        Drop();
        Destroy(gameObject);
    }
}
