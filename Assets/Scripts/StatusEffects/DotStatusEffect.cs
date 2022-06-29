using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Damage Over Time")]
public class DotStatusEffect : StatusEffect
{
    public override void Activate(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks)
    {
        gameUnit.ReceiveDamage(Damage);
    }
}
