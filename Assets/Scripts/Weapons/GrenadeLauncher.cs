using UnityEngine;

public class GrenadeLauncher : BaseWeapon, IReloadAble
{
    private int maxAmmo = 2;
    private int AmmoPerFire = 1;
    private int currentAmmo;
    private int TotalMag = 0;
    private string weaponName;

    void Awake()
    {
        weaponName = "Grenade Launcher";
        currentAmmo = maxAmmo;
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

        if (TotalMag <= 0)
        {
            Debug.Log($"{weaponName}: Out of ammo!");
            ReloadAmmo();
            return;
        }

        nextFireTime = Time.time + fireRate;
        currentAmmo -= AmmoPerFire;
        Debug.Log($"{weaponName}: Fired. Ammo left: {TotalMag}");
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
