using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls playerControls;
    Vector2 CurrentMovementInput;
    Vector3 CurrentMovement , RunMovement;
    bool IsMovementPressed , IsRunPressed;
    CharacterController characterController;
    float RotationFactor = 15.0f;
    float RunSpeed = 6.0f;
    float Speed = 3.0f;

    private void Awake()
    {
        playerControls = new PlayerControls();
        characterController = GetComponent<CharacterController>();

        playerControls.Movement.Move.started += OnMovementInput;
        playerControls.Movement.Move.canceled += OnMovementInput;
        playerControls.Movement.Move.performed += OnMovementInput;
        playerControls.Movement.Run.started += OnRun;
        playerControls.Movement.Run.canceled += OnRun;

    }

    private void Update()
    {
        HandleRotation();
        

        if (IsRunPressed)
        {
            characterController.Move(RunMovement * Time.deltaTime);
        }
        else
        {
            characterController.Move(CurrentMovement * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        playerControls.Movement.Enable();
    }

    private void OnDisable()
    {
        playerControls.Movement.Enable();
    }


   private void OnMovementInput(InputAction.CallbackContext context)
    {

        CurrentMovementInput = context.ReadValue<Vector2>();
            CurrentMovement.x = CurrentMovementInput.x * Speed;
            CurrentMovement.z = CurrentMovementInput.y * Speed;
            RunMovement.x = CurrentMovementInput.x * RunSpeed;
            RunMovement.z = CurrentMovementInput.y * RunSpeed;
            IsMovementPressed = CurrentMovementInput.x != 0 || CurrentMovementInput.y != 0;
    }

  private void OnRun(InputAction.CallbackContext context)
    {
        IsRunPressed = context.ReadValueAsButton();
    }

  private void HandleRotation()
    {
        Vector3 PosTolookAt;      

        PosTolookAt.x = CurrentMovement.x;
        PosTolookAt.y = 0.0f;
        PosTolookAt.z = CurrentMovement.z;

        Quaternion CurrentRotation = transform.rotation;

        if (IsMovementPressed)
        {
           Quaternion TargetRotation = Quaternion.LookRotation(PosTolookAt);
           transform.rotation =  Quaternion.Slerp(CurrentRotation, TargetRotation, RotationFactor * Time.captureDeltaTime);
        }
    }

    void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            float GroundedGravity = -.05f;
            CurrentMovement.y = 
        }
    }
}