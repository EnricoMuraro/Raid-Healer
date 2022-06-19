using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryShield : StatusEffect
{
    public Stat shield;

    public int Shield => (int)shield.Value;

    public override void StatusEffectStart(GameUnit gameUnit, Raid raid, int stacks)
    {
        base.StatusEffectStart(gameUnit, raid, stacks);
        gameUnit.ReceiveShield(Shield);
    }

    public override void StatusEffectEnd(GameUnit gameUnit, Raid raid, int stacks)
    {
        base.StatusEffectEnd(gameUnit, raid, stacks);
        gameUnit.RemoveShield(Shield);
    }
}
