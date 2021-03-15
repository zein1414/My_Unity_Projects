using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   private WeaponSlotManager _weaponSlotManager;

   public WeaponItem rightWeaponItem;
   public WeaponItem leftWeaponItem;

   private void Awake()
   {
      _weaponSlotManager = GetComponent<WeaponSlotManager>();
   }

   private void Start()
   {
      _weaponSlotManager.LoadWeaponOnSlot(rightWeaponItem,false);
      _weaponSlotManager.LoadWeaponOnSlot(leftWeaponItem,true);
   }
}
