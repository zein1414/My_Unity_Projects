using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeTolive;
    [SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timeTolive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var destructable = other.transform.GetComponent<Destructable>();
        if(destructable==null) return;
        
        destructable.TakeDamge(damage);
    }
}
