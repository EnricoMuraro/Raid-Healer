using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

[System.Serializable]
public class UnitModifier
{
    public Unit unit;
    public Unit.Stats statName;
    public Modifier modifier;
    private Stat GetStat(string name)
    {
        Type objType = unit.GetType();
        FieldInfo fieldInfo = objType.GetField(name);
        if (fieldInfo != null)
            return (Stat)fieldInfo.GetValue(unit);
        return null;
    }

    public void ApplyModifier()
    {
        Stat stat = GetStat(statName.ToString());
        if (stat != null)
            stat.AddModifier(modifier);
    }

    public void RemoveModifier()
    {
        Stat stat = GetStat(statName.ToString());
        if (stat != null)
            stat.RemoveModifier(modifier);
    }
}

