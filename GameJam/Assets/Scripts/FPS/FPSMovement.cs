using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this player move class will allow the gameobject to move based on charactercontroller

public class FPSMovement : MonoBehaviour

{

    //Vars
    public CharacterController m_charController;
    public float m_movementSpeed = 12f;
    public float m_runSpeed = 1.5f;

    public float m_gravity = -9.81f;
    public float m_jumpHeight = 3f;
    private Vector3 m_velocity;


    private bool m_isGrounded;


    public KeyCode m_forward;
    public KeyCode m_back;
    public KeyCode m_left;
    public KeyCode m_right;
    public KeyCode m_sprint;
    public KeyCode m_jump;

    private float m_finalSpeed = 0;

    void Awake()
    {
        m_finalSpeed = m_movementSpeed;
    }

    void Update()
    {
        m_isGrounded = m_charController.isGrounded;
        MoveInputCheck(); // Check movement input

    }

    //check if a button is pressed
    void MoveInputCheck()
    {
        float x = Input.GetAxis("Horizontal"); // get the x value for the GameObject vector
        float z = Input.GetAxis("Vertical"); // get the z value for the GameObject vector

        Vector3 move = Vector3.zero;

        if (Input.GetKey(m_forward) || Input.GetKey(m_back) || Input.GetKey(m_left) || Input.GetKey(m_right)) // check input for the keys defined in VARS
        {
            move = transform.right * x + transform.forward * z; // calculate the move vector (direction)

        }

        MovePlayer(move);
        RunCheck(); // Chaecks the input for run
        JumpCheck(); // Checks if we can jump
    }

    //MovePlayer()
    void MovePlayer(Vector3 move)
    {
        m_charController.Move(move * m_finalSpeed * Time.deltaTime); // moves the GameObject using the character Controller

        // Gravity due to player
        m_velocity.y += m_gravity * Time.deltaTime; // Gravity effects the jump
        m_charController.Move(m_velocity * Time.deltaTime); //Actually move the player up
    }

    // Player Run 
    void RunCheck()
    {
        if (Input.GetKeyDown(m_sprint)) // if key is down - m_sprint key
        {
            m_finalSpeed = m_movementSpeed * m_runSpeed; //Multiply movement speed by runSpeed and store it in final speed
        }
        else if (Input.GetKeyUp(m_sprint)) // if key is up - m_sprint key
        {
            m_finalSpeed = m_movementSpeed;
        }

    }



    //Jump check
    void JumpCheck()
    {
        if (Input.GetKeyDown(m_jump))
        {
            if (m_isGrounded == true)
            {
                m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
            }
        }
    }

}
