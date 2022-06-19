using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Active Ability/Shield")]
public class ShieldAbility : ActiveAbility
{
    public Stat shield;
    public int Shield => (int)shield.Value;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        raid.raiders[targetIndex].ReceiveShield(Shield);
        if (nextAbility != null)
            nextAbility.Activate(caster, targetIndex, raid);
    }
}
