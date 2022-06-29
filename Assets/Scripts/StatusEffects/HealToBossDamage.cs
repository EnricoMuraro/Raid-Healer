using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Heal To Boss Damage")]
public class HealToBossDamage : StatusEffect
{
    public float conversionRate;

    public override void StatusEffectStart(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks)
    {
        base.StatusEffectStart(caster, gameUnit, raid, stacks);
        gameUnit.OnHealingReceived.AddListener((int heal, int overheal) => ConvertHeal(heal, overheal, gameUnit, raid));
    }
    
    public override void StatusEffectRemoved(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks)
    {
        base.StatusEffectRemoved(caster, gameUnit, raid, stacks);
        gameUnit.OnDamageReceived.RemoveListener((int heal, int overheal) => ConvertHeal(heal, overheal, gameUnit, raid));
    }

    private void ConvertHeal(int healAmount, int overheal, GameUnit gameUnit, Raid raid)
    {
        int healingReceived = healAmount - overheal;
        gameUnit.ReceiveDamage(healingReceived, true);

        raid.Boss.ReceiveDamage((int)(healAmount * conversionRate));
    }    
}
