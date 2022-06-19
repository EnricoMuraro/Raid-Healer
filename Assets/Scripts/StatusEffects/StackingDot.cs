using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Stacking Dot")]
public class StackingDot : StatusEffect
{
    public Stat damage;

    public int Damage { get => (int)damage.Value; }

    public int DmgIncreasePerStack;

    public override void Activate(GameUnit gameUnit, Raid raid, int stacks)
    {
        base.Activate(gameUnit, raid, stacks);
        gameUnit.ReceiveDamage(Damage * DmgIncreasePerStack * stacks);
    }
}
