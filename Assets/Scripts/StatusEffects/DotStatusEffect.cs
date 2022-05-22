using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Damage Over Time")]
public class DotStatusEffect : StatusEffect
{
    public int baseDamage;

    public override void Activate(GameUnit gameUnit)
    {
        gameUnit.ReceiveDamage(baseDamage);
    }
}
