using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Controller : MonoBehaviour
{
    public int healthPoints;
    GameObject player; 
    public float speed;
    public GameObject enemydeathparticlesPrefab;
    Rigidbody rb;
    [Range(0f, 1f)]
    public float dropRate;
    public List<GameObject> drops;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime; // calculate distance to move
        
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    void OnParticleCollision() 
    {
        //Debug.Log("Ouch!");
        
        healthPoints--;
        
        if (healthPoints <= 0) 
        {
            Instantiate(enemydeathparticlesPrefab, rb.position + Vector3.up * 0.5f, Quaternion.identity);
            Drop();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Script_Player_Controller player = other.gameObject.GetComponent<Script_Player_Controller>();

        if (player != null)
        {
            player.ChangeHearts(-1);
        }
    }
    void Drop() {
        float roll;
        roll = Random.Range(0f,1f);
        Debug.Log(roll);
        if (roll < dropRate) {
            Instantiate(drops[0], transform.position, transform.rotation);
            
            //instantiate pickup
        }
    }
}
