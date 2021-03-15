using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    private Vector3 direction;
    private bool canChase = true;

    public int health=100;
    public float chaseRange = 5;
    public float speed = 8;
    public float attackingRange=0;
    public Transform grounded;
    public Animator animator;
    public CharacterController controller;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.GetComponent<PlayerController>().health<=0)
        {
            animator.SetBool("IsAttacking",false);
            animator.SetTrigger("Idle");
            currentState ="IdleState";
            canChase = false;
            return;
        }
        float distance = Vector3.Distance(transform.position, target.position);
        bool isGrounded = Physics.CheckSphere(grounded.position,0.15f,groundLayer);
        CanMove();
        if (distance>chaseRange&&!canChase)
        {
            animator.SetTrigger("Idle");
            currentState ="IdleState";
        }
        if (currentState == "IdleState")
        {
            if (distance < chaseRange&&canChase)
            {
                currentState ="ChaseState";
            }
        }else if(currentState =="ChaseState")
        {
            animator.SetTrigger("Chase");
            animator.SetBool("IsAttacking",false);
            if (distance <attackingRange)
            {
                currentState = "AttackState";
            }
         
            if (target.position.x > transform.position.x)
            {
              //  transform.Translate(transform.right*Time.deltaTime);
              direction.x = 1 * speed;
                controller.Move(direction * Time.deltaTime);
                transform.rotation=Quaternion.Euler(0,0,0);
            }
            else
            {
                //transform.Translate(-transform.right*speed*Time.deltaTime);
                direction.x = -1 * speed;
                controller.Move(direction * Time.deltaTime);
                transform.rotation=Quaternion.Euler(0,180,0);
             
            }
            Jump(isGrounded);
        }else if (currentState=="AttackState")
        {
            animator.SetBool("IsAttacking",true);
            if (distance >attackingRange)
            {
                currentState ="ChaseState";
            }
        }
    }
    private void Jump(bool isGrounded)
    {
       
        if (isGrounded)
        {
            direction.y = -1;
            Ray rayLeft = new Ray(grounded.position,grounded.right);
             
            RaycastHit hit;
            if ( Physics.Raycast(rayLeft, out hit, 1) && hit.transform.CompareTag("Obstaclejump") )
            {
                direction.y = 5;
                animator.SetBool("CanJump",true);
            }
           
        } else
        {
            direction.y += -20 * Time.deltaTime;
            animator.SetBool("CanJump",false);
        }
    
     
    }

    private void CanMove()
    {
        Ray rayLeft = new Ray(grounded.position,-grounded.right);
        Ray rayLeft1 = new Ray(grounded.position,grounded.right);
             
        RaycastHit hit;
        if ( Physics.Raycast(rayLeft, out hit, 3) && hit.transform.CompareTag("Player") )
        {
            canChase = true;
            Debug.DrawLine(rayLeft.origin,hit.point,Color.red);
        }
        else if(Physics.Raycast(rayLeft1, out hit, 1) && hit.transform.CompareTag("Obstacle"))
        {
            canChase = false;
            Debug.DrawLine(rayLeft.origin,hit.point,Color.red);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        currentState ="ChaseState";
        canChase = true;
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
        Destroy(gameObject,5f);
    }

 
}
