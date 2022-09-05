using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Controller : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public float slowDownSpeed;
    public float stopSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckInput();
    }

    void CheckInput() {
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
    }
}
