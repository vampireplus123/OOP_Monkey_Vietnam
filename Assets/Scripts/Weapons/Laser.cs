using UnityEngine;

public class Laser : BaseWeapon, IOverHeatable
{
    private float heatLevel = 0f;
    private const float maxHeat = 100f;
    private const float heatIncreaseRate = 10f;

    void Start()
    {
        weaponName = "Laser";
    }
    public override void Fire()
    {
        if (!isEquipped)
        {
            Debug.Log($"{weaponName} is not equipped.");
            return;
        }
        if(heatLevel >= maxHeat)
        {
            OverHeat();
        }
        heatLevel += heatIncreaseRate;
        Debug.Log($"{weaponName} fired. Heat level: {heatLevel}");
    }

    public void OverHeat()
    {
        Debug.Log($"{weaponName} overheated!");
        heatLevel -= 10f;
        Debug.Log($"{weaponName} is cooling down.");
    }
    
}
