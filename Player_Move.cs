using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed_Move;
    public float speed_Run;
    public float speed_Current;
    public float jump;
    public float gravity = 1;
    float x_Move;
    float z_Move;
    public CharacterController Player;
    public Vector3 move_Direction;

    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }


    void Move()
    {
        x_Move = Input.GetAxis("Horizontal");
        z_Move = Input.GetAxis("Vertical");

        if (Player.isGrounded)
        {
            move_Direction = new Vector3(x_Move, 0f, z_Move);
            move_Direction = transform.TransformDirection(move_Direction).normalized;
            if (Input.GetKey(KeyCode.Space))
            {
                move_Direction.y += jump;

            }
        }
        move_Direction.y -= gravity;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed_Current = speed_Run;
        }
        else
        {
            speed_Current = speed_Move;
        }
        Player.Move(move_Direction * speed_Current * Time.deltaTime);

    }   
}
