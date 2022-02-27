using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon data", menuName ="Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public string description;
    public int cost;
    public int damage;
}
