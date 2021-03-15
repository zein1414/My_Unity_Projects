﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable
{
    [SerializeField] private float inSeconds;
    public override void Die()
    {
        base.Die();
        
        GameManager.Instance.Respawner.Despawn(gameObject,inSeconds);
    }

    private void OnEnable()
    {
        Reset();
    }

    public override void TakeDamge(float value)
    {
        base.TakeDamge(value);
    }
}
