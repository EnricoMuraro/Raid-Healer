using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    [SerializeField] private List<UnitModifier> statModifiers;


    public void Equip(Unit unit)
    {
        foreach (UnitModifier modifier in statModifiers)
        {
            modifier.unit = unit;
            modifier.ApplyModifier();
        }
    }

    public void Unequip()
    {
        foreach (UnitModifier modifier in statModifiers)
        {
            if(modifier.unit != null)
                modifier.RemoveModifier();
        }
    }
}
