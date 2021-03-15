using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
  
  public Animator anim;
  private InputHandler InputHandler;
  private PlayerLocomotion PlayerLocomotion;
  private PlayerManager _playerManager;
  private int vertical;
  private int horizontal;
  public bool canRotate;

  public void Initialize()
  {
    anim = GetComponent<Animator>();
    InputHandler = GetComponent<InputHandler>();
    PlayerLocomotion = GetComponent<PlayerLocomotion>();
    _playerManager = GetComponent<PlayerManager>();
    vertical = Animator.StringToHash("Vertical");
    horizontal = Animator.StringToHash("Horizontal");
  }

  public void UpdateAnimtorValues(float verticalMovement, float horizontalMovement,bool isSprinting)
  {
    #region Vertical
    float v = 0;
    if (verticalMovement > 0 && verticalMovement < 0.55f)
    {
      v=0.5f;
    }else if (verticalMovement>0.55f)
    {
      v = 1f;
    }else if (verticalMovement<0&& verticalMovement>-0.55f)
    {
      v=-0.5f;
    }else if (verticalMovement<-0.5f)
    {
      v = -1f;
    }
    else
    {
      v = 0;
    }
    #endregion
    
    #region Horizontal
    float h = 0;
    if (horizontalMovement > 0 &&  horizontalMovement< 0.55f)
    {
      h=0.5f;
    }else if (horizontalMovement>0.55f)
    {
      h= 1f;
    }else if (horizontalMovement<0&& horizontalMovement>-0.55f)
    {
      h=-0.5f;
    }else if (horizontalMovement<-0.5f)
    {
      h= -1f;
    }
    else
    {
      h= 0;
    }
    #endregion

    if (isSprinting)
    {
      v = 2f;
      h = horizontalMovement;
    }
    
    anim.SetFloat(vertical,v,0.1f,Time.deltaTime);
    anim.SetFloat(horizontal,h,0.1f,Time.deltaTime);
  }

  public void PlayerTargetAnimation(string targetAnim, bool isInteracting)
  {
    anim.applyRootMotion = isInteracting;
    anim.SetBool("IsInteracting",isInteracting); 
    anim.CrossFade(targetAnim,0.05f);
  }
  
  public void CanRotate()
  {
    canRotate = true;
  }
  
  public void StopRotate()
  {
    canRotate = false;
  }

  private void OnAnimatorMove()
  {
    if(!_playerManager.isInteracting) return;

    float delta = Time.deltaTime;
    PlayerLocomotion.rigidbody.drag = 0;
    Vector3 deltaPosition = anim.deltaPosition;
    deltaPosition.y = 0;
    Vector3 velocity = deltaPosition / delta;
    PlayerLocomotion.rigidbody.velocity = velocity;
  }
}
