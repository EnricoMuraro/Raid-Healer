using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Ward/Damage Reduction Ward")]
public class DamageReductionWard : Ward
{
    public GameunitModifier damageModifier;

    public override void StatusEffectStart(GameUnit caster, GameUnit target, Raid raid, int stacks)
    {
        base.StatusEffectStart(caster, target, raid, stacks);
        damageModifier.gameUnit = target;
        damageModifier.ApplyModifier();
    }

    public override void StatusEffectRemoved(GameUnit caster, GameUnit target, Raid raid, int stacks)
    {
        base.StatusEffectRemoved(caster, target, raid, stacks);
        damageModifier.RemoveModifier();
    }
}
