using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryShield : StatusEffect
{
    public Stat shield;

    public int Shield => (int)shield.Value;

    public override void StatusEffectStart(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks)
    {
        base.StatusEffectStart(caster, gameUnit, raid, stacks);
        gameUnit.ReceiveShield(Shield);
    }

    public override void StatusEffectEnd(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks)
    {
        base.StatusEffectEnd(caster, gameUnit, raid, stacks);
        gameUnit.RemoveShield(Shield);
    }
}
