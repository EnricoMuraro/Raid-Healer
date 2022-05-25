using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class StatModifier<T> where T : IHasStats
{
    public T target;
    public string statName;
    public Modifier modifier;
    private Stat GetStat(string name)
    {
        Type objType = target.GetType();
        FieldInfo fieldInfo = objType.GetField(name);
        return (Stat)fieldInfo.GetValue(target);
    }

    public void ApplyModifier()
    {
        GetStat(statName).AddModifier(modifier);
    }

    public void RemoveModifier()
    {
        GetStat(statName).RemoveModifier(modifier);
    }
}
