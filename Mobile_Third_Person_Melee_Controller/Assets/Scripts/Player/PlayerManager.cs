using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputHandler _inputHandler;
    public bool isInteracting;
    private Animator anim;
    private CameraHandler _cameraHandler;
    private PlayerLocomotion _playerLocomotion;
    
    [Header("Player Flags")]
    public bool isSprinting;
    public bool isInAir;
    public bool isGrounded;
    
    void Start()
    {
        _inputHandler = GetComponent<InputHandler>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
        anim = GetComponent<Animator>();
        _cameraHandler=CameraHandler.singleton;
    }

    void Update()
    {
        float delta = Time.deltaTime;
        isInteracting = anim.GetBool("IsInteracting");
        _inputHandler.TackInput(delta);
        _playerLocomotion.HandleMovement(delta);
        _playerLocomotion.HandleRollingAndSprinting(delta);
        _playerLocomotion.HandleFalling(delta,_playerLocomotion.moveDirection);
    }
    
    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;

        if (_cameraHandler != null)
        {
            _cameraHandler.FollowTarget(delta);
            _cameraHandler.HandleCameraRotation(delta,_inputHandler.mouseX,_inputHandler.mouseY);
          
        }
   
    }


    private void LateUpdate()
    {
        _inputHandler.rollFlag = false;
        _inputHandler.sprintFlag = false;
        _inputHandler.rb_Input = false;
        _inputHandler.rt_Input = false;

        if (isInAir)
        {
            _playerLocomotion.inAirTimer = _playerLocomotion.inAirTimer + Time.deltaTime;
        }
    }
}
