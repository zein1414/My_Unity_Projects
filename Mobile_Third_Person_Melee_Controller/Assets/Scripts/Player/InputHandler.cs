﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    public bool b_Input;
    public bool rb_Input;
    public bool rt_Input;
    
    
    public bool rollFlag;
    public bool sprintFlag;
    public float rollInputTimer;
 
    
    private PlayerControls inputActions;
    private PlayerAttacker _playerAttacker;
    private PlayerInventory _playerInventory;

    private Vector2 movementInput;
    private Vector2 cameraInput;

    private void Awake()
    {
        _playerAttacker = GetComponent<PlayerAttacker>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions=new PlayerControls();
            inputActions.PlayerMovement.Movement.performed +=
                inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed +=
                i => cameraInput = i.ReadValue<Vector2>();
        }
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TackInput(float delta)
    {
        MoveInput(delta);
        HandelRollInput(delta);
        HandleAttackInput(delta);
    }

    private void MoveInput(float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    private void HandelRollInput(float delta)
    {
        b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        if (b_Input)
        {
            rollInputTimer += delta;
            sprintFlag = true;
        }
        else
        {
            if (rollInputTimer > 0 && rollInputTimer < 0.5f)
            {
                sprintFlag = false;
                rollFlag = true;
            }
         
            rollInputTimer = 0;
        }
        
    }

    private void HandleAttackInput(float delta)
    {
        inputActions.PlayerActions.RB.performed += i => rb_Input = true;
        inputActions.PlayerActions.RT.performed += input => rt_Input = true;

        if (rb_Input)
        {
            _playerAttacker.HandleLightAttack(_playerInventory.rightWeaponItem);
        }

        if (rt_Input)
        {
            _playerAttacker.HandleHeavyAttack(_playerInventory.rightWeaponItem);
        }
        
    }
}
