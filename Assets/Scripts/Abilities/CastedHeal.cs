using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Casted Heal")]
public class CastedHeal : Ability
{
    public int baseHeal;
    public enum TargetType
    {
        single,
        row,
        column,
    }

    public TargetType targetType;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        caster.Mana -= manaCost;
        (int row, int column) = raid.ArrayIndexToMatrixCoords(targetIndex);

        switch(targetType)
        {
            case TargetType.single:
                raid.raiders[targetIndex].ReceiveHeal(baseHeal);
            break;

            case TargetType.row: {
                var targets = raid.GetRaidersByRow(row);
                foreach (GameUnit target in targets)
                    target.ReceiveHeal(baseHeal);
            } break;

            case TargetType.column: {
                var targets = raid.GetRaidersByColumn(column);
                foreach (GameUnit target in targets)
                    target.ReceiveHeal(baseHeal);
            } break;
        }

    }
}
