using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] private float rateOfFire;
    [SerializeField] private Projectile projectiles;
    
    [HideInInspector]
    public Transform muzzle;

    private WeaponReloader _reloader;
    
    private float nextFireAllowed;

    public bool canFire=false;
    // Start is called before the first frame update
    void Awake()
    {
        muzzle = transform.Find("Muzzle");

        _reloader = GetComponent<WeaponReloader>();
    }

    public virtual void Fire()
    {
        canFire = false;
        if(Time.time<nextFireAllowed)return;

        if (_reloader != null)
        {
            if (_reloader.IsReloading)
            {
                return;
            }else if (_reloader.RoundsRemainingInClip == 0)
            {
                return;
            }
            _reloader.TakeFromClip(1);
        }
        nextFireAllowed = Time.time + rateOfFire;

        Instantiate(projectiles, muzzle.position, muzzle.rotation);
        
        canFire = true;
       
    }

    public void Reload()
    {
        if(_reloader==null)return;
        _reloader.Reload();
    }
}
