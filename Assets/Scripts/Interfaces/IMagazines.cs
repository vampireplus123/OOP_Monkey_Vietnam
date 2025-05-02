using UnityEngine;

interface IMagazines
{
    void ReloadBulletMag();
    void OutOfMagazines();
    public bool isOutOfMagazines { get; set; }
}
