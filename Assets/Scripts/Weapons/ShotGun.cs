using UnityEngine;

public class ShotGun : BaseWeapon, IReloadAble, IMagazines
{
    private int Magazines;

    public bool isOutOfMagazines { get; set; }

    void Awake()
    {
        weaponName = "ShotGun";
        maxAmmo = 2;
        currentAmmo = maxAmmo;
        AmmoPerFire = 2;
        fireRate = 1.5f;
        Magazines = 3;
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
        ReloadBulletMag(); // Kiểm tra và trừ băng đạn ở đây

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
