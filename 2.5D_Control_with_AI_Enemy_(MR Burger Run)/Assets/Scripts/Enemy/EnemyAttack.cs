using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmont=10;
    public void AttackPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().TakeDamage(damageAmont);
    }
}
