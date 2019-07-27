using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun", order = 1)]
public class GunObject : ScriptableObject
{
    public string gunName, gunDescription;
    public int gunType;
    public int maxCapacity, currentCapacity;
    public float rateOfFire, reloadTime;
}
