using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Healing Over Time")]
public class HotStatusEffect : StatusEffect
{
    public Stat heal;
    public int Heal => (int) heal.Value;

    public override void Activate(GameUnit gameUnit, Raid raid, int stacks)
    {
        int newHeal = Heal;
        if(caster != null)
            newHeal = (int) (Heal + caster.AbilityPower / (duration.Value / tickRate.Value));
        
        caster.Heal(gameUnit, newHeal);
    }
}
