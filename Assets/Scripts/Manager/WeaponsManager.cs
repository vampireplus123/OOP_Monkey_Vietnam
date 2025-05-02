using UnityEngine;
using System.Collections.Generic;
public class WeaponsManager : MonoBehaviour
{
    private List<IWeapons> weapons = new List<IWeapons>();
    private IWeapons currentWeapon;
    private int currentIndex = 0;

    [SerializeField] private List<MonoBehaviour> weaponBehaviours; // chứa script kế thừa IWeapon

    void Awake()
    {
        foreach (var mono in weaponBehaviours)
        {
            if (mono is IWeapons weapon)
            {
                weapons.Add(weapon);
            }
        }
    }
    void Start()
    {
        AttachWeapons(currentIndex);
    }

    void Update()
    {
        WeaponsInputController();
    }

    void WeaponsInputController()
    {
        HandleFireInput();
        HandleReloadInput();
        HandleSwitchWeaponInput();
    }
    void HandleFireInput()
    {
        if (Input.GetMouseButtonDown(0))
            currentWeapon.Fire();
    }

    void HandleReloadInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentWeapon is IReloadAble reloadable)
                reloadable.ReloadAmmo();
            else
                Debug.Log("This weapon can't reload.");
        }
    }

    void HandleSwitchWeaponInput()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchWeapon(i);
                break;
            }
        }
    }

    void SwitchWeapon(int index)
    {
        if (index < 0 || index >= weapons.Count) return;

        currentWeapon.UnequipWeapon();
        currentIndex = index;
        AttachWeapons(index);
    }

    void AttachWeapons(int index)
    {
        currentWeapon = weapons[index];
        currentWeapon.EquipWeapon();
        Debug.Log($"Switched to weapon at index {index}");
    }
}
