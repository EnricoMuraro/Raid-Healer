using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryShield : StatusEffect
{
    public Stat shield;

    public int Shield => (int)shield.Value;

    public override void StatusEffectStart(GameUnit gameUnit, Raid raid)
    {
        base.StatusEffectStart(gameUnit, raid);
        gameUnit.ReceiveShield(Shield);
    }

    public override void StatusEffectEnd(GameUnit gameUnit, Raid raid)
    {
        base.StatusEffectEnd(gameUnit, raid);
        gameUnit.RemoveShield(Shield);
    }
}
