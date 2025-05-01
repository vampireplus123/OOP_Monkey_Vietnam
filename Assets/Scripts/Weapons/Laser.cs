using UnityEngine;

public class Laser : BaseWeapon, IOverHeatable
{
    private float heatLevel = 0f;
    private const float maxHeat = 100f;
    private const float heatIncreaseRate = 10f;

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
    }

    public void OverHeat()
    {
        Debug.Log($"{weaponName} overheated!");
        heatLevel -= heatIncreaseRate; 
    }
}
