using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Healing Over Time")]
public class HotStatusEffect : StatusEffect
{
    public Stat heal;
    public int Heal => (int)heal.Value + effectPower;
    public override void Activate(GameUnit gameUnit)
    {
        gameUnit.ReceiveHeal(Heal);
    }
}
