using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float SprintSpeed;
    public float MoveSpeed = 3;
    public float gravity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpdist;
    public GameObject flash;
    public GameObject HUD;
    public GameObject PauseMenuOBJ;
    public LayerMask groundMask;
    Vector3 velocity;
    public bool isGrounded;


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

        if (Input.GetKeyDown(KeyCode.LeftShift) && gameObject.GetComponent<Stats>().stamina > 0)
        {
            MoveSpeed = SprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || gameObject.GetComponent<Stats>().stamina <  0)
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

        if(Input.GetKeyDown(KeyCode.F))
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuOBJ.SetActive(true);
            HUD.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * MoveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}

