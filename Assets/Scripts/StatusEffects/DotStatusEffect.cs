using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Damage Over Time")]
public class DotStatusEffect : StatusEffect
{
    public Stat damage;

    public int Damage => (int)damage.Value + effectPower;
    public override void Activate(GameUnit gameUnit)
    {
        gameUnit.ReceiveDamage(Damage);
    }
}
