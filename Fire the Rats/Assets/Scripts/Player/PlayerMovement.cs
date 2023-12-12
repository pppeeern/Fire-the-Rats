using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private PlayerInput playerInput;
    [SerializeField]
    //private int playerIndex;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        //var index = playerInput.playerIndex;
        //Debug.Log(GetPlayerIndex());
        rb = GetComponent<Rigidbody2D>();
    }

    //private Vector2 Diretion;
    void Update()
    {
        /*float X = playerInput.actions["Move"].ReadValue<Vector2>().x;
        float Y = playerInput.actions["Move"].ReadValue<Vector2>().y;

        Diretion = new Vector2(X,Y);*/
    }

    /*public int GetPlayerIndex()
    {
        return playerIndex;
    }*/

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(Diretion.x * Speed, Diretion.y * Speed);
        rb.velocity = movementInput*Speed;
    }

    public void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
