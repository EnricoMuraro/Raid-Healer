using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ward : StatusEffect
{

    public override void Activate(GameUnit gameUnit, Raid raid)
    {
        base.Activate(gameUnit, raid);
        //Remove any other ward currently active in the raid
        foreach(GameUnit raider in raid.raiders)
            foreach(StatusEffect statusEffect in raider.GetStatusEffects())
                if(statusEffect is Ward)
                    raider.RemoveStatusEffect(statusEffect);
    }
}
