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
    public InputAction startButton;
    public InputAction rightBumper;
    public GameObject sonicBoom;
    
    public ParticleSystem bullets;
    public float rateOverTime;
    public float arc;

    //private ParticleSystem.EmissionModule em;
    //private ParticleSystem.ShapeModule sh;

    //public TMP_Text gameOverText;
    //public TMP_Text heartsText;
    public int maxHearts = 5;
    //public int minHearts = 0;
    public int hearts { get { return currentHearts; } }
    public int currentHearts;
    public float timeInvincible = 2.0f;
    public float timePowered = 10f;
    bool isInvincible;
    float invincibleTimer;

    public float timeSpeed = 10f;
    bool isSpeeding;
    public float speedTimer;

    public float timeDoubleRoF = 10f;
    bool isDoubleRoF;
    public float doubleRoFTimer;

    public int XP { get {return currentXP; } }
    public int currentXP;
    public int maxXP = 100;


    public Script_Health_Bar healthBar;
    public Script_Sonic_Bar sonicBar;
    //public Script_GameOver gameoverScreen;
    public GameObject gameoverPanel, gameoverImg, pauseMenu, healthTokenPop, speedTokenPop, rofTokenPop,
    invincibleTokenPop, sonicTokenPop;
    //Script_GameUI gameUI;
    public Script_shopController shopBackground;

    //set up controller
    void OnEnable() {
        leftStick.Enable();
        rightStick.Enable();
        startButton.Enable();
        rightBumper.Enable();
    }
    void OnDisable() {
        leftStick.Disable();
        rightStick.Disable();
        startButton.Disable();
        rightBumper.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bullets = bullets.GetComponent<ParticleSystem>();

        //gameUI = InGameUI.GetComponent<Script_GameUI>();

        currentHearts = maxHearts;
        healthBar.SetMaxHealth(maxHearts);

        currentXP = 0;
        sonicBar.SetXP(currentXP);

        speed = 3;

        arc = 50;

        rateOverTime = 6;

        //gameOverText.text = "";
        // hearts = 4;
        // SetHeartsText();
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        if (isSpeeding)
        {
            speedTimer -= Time.deltaTime;
            
            if (speedTimer < 0)
            {
                speed = speed - 3;
                
                isSpeeding = false;
            }
        }

        if(isDoubleRoF)
        {
            doubleRoFTimer -= Time.deltaTime;
            
            if (doubleRoFTimer < 0)
            {
                rateOverTime = rateOverTime - 3;
                
                isDoubleRoF = false;
            }
        }

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (currentXP == maxXP)
        {
            if (rightBumper.triggered) 
            {
                sonicBoom.SetActive(true);

                currentXP = 0;

                sonicBar.SetXP(currentXP);
            }
        }

        else if (currentXP < maxXP)
        {
            if (rightBumper.triggered)
            {
                sonicBoom.SetActive(false);
            }
        }
        

        if (startButton.triggered) 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        ParticleSystem.EmissionModule em = bullets.GetComponent<ParticleSystem>().emission;
        em.rateOverTime = rateOverTime;

        ParticleSystem.ShapeModule sh = bullets.GetComponent<ParticleSystem>().shape;
        sh.arc = arc;
    }

    public void TakeDamage() => healthBar.SetHealth(currentHearts);

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

        currentHearts = Mathf.Clamp(currentHearts + amount, 0, maxHearts);
        //UIHearts.instance.SetValue(currentHearts / (float)maxHearts);
    }

    public void ChangeXP(int xpAmount)
    {

        currentXP = Mathf.Clamp(currentXP + xpAmount, 0, maxXP);
        //sonicBar.SetXP(currentXP);
    }

    public void GainedXP()
    {
        sonicBar.SetXP(currentXP);
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

        if (lookVector != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(lookVector);
        }
        
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

        if (collider.tag == "Speed")
        {
            LeanTween.moveLocal(speedTokenPop, new Vector3(-750f, 130f, 0f), 0.6f).setDelay(0.2f).setEase(LeanTweenType.easeInCirc);
            LeanTween.moveLocal(speedTokenPop, new Vector3(-1160f, 130f, 0f), 0.6f).setDelay(3.2f).setEase(LeanTweenType.easeOutCirc);

            isSpeeding = true;
            
            speedTimer = timeSpeed;
            
            speed = speed + 3;

            Debug.Log("SPEED BOOST");

            Destroy(collider.gameObject);
        }

        if (collider.tag == "DoubleTap")
        {
            LeanTween.moveLocal(rofTokenPop, new Vector3(-730f, 60f, 0f), 0.6f).setDelay(0.2f).setEase(LeanTweenType.easeInCirc);
            LeanTween.moveLocal(rofTokenPop, new Vector3(-1180f, 60f, 0f), 0.6f).setDelay(3.2f).setEase(LeanTweenType.easeOutCirc);

            isDoubleRoF = true;
            
            doubleRoFTimer = timeDoubleRoF;
            
            rateOverTime = rateOverTime + 3;

            Debug.Log("DOUBLE TAP");

            Destroy(collider.gameObject);
        }

        if (collider.tag == "Invincible")
        {
            if (isInvincible)
            return;

            LeanTween.moveLocal(invincibleTokenPop, new Vector3(-750f, -10f, 0f), 0.6f).setDelay(0.2f).setEase(LeanTweenType.easeInCirc);
            LeanTween.moveLocal(invincibleTokenPop, new Vector3(-1160f, -10f, 0f), 0.6f).setDelay(3.2f).setEase(LeanTweenType.easeOutCirc);            

            isInvincible = true;
            
            invincibleTimer = timePowered;

            Debug.Log("INVINCIBLE");

            Destroy(collider.gameObject);
        }

        if (collider.tag == "Ability")
        {
            LeanTween.moveLocal(sonicTokenPop, new Vector3(-670f, -80f, 0f), 0.6f).setDelay(0.2f).setEase(LeanTweenType.easeInCirc);
            LeanTween.moveLocal(sonicTokenPop, new Vector3(-1230f, -80f, 0f), 0.6f).setDelay(3.2f).setEase(LeanTweenType.easeOutCirc);

            currentXP = maxXP;

            sonicBar.SetXP(currentXP);

            Debug.Log("ABILITY REFRESH");

            Destroy(collider.gameObject);
        }

        if (collider.tag == "Heal")
        {
            LeanTween.moveLocal(healthTokenPop, new Vector3(-750f, 200f, 0f), 0.6f).setDelay(0.2f).setEase(LeanTweenType.easeInCirc);
            LeanTween.moveLocal(healthTokenPop, new Vector3(-1160f, 200f, 0f), 0.6f).setDelay(3.2f).setEase(LeanTweenType.easeOutCirc);

            currentHearts = maxHearts;

            healthBar.SetMaxHealth(maxHearts);

            Debug.Log("MAX HEARTS");

            Destroy(collider.gameObject);
        }
    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);
        LeanTween.alpha(gameoverPanel.GetComponent<RectTransform>(), 1f, 0.3f).setDelay(0.5f);
        LeanTween.alpha(gameoverImg.GetComponent<RectTransform>(), 1f, 0.8f).setDelay(0.8f);
    }

    public void ChangeHealthBuff()
    {
        maxHearts = maxHearts + 1;
        currentHearts = maxHearts;
        healthBar.SetMaxHealth(maxHearts);
    }

    public void ChangeSpeedBuff() => speed = speed + 1;

    public void ChangeROF() => rateOverTime = rateOverTime + 2;

    public void ChangeArc() => arc = arc - 2;

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
