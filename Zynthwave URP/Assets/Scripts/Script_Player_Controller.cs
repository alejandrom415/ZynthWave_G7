using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Script_Player_Controller : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    //public float maxSpeed;
    //public float slowDownSpeed;
    //public float stopSpeed;
    public InputAction leftStick;
    public InputAction rightStick;
    public ParticleSystem bullets;
    public TMP_Text gameOverText;
    //public TMP_Text heartsText;
    public int maxHearts = 5;
    public int minHearts = 0;
    public int hearts { get { return currentHearts; } }
    public int currentHearts;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    public Script_Health_Bar healthBar;
    Animator anim;

    //set up controller
    void OnEnable() {
        leftStick.Enable();
        rightStick.Enable();
    }
    void OnDisable() {
        leftStick.Disable();
        rightStick.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bullets = bullets.GetComponent<ParticleSystem>();

        anim = GetComponent<Animator>();

        currentHearts = maxHearts;
        healthBar.SetMaxHealth(maxHearts);

        gameOverText.text = "";
        // hearts = 4;
        // SetHeartsText();
    }

    // void SetHeartsText()
    // {
    //     heartsText.text = "Hearts: " + text.ToString;
    // }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
                Debug.Log ("NOT INVINCIBLE");
        }

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void TakeDamage()
    {
        healthBar.SetHealth(currentHearts);
    }


    public void ChangeHearts(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            Debug.Log ("INVINCIBLE");
        }

        if (hearts == minHearts)
        {
            GameOver();
        }

        currentHearts = Mathf.Clamp(currentHearts + amount, 0, maxHearts);
        //UIHearts.instance.SetValue(currentHearts / (float)maxHearts);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //CheckInput();
        GamepadInputs();
    }

    void GamepadInputs() {
        Vector2 direction = leftStick.ReadValue<Vector2>();
        Vector2 lookDirection = rightStick.ReadValue<Vector2>();
        
        rb.velocity = new Vector3(direction.x*speed, 0, direction.y*speed);
        Vector3 lookVector = new Vector3(lookDirection.x, 0, lookDirection.y);
        transform.rotation = Quaternion.LookRotation(lookVector);
        if (lookDirection.x > 0.8 || lookDirection.x < -0.8 || lookDirection.y > 0.8 || lookDirection.y < -0.8) {
            Shoot(true);
        } else {
            Shoot(false);
        }
        //Debug.Log(lookDirection);
    }

    void Shoot(bool isShooting) {
        ParticleSystem.EmissionModule em = bullets.GetComponent<ParticleSystem>().emission;
        if (isShooting) {
            em.enabled = true;
            return;
        }
        em.enabled = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Hearts")
        {
            if (hearts < maxHearts)
            {
                currentHearts = currentHearts + 1;

                Debug.Log("HEARTS COLLECTED");

                Destroy(collider.gameObject);
            }
        }

        if (collider.tag == "Speed")
        {
            speed = speed * 2;

            Debug.Log("SPEED BOOST");

            Destroy(collider.gameObject);
        }
    }

    void GameOver()
    {
        gameOverText.text = "YOU LOSE! - ESC TO QUIT TO MENU";
        
        Destroy(gameObject.GetComponent<Collider>());
        
        isInvincible = true;
        
        invincibleTimer = 9999;

        speed = 0;
    }

    public void ChangeHealthBuff()
    {
        maxHearts = maxHearts + 1;
        currentHearts = maxHearts;
        healthBar.SetMaxHealth(maxHearts);
    }



    /*void CheckInput() {
        if (Input.GetKey(KeyCode.W)) {
            Move("up");
        }
        if (Input.GetKey(KeyCode.S)) {
            Move("down");
        }
        if (Input.GetKey(KeyCode.A)) {
            Move("left");
        }
        if (Input.GetKey(KeyCode.D)) {
            Move("right");
        }
        //Check if user is not using any movement inputs
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            SlowDown();
        }
    }

    void Move(string input) {
        switch (input) {
            case "up":
                if (rb.velocity.z < 0) {
                    rb.velocity = new Vector3(rb.velocity.x, 0, -rb.velocity.z);
                    break;
                }
                if (rb.velocity.z < maxSpeed) {
                    rb.AddForce(new Vector3(0, 0, speed));
                }
                break;
            case "down":
                if (rb.velocity.z > 0) {
                    rb.velocity = new Vector3(rb.velocity.x, 0, -rb.velocity.z);
                    break;
                }
                if (rb.velocity.z > -maxSpeed) {
                    rb.AddForce(new Vector3(0, 0, -speed));
                }
                break;
            case "left":
                if (rb.velocity.x > 0) {
                    rb.velocity = new Vector3(-rb.velocity.x, 0, rb.velocity.z);
                    break;
                }
                if (rb.velocity.x > -maxSpeed) {
                    rb.AddForce(new Vector3(-speed, 0, 0));
                }
                break;
            case "right":
                if (rb.velocity.x < 0) {
                    rb.velocity = new Vector3(-rb.velocity.x, 0, rb.velocity.z);
                    break;
                }
                if (rb.velocity.x < maxSpeed) {
                    rb.AddForce(new Vector3(speed, 0, 0));
                }
                break;
        }
    }
    void SlowDown() {
        //Check Horizontal speed
        if (rb.velocity.x != 0) {
            //stop threshold
            if (rb.velocity.x < stopSpeed && rb.velocity.x > -stopSpeed) {
                //Set horizontal speed to 0 while maintaining vertical speed
                rb.velocity = new Vector3(0,0,rb.velocity.z);
            }
            //Apply slowdown force
            if (rb.velocity.x > 0) {
                rb.AddForce(new Vector3(-slowDownSpeed, 0, 0));
            }
            if (rb.velocity.x < 0) {
                rb.AddForce(new Vector3(slowDownSpeed, 0, 0));
            }
        }
        //Check vertical speed
        if (rb.velocity.z != 0) {
            if (rb.velocity.z < stopSpeed && rb.velocity.z > -stopSpeed) {
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            }
            if (rb.velocity.z > 0) {
                rb.AddForce(new Vector3(0,0,-slowDownSpeed));
            }
            if (rb.velocity.z < 0) {
                rb.AddForce(new Vector3(0,0,slowDownSpeed));
            }
        }
    }*/
}
