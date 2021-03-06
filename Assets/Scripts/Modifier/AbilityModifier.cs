using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

[System.Serializable]
public class AbilityModifier
{
    public ActiveAbility ability;
    public Ability.Stats statName;
    public Modifier modifier;
    public ActiveAbility newNextAbility;
    private ActiveAbility oldNextAbility = null;

    public AbilityModifier(ActiveAbility ability, Ability.Stats statName, Modifier modifier)
    {
        this.ability = ability;
        this.statName = statName;
        this.modifier = modifier;
    }

    private Stat GetStat(string name)
    {
        Type objType = ability.GetType();
        FieldInfo fieldInfo = objType.GetField(name);
        if (fieldInfo != null)
            return (Stat)fieldInfo.GetValue(ability);
        return null;
    }

    public void ApplyModifier()
    {
        Stat stat = GetStat(statName.ToString());
        if (stat != null)
            stat.AddModifier(modifier);
        if(newNextAbility != null)
        {
            oldNextAbility = ability.nextAbility;
            ability.nextAbility = newNextAbility;
        }
    }

    public void RemoveModifier()
    {
        Stat stat = GetStat(statName.ToString());
        if (stat != null)
            stat.RemoveModifier(modifier);

        if (newNextAbility != null)
            ability.nextAbility = oldNextAbility;
    }
}
