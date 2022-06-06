using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Apply Status Effect")]
public class ApplyStatusEffect : Ability
{
    public StatusEffect effect;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        effect.effectPower = caster.AbilityPower;
        raid.raiders[targetIndex].AddStatusEffect(effect);
    }
}
