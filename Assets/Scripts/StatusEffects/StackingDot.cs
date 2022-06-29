using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Stacking Dot")]
public class StackingDot : StatusEffect
{

    public int DmgIncreasePerStack;

    public override void Activate(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks)
    {
        base.Activate(caster, gameUnit, raid, stacks);
        gameUnit.ReceiveDamage(Damage * DmgIncreasePerStack * stacks);
    }
}
