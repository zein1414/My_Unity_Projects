using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour
{
    [SerializeField] private int maxAmmo;
    [SerializeField] private float reloadTime;
    [SerializeField] private int clipSize;

    private int ammo;
    private int shotsFiredInClip;
    private bool isreloading;

    public int RoundsRemainingInClip
    {
        get
        {
            return clipSize - shotsFiredInClip;
        }
    }

    public bool IsReloading
    {
        get
        {
            return isreloading;
        }
    }

    public void Reload()
    {
        if (isreloading) return;

        isreloading = true;
        GameManager.Instance.Timer.Add(ExecuteReloading,reloadTime);
    }

    private void ExecuteReloading()
    {
        isreloading = false;
        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;
        if (ammo < 0)
        {
            ammo = 0;
            shotsFiredInClip += -ammo;
        }
    }

    public void TakeFromClip(int amount)
    {
        shotsFiredInClip += amount;
    }
    
}
