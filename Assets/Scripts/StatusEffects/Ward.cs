using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ward : StatusEffect
{

    public override void StatusEffectStart(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks)
    {
        base.StatusEffectStart(caster, gameUnit, raid, stacks);

    }
}
