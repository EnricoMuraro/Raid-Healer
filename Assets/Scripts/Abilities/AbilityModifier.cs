using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Ability Modifier")]
public class AbilityModifier : ScriptableObject
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
