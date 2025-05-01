using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
public class WeaponsManager : MonoBehaviour
{
    private List<IWeapons> weapons = new List<IWeapons>();
    private IWeapons currentWeapon;
    private int currentIndex = 0;

    [SerializeField] private List<MonoBehaviour> weaponBehaviours; 

    void Awake()
    {
        foreach (var mono in weaponBehaviours)
        {
            if (mono is IWeapons weapon)
            {
                weapons.Add(weapon);
            }
        }

        EquipWeapon(currentIndex);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) currentWeapon.Fire();

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentWeapon is IReloadAble reloadable)
                reloadable.ReloadAmmo();
            else
                Debug.Log("This weapon can't reload.");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchWeapon(2);

    }

    void SwitchWeapon(int index)
    {
        if (index < 0 || index >= weapons.Count) return;

        currentWeapon.UnequipWeapon();
        currentIndex = index;
        EquipWeapon(index);
    }

    void EquipWeapon(int index)
    {
        currentWeapon = weapons[index];
        currentWeapon.EquipWeapon();
        Debug.Log($"Switched to weapon at index {index}");
    }
}
