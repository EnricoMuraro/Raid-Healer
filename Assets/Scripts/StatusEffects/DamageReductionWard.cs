using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Ward/Damage Reduction Ward")]
public class DamageReductionWard : Ward
{
    public Modifier damageModifier;

    public override void StatusEffectStart(GameUnit caster, Raid raid)
    {
        base.StatusEffectStart(caster, raid);
        caster.DamageReceived.AddModifier(damageModifier);
    }

    public override void StatusEffectRemoved(GameUnit caster, Raid raid)
    {
        base.StatusEffectEnd(caster, raid);
        caster.DamageReceived.AddModifier(damageModifier);
    }
}
