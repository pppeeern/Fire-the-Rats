using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int PlayerIndex;
    public float PlayerSpeed;
    private Rigidbody2D rb;
    public Vector2 movement;
    public bool CanMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(PlayerIndex == 1)
        {
            movement.x = Input.GetAxisRaw("1H");
            movement.y = Input.GetAxisRaw("1V");
            movement.Normalize();
        }
        else if(PlayerIndex == 2)
        {
            movement.x = Input.GetAxisRaw("2H");
            movement.y = Input.GetAxisRaw("2V");
            movement.Normalize();
        }
    }
    private void FixedUpdate()
    {
        if (CanMove)
        {
            rb.MovePosition(rb.position + movement * PlayerSpeed * Time.fixedDeltaTime);
        }
        else{rb.velocity = Vector2.zero;}
    }
}
