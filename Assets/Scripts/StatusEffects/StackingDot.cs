using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Stacking Dot")]
public class StackingDot : StatusEffect
{
    public Stat damage;

    public int Damage { get => (int)damage.Value; }

    public int DmgIncreasePerStack;

    public override void Activate(GameUnit gameUnit, Raid raid)
    {
        base.Activate(gameUnit, raid);
        gameUnit.ReceiveDamage(Damage);
        damage.AddModifier(new Modifier(Modifier.Type.Percentage, Modifier.Source.Temporary, DmgIncreasePerStack));
    }

    public override void StatusEffectRemoved(GameUnit gameUnit, Raid raid)
    {
        base.StatusEffectRemoved(gameUnit, raid);
        damage.RemoveModifiersFromSource(Modifier.Source.Temporary);
    }
}
