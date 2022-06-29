using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Ward/Demonic Ward")]
public class DemonicWard : Ward
{
    public GameunitModifier damageModifier;
    public float manaConversionRate;
    
    public override void StatusEffectStart(GameUnit caster, GameUnit target, Raid raid, int stacks)
    {
        base.StatusEffectStart(caster, target, raid, stacks);
        damageModifier.gameUnit = target;
        damageModifier.ApplyModifier();
        target.OnDamageReceived.AddListener((int damage, int damageReceived) => RestoreMana(damageReceived, raid.Player));
    }

    public override void StatusEffectRemoved(GameUnit caster, GameUnit target, Raid raid, int stacks)
    {
        base.StatusEffectRemoved(caster, target, raid, stacks);
        damageModifier.RemoveModifier();
        target.OnDamageReceived.RemoveListener((int damage, int damageReceived) => RestoreMana(damageReceived, raid.Player));
    }

    private void RestoreMana(int damage, GameUnit target)
    {
        int manaRestored = (int)(damage * manaConversionRate);
        target.Mana += manaRestored;
    }
}
