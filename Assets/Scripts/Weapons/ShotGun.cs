using UnityEngine;

public class ShotGun : BaseWeapon, IReloadAble
{
    private int maxAmmo = 8;
    private int currentAmmo;
 

    void Start()
    {
        currentAmmo = maxAmmo;
        weaponName = "Shotgun";
        AmmoPerFire = 2;
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
            return;
        }

        nextFireTime = Time.time;
        currentAmmo -= 2;
        Debug.Log($"{weaponName}: Fired. Ammo left: {currentAmmo}");
    }

    public virtual void ReloadAmmo()
    {
        currentAmmo = maxAmmo;
        Debug.Log($"{weaponName}: Reloaded.");
    }
}
