using UnityEngine;

public class GrenadeLauncher : BaseWeapon, IReloadAble
{
    private int TotalMag = 6;
    void Awake()
    {
        weaponName = "Grenade Launcher";
        maxAmmo = 1;
        fireRate = 2f;
        currentAmmo = maxAmmo;
        AmmoPerFire = 1;
    }

    public override void Fire()
    {
        if (!isEquipped) return;
        base.Fire();
        if (currentAmmo <= 0)
        {
            Debug.Log($"{weaponName}: Out of ammo!");
            ReloadAmmo();
        }
    }

    public virtual void ReloadAmmo()
    {
        currentAmmo += maxAmmo;
        Debug.Log($"{weaponName}: Reloaded.");
        TotalMag--;
    }
    public void MagReReloadBulletMagmain()
    {
        if (TotalMag <= 0)
        {
            Debug.Log($"{weaponName}: No more magazines left!");
            return;
        }
        Debug.Log($"{weaponName}: Magazines left: {TotalMag}");
        TotalMag--;
    }
}
