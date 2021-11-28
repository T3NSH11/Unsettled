using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float SprintSpeed;
    float MoveSpeed = 5;
    public float gravity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpdist;
    public GameObject flash;

    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeed = SprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeed = speed;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            controller.height = 0.5f;
            speed = 5f;
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            controller.height = 2.0f;
            speed = 12f;
        }

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpdist;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(flash.GetComponent<Light>().enabled == false)
            {
                flash.GetComponent<Light>().enabled = true;
            }
            else
            {
                flash.GetComponent<Light>().enabled = false;
            }
            
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * MoveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}

