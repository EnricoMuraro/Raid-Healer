using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

[System.Serializable]
public class StatusEffectModifier
{
    public StatusEffect statusEffect;
    public StatusEffect.Stats statName;
    public Modifier modifier;

    public StatusEffectModifier(StatusEffect statusEffect, StatusEffect.Stats statName, Modifier modifier)
    {
        this.statusEffect = statusEffect;
        this.statName = statName;
        this.modifier = modifier;
    }

    private Stat GetStat(string name)
    {
        Type objType = statusEffect.GetType();
        FieldInfo fieldInfo = objType.GetField(name);
        if(fieldInfo != null)
            return (Stat)fieldInfo.GetValue(statusEffect);
        return null;
    }

    public void ApplyModifier()
    {
        Stat stat = GetStat(statName.ToString());
        if(stat != null)
            stat.AddModifier(modifier);
    }

    public void RemoveModifier()
    {
        Stat stat = GetStat(statName.ToString());
        if (stat != null)
            stat.RemoveModifier(modifier);
    }

}
