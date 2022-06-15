using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Ward/Demonic Ward")]
public class DemonicWard : Ward
{
    public Modifier damageModifier;
    public float manaConversionRate;

    public override void StatusEffectStart(GameUnit caster, Raid raid)
    {
        base.StatusEffectStart(caster, raid);
        caster.DamageReceived.AddModifier(damageModifier);
        caster.OnDamageReceived.AddListener((int damage, int damageReceived) => RestoreMana(damageReceived, raid.Player));
    }

    public override void StatusEffectRemoved(GameUnit caster, Raid raid)
    {
        base.StatusEffectEnd(caster, raid);
        caster.DamageReceived.AddModifier(damageModifier);
        caster.OnDamageReceived.RemoveListener((int damage, int damageReceived) => RestoreMana(damageReceived, raid.Player));
    }

    private void RestoreMana(int damage, GameUnit target)
    {
        int manaRestored = (int)(damage * manaConversionRate);
        target.Mana += manaRestored;
    }
}
