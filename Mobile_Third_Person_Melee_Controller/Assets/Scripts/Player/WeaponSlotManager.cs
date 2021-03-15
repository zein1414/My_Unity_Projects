﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
   private WeaponHolderSlot leftHandSlot;
   private WeaponHolderSlot rightHandSlot;

   private void Awake()
   {
      WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
      foreach (WeaponHolderSlot weaponHolderSlot in weaponHolderSlots)
      {
         if (weaponHolderSlot.isLeftHandSlot)
         {
            leftHandSlot = weaponHolderSlot;
         }
         else
         {
            rightHandSlot = weaponHolderSlot;
         }
      }
   }

   public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
   {
      if (isLeft)
      {
        // leftHandSlot.LoadWeaponModel(weaponItem);
      }
      else
      {
         rightHandSlot.LoadWeaponModel(weaponItem);
      }
   }
}
