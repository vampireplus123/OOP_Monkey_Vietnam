using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : BaseWeapon, IReloadAble,IMagazines
{
    private int maxAmmo = 12;
    private int currentAmmo;

    private int Magazines = 3;

    void Start()
    {
        currentAmmo = maxAmmo;
        weaponName = "Pistol";
        AmmoPerFire = 1;
    }
    

    public override void Fire()
    {
        if (!isEquipped) return;

        if (Time.time - nextFireTime < fireRate)
        {
            Debug.Log($"{weaponName}: Wait for fire rate cooldown.");
            return;
        }

        if (currentAmmo <= 0)
        {
            Debug.Log($"{weaponName}: Out of ammo!");
            ReloadAmmo();
        }

        nextFireTime = Time.time;
        currentAmmo-= AmmoPerFire;
        Debug.Log($"{weaponName}: Fired. Ammo left: {currentAmmo}");
    }

    public virtual void ReloadAmmo()
    {
        currentAmmo = maxAmmo;
        MagRemain();
        Debug.Log($"{weaponName}: Reloaded.");
    }
    public void MagRemain()
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
