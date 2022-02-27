using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Potion", menuName ="Inventory/Potion")]
public class HealthPotion : Item
{
    public int healthModifier;
    HealthAndDamage healthAndDamage;

    void Start()
    {
        healthAndDamage = HealthAndDamage.instance;
    }
    public override void Use()
    {
        base.Use();
        ApplyEffect();
    }

    public void ApplyEffect()
    {
        healthAndDamage.AddLife(healthModifier);
    }
}
