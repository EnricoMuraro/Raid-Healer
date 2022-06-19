using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Active Ability/Potion")]
public class Potion : ActiveAbility
{
    public Stat manaRestored;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        caster.Mana += (int)manaRestored.Value;
        if (nextAbility != null)
            nextAbility.Activate(caster, targetIndex, raid);
    }
}
