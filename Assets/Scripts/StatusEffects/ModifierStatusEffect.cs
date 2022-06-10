using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Modifier Status Effect")]
public class ModifierStatusEffect : StatusEffect
{
    public List<UnitModifier> UnitModifiers;
    public List<AbilityModifier> AbilityModifiers;
    public List<StatusEffectModifier> StatusEffectModifiers;

    public override void StatusEffectStart(GameUnit caster, Raid raid)
    {
        base.StatusEffectStart(caster, raid);
        foreach (UnitModifier unitModifier in UnitModifiers)
            unitModifier.ApplyModifier();
        foreach (AbilityModifier abilityModifier in AbilityModifiers)
            abilityModifier.ApplyModifier();
        foreach (StatusEffectModifier statusEffectModifier in StatusEffectModifiers)
            statusEffectModifier.ApplyModifier();
    }

    public override void StatusEffectEnd(GameUnit caster, Raid raid)
    {
        base.StatusEffectEnd(caster, raid);
        foreach (UnitModifier unitModifier in UnitModifiers)
            unitModifier.RemoveModifier();
        foreach (AbilityModifier abilityModifier in AbilityModifiers)
            abilityModifier.RemoveModifier();
        foreach (StatusEffectModifier statusEffectModifier in StatusEffectModifiers)
            statusEffectModifier.RemoveModifier();
    }
}
