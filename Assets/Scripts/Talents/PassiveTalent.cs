using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Talent/Passive Talent")]
public class PassiveTalent : Talent
{
    [SerializeField]
    public PassiveEffect[] passiveEffects;

    public void ApplyPassiveEffects()
    {
        foreach (var effect in passiveEffects)
            foreach (var ability in effect.affectedAbilities)
                ability.AddModifiers(effect.abilityModifiers);
    }

  
}

[System.Serializable]
public class PassiveEffect
{
    public Ability[] affectedAbilities;
    public AbilityModifier[] abilityModifiers;
}