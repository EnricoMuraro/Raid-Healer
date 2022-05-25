using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Damage Over Time")]
public class DotStatusEffect : StatusEffect
{
    public Stat damage;

    public override void Activate(GameUnit gameUnit)
    {
        gameUnit.ReceiveDamage((int)damage.Value);
    }
}
