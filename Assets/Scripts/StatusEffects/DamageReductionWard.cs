using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Ward/Damage Reduction Ward")]
public class DamageReductionWard : Ward
{
    public GameunitModifier damageModifier;

    public override void StatusEffectStart(GameUnit caster, Raid raid, int stacks)
    {
        base.StatusEffectStart(caster, raid, stacks);
        damageModifier.gameUnit = caster;
        damageModifier.ApplyModifier();
    }

    public override void StatusEffectRemoved(GameUnit caster, Raid raid, int stacks)
    {
        base.StatusEffectRemoved(caster, raid, stacks);
        damageModifier.RemoveModifier();
    }
}
