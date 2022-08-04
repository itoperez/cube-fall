using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed = 3f;
    private const float jumpAmount = 8f;

    private bool canJump = false;
    

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>(); 
    }

    // FixedUpdate() used for rigid body and Update() for transform like in PlatformScript.cs
    void FixedUpdate()
    {
        Move();
    }

    void Move() {
        // Right arrow key or 'D'
        if(Input.GetAxisRaw("Horizontal") > 0f) {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }
        // Left arrow key or 'A'
        if(Input.GetAxisRaw("Horizontal") < 0f) {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
    }

    void Update() {
        Jump();        
    }

    void Jump() {
        // Spacebar
        if (Input.GetKeyDown(KeyCode.Space) & canJump) {
            myBody.velocity = Vector2.up * jumpAmount;
            canJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {        
        if (target.gameObject.tag == "Jumpable") {
            canJump = true;
        }
    }

    public void PlatformMove(float x) {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
