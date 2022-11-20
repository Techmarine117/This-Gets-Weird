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
    Animator Anim;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        canSprint = true;
        Anim= GetComponent<Animator>();
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
            Anim.SetBool("IsRunning", true);
            speed = 15f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
        }
        else
            Anim.SetBool("IsRunning", false);

        if (Input.GetKeyDown(KeyCode.C))
        {
            controller.height = 0.5f;
            Anim.SetBool("IsCrouched", true);

            speed = 5f;
        }
        else
            Anim.SetBool("IsCrouched", false);

        if (Input.GetKeyUp(KeyCode.C))
        {
            controller.height = 2.0f;
            speed = 12f;
        }
       

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpdist;
             Anim.SetBool("IsJumping", true);
        }
        else
            Anim.SetBool("IsJumping", false);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}