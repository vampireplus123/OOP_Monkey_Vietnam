using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IWeapons
{
    protected string weaponName;
    protected int AmmoPerFire;
    protected int maxAmmo;
    protected int currentAmmo;
    protected float fireRate = 0.5f; 
    protected float nextFireTime = 0f;

    protected bool isEquipped;
    public bool IsEquipped
    {
        get { return isEquipped; }
        set { isEquipped = value; }
    }



    public virtual  void EquipWeapon()
    {
        isEquipped = true;
        Debug.Log($"{weaponName} equipped.");
    }
    public virtual void UnequipWeapon()
    {
        isEquipped = false;
        Debug.Log($"{weaponName} unequipped.");
    }
    public virtual void Fire()
    {
        // if (!isEquipped) return;
        // if (Time.time < nextFireTime) return;
        // nextFireTime = Time.time + fireRate;
        // currentAmmo -= AmmoPerFire;
        if (Time.time - nextFireTime < fireRate)
        {
            Debug.Log($"{weaponName}: Wait for fire rate cooldown.");
            return;
        }
        nextFireTime = Time.time + fireRate;
        currentAmmo-= AmmoPerFire;
        Debug.Log($"{weaponName}: Fired. Ammo left: {currentAmmo}");
    }

}
