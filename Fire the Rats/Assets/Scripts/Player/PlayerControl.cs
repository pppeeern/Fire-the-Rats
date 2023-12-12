using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 2;

    private Rigidbody2D rb;


    //Bindings
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(UnityEngine.Input.GetKey(Up))
        {
            rb.velocity = new Vector2(0, moveSpeed);
        }
        else if(UnityEngine.Input.GetKey(Down))
        {
            rb.velocity = new Vector2(0, -moveSpeed);
        }
        else if(UnityEngine.Input.GetKey(Left))
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        else if(UnityEngine.Input.GetKey(Right))
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else 
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
