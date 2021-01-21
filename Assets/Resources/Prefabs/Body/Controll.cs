using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    public float jumpForce;
    public AudioClip jumpSound;
    public LevelModuleMoving level;

    private bool onGround;
    private Rigidbody2D rb;

    private AudioSource audio;


    void Start(){
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision){
        onGround = true;
    }

    void Update()
    {
        if(onGround){
            if((Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)) && !level.isGameOver) 
            {
                audio.clip = jumpSound;
                audio.Play();
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                onGround = false;
            }
        }
    }
}
