using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(menuName = "Talent/Passive Talent")]
public class PassiveTalent : Talent
{
    public UnitModifier[] unitStatModifiers;
    public AbilityModifier[] abilityModifiers;
    public StatusEffectModifier[] statusEffectModifiers;
}
