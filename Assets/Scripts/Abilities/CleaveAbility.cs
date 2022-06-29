using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Active Ability/Cleave")]
public class CleaveAbility : ActiveAbility
{
    public Stat numberOfTargets;
    public int NumberOfTargets { get => (int)numberOfTargets.Value; }
    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        List<GameUnit> targets = raid.GetFirstRaiders(NumberOfTargets);
        foreach (GameUnit target in targets)
        {
            target.ReceiveDamage(Damage);
            if (nextAbility != null)
                nextAbility.Activate(caster, raid.GetRaiderIndex(target), raid);
        }
    }
}
