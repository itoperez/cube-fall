using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed = 3f;
    private const float jumpAmount = 8f;
    

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
        if (Input.GetKeyDown(KeyCode.Space)) {
            myBody.velocity = Vector2.up * jumpAmount;
        }
    }

    public void PlatformMove(float x) {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
