using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityModifier : ScriptableObject
{

    public float cooldownMod;
    public float castTimeMod;
    public float manaCostMod;
    public float damageMod;
    public float healMod;

    public enum ModType
    {
        percentage,
        flat
    }
}
