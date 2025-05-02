using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : BaseWeapon, IReloadAble,IMagazines
{
    // private int maxAmmo = 12;
    // private int currentAmmo;
    
    // protected float fireRate = 0.5f; 
    // protected float nextFireTime = 0f;

    // protected string weaponName;

    private int Magazines;

    void Awake()
    {
        weaponName = "Pistol";
        currentAmmo = maxAmmo;
        AmmoPerFire = 1;
        maxAmmo = 12;
        currentAmmo = maxAmmo;
        Magazines = 3;
        AmmoPerFire = 1;
    }
    

    public override void Fire()
    {
        if (!isEquipped) return;

        if (currentAmmo <= 0)
        {
            Debug.Log($"{weaponName}: Out of ammo!");
            ReloadAmmo();
        }
        base.Fire();
    }

    public virtual void ReloadAmmo()
    {
        currentAmmo += maxAmmo;
        Debug.Log($"{weaponName}: Reloaded.");
        ReloadBulletMag();
    }
    public void ReloadBulletMag()
    {
        if(Magazines <=0)
        {
            Debug.Log($"{weaponName}: No more magazines left!");
            return;
        }
        Debug.Log($"{weaponName}: Magazines left: {Magazines}");
        Magazines--;
    }
}
