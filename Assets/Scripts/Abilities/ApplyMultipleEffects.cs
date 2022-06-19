using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Active Ability/Apply Multiple Effects")]
public class ApplyMultipleEffects : ActiveAbility
{
    public StatusEffect statusEffect;
    public int numberOfTargets;
    public bool avoidAlreadyAffectedTargets;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        statusEffect.caster = caster;

        List<GameUnit> raiders = raid.raiders.Where(Filter).ToList();
        List<GameUnit> targets = new();
        for (int i = 0; i < numberOfTargets && raiders.Count > 0; i++)
        {
            int nextTargetIndex = Random.Range(0, raiders.Count);
            targets.Add(raiders.ElementAt(nextTargetIndex));
            raiders.RemoveAt(nextTargetIndex);
        }

        foreach(GameUnit target in targets)
            target.AddStatusEffect(statusEffect);

    }

    private bool Filter(GameUnit gameUnit)
    {
        if(!gameUnit.IsDead())
        {
            if (avoidAlreadyAffectedTargets && gameUnit.HasStatusEffect(statusEffect))
                return false;
            else
                return true;
        }

        return false;
    }
}
