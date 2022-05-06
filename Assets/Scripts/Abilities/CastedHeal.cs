using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Casted Heal")]
public class CastedHeal : Ability
{
    public int baseHeal;
    public StatusEffect statusEffect;
    public TargetType targetType;

    public enum TargetType
    {
        single,
        row,
        column,
    }

    public int HealValue
    { get { return (int)ApplyModifiers(baseHeal, AbilityModifier.Stat.Heal); } }

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        caster.Mana -= ManaCost;
        (int row, int column) = raid.ArrayIndexToMatrixCoords(targetIndex);

        List<GameUnit> targets = new List<GameUnit>();

        switch (targetType)
        {
            case TargetType.single:
                {
                    targets.Add(raid.raiders[targetIndex]);
                }
                break;

            case TargetType.row:
                {
                    targets = raid.GetRaidersByRow(row);
                }
                break;

            case TargetType.column:
                {
                    targets = raid.GetRaidersByColumn(column);
                }
                break;
        }

        foreach (GameUnit target in targets)
        {
            target.ReceiveHeal(HealValue);
            if (statusEffect != null)
                target.AddStatusEffect(statusEffect);
        }
    }
}
