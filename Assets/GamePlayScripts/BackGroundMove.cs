using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        rb.velocity = new Vector2(speed*-1, 0);    
        if(transform.position.x <= -37.2) transform.position = new Vector2(0,0);     
    }
}
