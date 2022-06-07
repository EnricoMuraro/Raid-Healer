using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryShield : StatusEffect
{
    public Stat shield;

    public int Shield => (int)shield.Value;

    public override void OnStatusEffectStart(GameUnit gameUnit, Raid raid)
    {
        base.OnStatusEffectStart(gameUnit, raid);
        gameUnit.ReceiveShield(Shield);
    }

    public override void OnStatusEffectEnd(GameUnit gameUnit, Raid raid)
    {
        base.OnStatusEffectEnd(gameUnit, raid);
        gameUnit.RemoveShield(Shield);
    }
}
