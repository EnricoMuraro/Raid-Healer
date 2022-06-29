using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Healing Over Time")]
public class HotStatusEffect : StatusEffect
{

    public override void Activate(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks)
    {
        int newHeal = Heal;
        caster.Heal(gameUnit, newHeal);
    }
}
