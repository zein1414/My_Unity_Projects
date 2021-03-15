using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottel : MonoBehaviour
{
    public GameObject broken;
    public int damageAmont = 10;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy")||other.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(broken,transform.position,transform.rotation);
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(damageAmont);
            }
            Destroy(gameObject);
        }
    
    }
}
