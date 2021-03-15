using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle :ShooterScript
{
    public override void Fire()
    {
        base.Fire();
        if (canFire)
        {
            
        }
    }

    private void Update()
    {
        if (GameManager.Instance.InputController.Reload)
        { 
            Reload();
        }
    }
}
