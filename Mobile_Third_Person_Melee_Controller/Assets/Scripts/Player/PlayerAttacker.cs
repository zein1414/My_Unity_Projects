using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    private AnimatorHandler _animatorHandler;

    private void Awake()
    {
        _animatorHandler = GetComponent<AnimatorHandler>();
    }

    public void HandleLightAttack(WeaponItem weaponItem)
    {
        _animatorHandler.PlayerTargetAnimation(weaponItem.OH_Light_Attack_1,true);
    }
    
    public void HandleHeavyAttack(WeaponItem weaponItem)
    {
        _animatorHandler.PlayerTargetAnimation(weaponItem.OH_Heavy_Attack_1,true);
    }
}
