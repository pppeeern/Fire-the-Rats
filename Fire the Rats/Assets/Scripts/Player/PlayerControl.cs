using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int PlayerIndex;
    public float moveSpeed = 10;

    public Rigidbody2D rb;

    public Vector2 movement;

    private GrabItem grabItem;
    public bool canMove = true;
    public GameObject indicator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grabItem = gameObject.GetComponent<GrabItem>();
        grabItem.Direction = new Vector2(0, -1);
    }

    private void Update()
    {
        if (PlayerIndex == 1){
            movement.x = UnityEngine.Input.GetAxisRaw("P1_H");
            movement.y = UnityEngine.Input.GetAxisRaw("P1_V");
            movement.Normalize();
        }
        else if (PlayerIndex == 2){
            movement.x = UnityEngine.Input.GetAxisRaw("P2_H");
            movement.y = UnityEngine.Input.GetAxisRaw("P2_V");
            movement.Normalize();
        }
        else
        {
            movement.x = UnityEngine.Input.GetAxisRaw("Horizontal");
            movement.y = UnityEngine.Input.GetAxisRaw("Vertical");
            movement.Normalize();
        }
        if (movement.sqrMagnitude > .1f)
        {
            grabItem.Direction = movement.normalized;
        }
        ThrowIndicatior();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else{rb.velocity = Vector2.zero;}
    }

    void ThrowIndicatior()
    {
        Vector3 aim = new(movement.x, movement.y, 0.0f);
        if (aim.magnitude > 0.0f)
        {
            aim.Normalize();
            movement.Normalize();
            if (aim.x == 0){aim.y += 0.5f;}
            indicator.transform.localPosition = aim*1.2f;
            //indicator.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg);
        }
    }
}
