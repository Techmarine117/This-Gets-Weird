using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput PlayerInput;

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


    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();
        controller = gameObject.GetComponent<CharacterController>();
        canSprint = true;


    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }


    public void Jump(InputAction.CallbackContext context)   
    {
        if (context.performed)
        {
           

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpdist;
            }

        }
    }

    
    public void Move(InputAction.CallbackContext context)
    {
      Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 20f;
        rb.AddForce( new Vector3(inputVector.x,0, inputVector.y) * speed, ForceMode.Force);
    }

}
