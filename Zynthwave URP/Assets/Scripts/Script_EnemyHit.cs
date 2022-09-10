using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EnemyHit : MonoBehaviour
{
    public int healthPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision() {
        Debug.Log("Ouch!");
        healthPoints--;
        if (healthPoints <= 0) {
            gameObject.SetActive(false);
        }
    }
}
