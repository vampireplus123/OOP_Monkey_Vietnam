using UnityEngine;

public class ShotGun : BaseWeapon, IReloadAble,IMagazines
{
    private int Magazines;
  
    void Awake()
    {
        weaponName = "ShotGun";
        maxAmmo = 2;
        currentAmmo = maxAmmo;
        AmmoPerFire = 2;
        fireRate = 1.5f;
        Magazines = 3;
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
        Magazines--;
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
