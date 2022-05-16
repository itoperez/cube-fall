using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float move_Speed = 2f;
    public float bound_Y = 6f;  

    public float platformMoveSpeed = 1f;

    public bool speed_Platform_Left, speed_Platform_Right, is_Breakable, is_Spike, is_Platform;

    private Animator anim;

    void Awake() {
        if (is_Breakable) {
            anim = GetComponent<Animator>();
        }
    }

    void Update() {
        Move();
    }

    void Move() {
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= bound_Y) {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate() {
        Invoke("DeactivateGameObject", 0.5f);
    }

    void DeactivateGameObject() {
        SoundManager.instance.IceBreakSound();   
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Player") {
            if(is_Spike) {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }        
    }

    void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag == "Player") {
            SoundManager.instance.LandSound();
            if (is_Breakable) {
                //SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if(is_Platform) {
                //SoundManager.instance.LandSound();
            }
        }
    }

    void OnCollisionStay2D(Collision2D target) {
        if(target.gameObject.tag == "Player") {
            if(speed_Platform_Left) {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-platformMoveSpeed);
            }
            if(speed_Platform_Right) {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(platformMoveSpeed);
            }
        }
    }

}
