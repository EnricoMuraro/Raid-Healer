using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HotStatusEffect : StatusEffect
{
    public int baseHeal;

    public override void Activate(GameUnit gameUnit)
    {
        gameUnit.ReceiveHeal(baseHeal);
    }
}
