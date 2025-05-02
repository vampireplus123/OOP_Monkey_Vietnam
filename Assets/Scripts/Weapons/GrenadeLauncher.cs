using UnityEngine;

public class GrenadeLauncher : BaseWeapon, IReloadAble, IMagazines
{
    private int TotalMag = 6;
    public bool isOutOfMagazines { get; set; }

    void Awake()
    {
        weaponName = "Grenade Launcher";
        maxAmmo = 1;
        fireRate = 2f;
        currentAmmo = maxAmmo;
        AmmoPerFire = 1;
        isOutOfMagazines = false;
    }

    public override void Fire()
    {
        if (!isEquipped) return;

        if (isOutOfMagazines)
        {
            Debug.Log($"{weaponName}: Out of magazines! Can't fire.");
            return;
        }

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
        ReloadBulletMag(); // Kiểm tra và trừ TotalMag ở đây

        if (isOutOfMagazines)
        {
            Debug.Log($"{weaponName}: Cannot reload, no magazines left!");
            return;
        }

        currentAmmo = maxAmmo;
        Debug.Log($"{weaponName}: Reloaded.");
    }

    public void ReloadBulletMag()
    {
        if (TotalMag <= 0)
        {
            OutOfMagazines();
            return;
        }

        TotalMag--;
        Debug.Log($"{weaponName}: Magazines left: {TotalMag}");
    }

    public void OutOfMagazines()
    {
        Debug.Log($"{weaponName}: No more magazines left!");
        isOutOfMagazines = true;
    }
}
