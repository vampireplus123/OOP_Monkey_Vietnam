using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : BaseWeapon, IReloadAble, IMagazines
{
    public bool isOutOfMagazines { get; set; }

    private int Magazines;

    void Start()
    {
        weaponName = "Pistol";
        maxAmmo = 12;
        currentAmmo = maxAmmo;
        AmmoPerFire = 1;
        Magazines = 3;
    }

    public override void Fire()
    {
        if (!isEquipped) return;

        if (currentAmmo <= 0)
        {
            Debug.Log($"{weaponName}: Out of ammo!");
            ReloadAmmo();
            return;
        }

        base.Fire();
    }

    public virtual void ReloadAmmo()
    {
        ReloadBulletMag();

        if (isOutOfMagazines)
        {
            Debug.Log($"{weaponName}: Can't reload, out of magazines!");
            return;
        }

        currentAmmo = maxAmmo;
        Debug.Log($"{weaponName}: Reloaded.");
    }

    public void ReloadBulletMag()
    {
        if (Magazines <= 0)
        {
            OutOfMagazines();
            return;
        }

        Magazines--;
        Debug.Log($"{weaponName}: Magazines left: {Magazines}");
    }

    public void OutOfMagazines()
    {
        Debug.Log($"{weaponName}: No more magazines left!");
        isOutOfMagazines = true;
    }
}