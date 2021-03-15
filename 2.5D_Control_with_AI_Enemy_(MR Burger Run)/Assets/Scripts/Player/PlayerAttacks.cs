using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject boattel;
    public Transform attackpoint;
    public Transform attackpoint2;
    public float bottelSpeed = 600f;
    private GameObject bottel;
    public void AttackStart()
    {
       bottel=Instantiate(boattel, attackpoint.position, attackpoint.rotation);
       bottel.transform.parent = attackpoint;
    }

    public void AttackEnd()
    {
        if (bottel)
        {
            bottel.transform.parent = null;
            bottel.GetComponent<Rigidbody>().AddForce(attackpoint2.forward * bottelSpeed);
        }
    }
    
}
