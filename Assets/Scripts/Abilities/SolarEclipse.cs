using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Active Ability/Solar Eclipse")]
public class SolarEclipse : ActiveAbility
{
    public StatusEffect effect;
    public float overhealConversionRate;
    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);

        effect.caster = caster;

        effect.OnStatusEffectStart.AddListener(() => caster.OnHealingDone.AddListener(convertOverhealing));
        effect.OnStatusEffectRemoved.AddListener(() => caster.OnHealingDone.RemoveListener(convertOverhealing));


        caster.AddStatusEffect(effect);

    }

    private void convertOverhealing(GameUnit target, int heal, int overheal)
    {
        target.ReceiveShield((int)(overheal*overhealConversionRate));
    }
}
