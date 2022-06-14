using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Ability/Apply Multiple Effects")]
public class ApplyMultipleEffects : Ability
{
    public StatusEffect statusEffect;
    public int numberOfTargets;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        statusEffect.caster = caster;

        List<GameUnit> raiders = raid.raiders.Where(x => !x.IsDead()).ToList();
        List<GameUnit> targets = new();
        for (int i = 0; i < numberOfTargets; i++)
        {
            int nextTargetIndex = Random.Range(0, targets.Count);
            targets.Add(raiders.ElementAt(nextTargetIndex));
            raiders.RemoveAt(nextTargetIndex);
        }

        foreach(GameUnit target in targets)
            target.AddStatusEffect(statusEffect);

    }
}
