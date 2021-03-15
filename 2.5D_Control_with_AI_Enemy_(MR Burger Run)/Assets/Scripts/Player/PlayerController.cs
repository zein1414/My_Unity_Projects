using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public Vector3 direction;

    public float speed = 8;

    public float jumpForce = 5;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool ableToMakeADoubleJump=true;
    public Animator animator;
    public Transform model;
    public int health=100;
    
    private PlayerInput _input;
    
    // Start is called before the first frame update
    void Start()
    {
        _input = GameObject.Find("GameController").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
       // if (dead) return;
       float hInput;
#if UNITY_ANDROID
         hInput = _input.x;
           #else
        hInput = Input.GetAxis("Horizontal");
#endif
        direction.x = hInput * speed;
        animator.SetFloat("Speed",Mathf.Abs(hInput));
        bool isGrounded = Physics.CheckSphere(groundCheck.position,0.15f,groundLayer);
        animator.SetBool("IsGrounded",isGrounded);
        Jump(isGrounded);
        Attack(isGrounded);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Throw Object"))
        {
            return;
        }
        if (hInput != 0)
        {
            Quaternion newRotation=Quaternion.LookRotation(new Vector3(hInput,0,0));
            model.rotation = newRotation;
        }
        controller.Move(direction * Time.deltaTime);
    }

    private void Jump(bool isGrounded)
    {
        //if (dead) return;
        if (isGrounded)
        {
            direction.y = -1;
            ableToMakeADoubleJump = true;
            if (_input.jump)
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
            if (ableToMakeADoubleJump && _input.jump)
            {
                animator.SetTrigger("doublejump");
                direction.y = jumpForce;
                ableToMakeADoubleJump=false;
            }
        }
        _input.jump = false;
    }

    private void Attack(bool isGrounded)
    {  
       // if (dead) return;
        if (isGrounded&&_input.attack)
        {
            animator.SetTrigger("Bottalattack");
        }
        _input.attack = false;
    }
    
    public void TakeDamage(int damage)
    {
      
        health -= damage;
        if (health<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Dead");
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
        controller.enabled = false;
    }
}
