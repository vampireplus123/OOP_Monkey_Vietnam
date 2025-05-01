using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour, IWeapons
{
    protected string weaponName;
    protected int AmmoPerFire;

    protected float fireRate = 0.5f; 
    protected float nextFireTime = 0f;

    protected bool isEquipped = false;
    public bool IsEquipped => isEquipped;


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
        if (!isEquipped) return;
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireRate;
        Debug.Log($"{weaponName} fired.");
    }
    public virtual void Aim()
    {
        if (!isEquipped)
        {
            Debug.Log($"{weaponName} is not equipped.");
            return;
        }
        Debug.Log($"{weaponName} aimed.");
    }
}
