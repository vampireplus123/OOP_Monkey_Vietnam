using UnityEngine;

public class ShotGun : BaseWeapon, IReloadAble,IMagazines
{
    private int maxAmmo = 8;
    private int currentAmmo;
    private int Magazines = 2;

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
        Magazines--;
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
