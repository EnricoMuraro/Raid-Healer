using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : ScriptableObject
{
    public int ID;
    public new string name;
    public Sprite icon;

    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float castTime;
    [SerializeField]
    private int manaCost;

    public AbilityModifier[] modifiers;

    public void AddModifiers(AbilityModifier[] abilityModifiers)
    {
        AbilityModifier[] newModifiers = new AbilityModifier[modifiers.Length + abilityModifiers.Length];
        modifiers.CopyTo(newModifiers, 0);
        abilityModifiers.CopyTo(newModifiers, modifiers.Length);
        modifiers = newModifiers;
    }

    protected float ApplyModifiers(float initialValue, AbilityModifier.Stat modStat)
    {
        float flatValuesSum = 0;
        float percentaceValuesSum = 1;

        foreach (var modifier in modifiers)
            if (modifier.stat == modStat)
                switch (modifier.type)
                {
                    case AbilityModifier.Type.Flat:
                        flatValuesSum += modifier.value; break;
                    case AbilityModifier.Type.Percentage:
                        percentaceValuesSum *= 1 + (modifier.value/100); break; 
                }

        initialValue += flatValuesSum;
        initialValue *= percentaceValuesSum;
        return initialValue;
    }

    public float Cooldown 
    { 
        get { return ApplyModifiers(cooldown, AbilityModifier.Stat.Cooldown); } 
        set => cooldown = value; 
    }

    public float CastTime 
    { 
        get { return ApplyModifiers(castTime, AbilityModifier.Stat.CastTime); } 
        set => castTime = value; 
    }
    public int ManaCost 
    { 
        get { return (int)ApplyModifiers(manaCost, AbilityModifier.Stat.ManaCost); } 
        set => manaCost = value; 
    }

    public virtual void Activate(GameUnit caster, int targetIndex, Raid raid) {}
}

/*
public class AbilityArgs
{
    public GameUnit caster;
    public int targetIndex;
    public Raid raid1;
}
*/