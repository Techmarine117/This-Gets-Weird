using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpdist;

    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    public bool canSprint;
    

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        canSprint = true;
        
    }

    void Update()
    {
        

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // edited
        if (!isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canSprint)
        {
            
            speed = 15f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
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
       

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpdist;
            
        }
        
            

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}