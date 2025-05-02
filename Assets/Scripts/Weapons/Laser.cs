using System.Collections;
using UnityEngine;

public class Laser : BaseWeapon, IOverHeatable,IEnergyRestore
{
    private int heatLevel = 0;
    private const int maxHeat = 100;
    private const int heatIncreaseRate = 10;

    private int EnergyRemain;

    void Awake()
    {
        weaponName = "Laser";
        EnergyRemain = 2;
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
            RestoreEnergy();
        }
        heatLevel += heatIncreaseRate;
        Debug.Log($"{weaponName} fired. Heat level: {heatLevel}");
    }

    public void OverHeat()
    {
        Debug.Log($"{weaponName} overheated!");
        // while (heatLevel > 10)
        // {
        //     Debug.Log($"{weaponName} cooling down. Heat level: {heatLevel}");
        //     heatLevel -= heatIncreaseRate;
        // }   
        StartCoroutine(DecreaseHeat()); 
    }
    public void RestoreEnergy()
    {
        if (EnergyRemain <= 0)
        {
            Debug.Log($"{weaponName}: No more energy left!");
            return;
        }
        EnergyRemain--;
        Debug.Log($"{weaponName} energy restored. Remaining energy: {EnergyRemain}");
    }
    IEnumerator DecreaseHeat()
    {
        while (heatLevel > 0)
        {
            heatLevel -= heatIncreaseRate;
            Debug.Log($"{weaponName} cooling down. Heat level: {heatLevel}");
            yield return new WaitForSeconds(1f);
        }
        Debug.Log($"{weaponName} is cooled down.");
    }
}
