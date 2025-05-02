using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : BaseWeapon, IReloadAble,IMagazines
{
    private int maxAmmo = 12;
    private int currentAmmo;
    
    protected float fireRate = 0.5f; 
    protected float nextFireTime = 0f;

    protected string weaponName;
    private int AmmoPerFire;

    private int Magazines = 3;

    void Start()
    {
        weaponName = "Pistol";
        currentAmmo = maxAmmo;
        AmmoPerFire = 1;
    }
    

    public override void Fire()
    {
        if (!isEquipped) return;
        base.Fire();
        if(currentAmmo <= 0)
        {
            Debug.Log($"{weaponName}: Out of ammo!");
            ReloadAmmo();
        }
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
