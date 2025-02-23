using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public CharacterController Player;
    public float speed;

    public float gravity = 9.81f;
    private float verticalVelocity;
    public float jumpForce = 5f;

    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Player.isGrounded)
        {
            if (verticalVelocity < 0) 
            {
                verticalVelocity = -0.5f; 
            }

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(horizontalMove, 0, verticalMove) * speed;
        move.y = verticalVelocity; 
        Player.Move(move * Time.deltaTime);
    }
}

