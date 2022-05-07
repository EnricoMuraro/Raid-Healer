using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AbilityModifier
{

    public Stat stat;
    public Type type;
    public float value;

    public enum Stat
    {
        Cooldown,
        CastTime,
        ManaCost,
        Damage,
        Heal,
    }

    public enum Type
    {
        Percentage,
        Flat,
    }
}
