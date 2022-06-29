using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Modifier Status Effect")]
public class ModifierStatusEffect : StatusEffect
{
    public List<GameunitModifier> UnitModifiers;
    public List<AbilityModifier> AbilityModifiers;
    public List<StatusEffectModifier> StatusEffectModifiers;

    public override void StatusEffectStart(GameUnit caster, GameUnit target, Raid raid, int stacks)
    {
        base.StatusEffectStart(caster, target, raid, stacks);
        foreach (GameunitModifier unitModifier in UnitModifiers)
        {
            unitModifier.gameUnit = target; 
            unitModifier.ApplyModifier();
        }
        foreach (AbilityModifier abilityModifier in AbilityModifiers)
            abilityModifier.ApplyModifier();
        foreach (StatusEffectModifier statusEffectModifier in StatusEffectModifiers)
            statusEffectModifier.ApplyModifier();
    }

    public override void StatusEffectRemoved(GameUnit caster, GameUnit target, Raid raid, int stacks)
    {
        base.StatusEffectRemoved(caster, target, raid, stacks);
        foreach (GameunitModifier unitModifier in UnitModifiers)
            unitModifier.RemoveModifier();
        foreach (AbilityModifier abilityModifier in AbilityModifiers)
            abilityModifier.RemoveModifier();
        foreach (StatusEffectModifier statusEffectModifier in StatusEffectModifiers)
            statusEffectModifier.RemoveModifier();
    }
}