using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Active Ability/Apply Status Effect")]
public class ApplyStatusEffect : ActiveAbility
{
    public bool SelfApply;
    public StatusEffect effect;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);

        effect.caster = caster;

        if (SelfApply)
            caster.AddStatusEffect(effect);
        else
        {

            //Remove any other ward currently active in the raid
            if (effect is Ward)
                foreach (GameUnit raider in raid.raiders)
                    foreach (StatusEffect statusEffect in raider.GetStatusEffects())
                        if (statusEffect is Ward)
                            raider.RemoveStatusEffect(statusEffect);

            raid.raiders[targetIndex].AddStatusEffect(effect);
        }
    }
}
