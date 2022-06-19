using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

[System.Serializable]
public class GameunitModifier
{
    [HideInInspector]
    public GameUnit gameUnit;
    public Unit.Stats statName;
    public Modifier modifier;
    private bool active = false;

    public GameunitModifier(GameUnit gameUnit, Unit.Stats statName, Modifier modifier)
    {
        this.gameUnit = gameUnit;
        this.statName = statName;
        this.modifier = modifier;
    }

    private Stat GetStat(string name)
    {
        Type objType = gameUnit.GetType();
        FieldInfo fieldInfo = objType.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
        if (fieldInfo != null)
            return (Stat)fieldInfo.GetValue(gameUnit);
        Debug.LogWarning("Stat not found on modifier " + this.ToString());
        return null;
    }

    public void ApplyModifier()
    {
        if(!active)
        {
            Stat stat = GetStat(statName.ToString());
            if (stat != null)
            {
                stat.AddModifier(modifier);
                active = true;
            }
        }
    }

    public void RemoveModifier()
    {
        if(active)
        {
            Stat stat = GetStat(statName.ToString());
            if (stat != null)
            {
                stat.RemoveModifier(modifier);
                active = false;
            }
        }
    }

}
