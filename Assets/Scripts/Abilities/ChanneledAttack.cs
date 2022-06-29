using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Active Ability/Channeled Attack")]
public class ChanneledAttack : Channel
{

    public Pattern targetPattern;
    public int size;

    public enum Pattern
    {
        single,
        plus,
        all,
    }
    public override void Tick(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Tick(caster, targetIndex, raid);
        List<GameUnit> targets = new List<GameUnit>();
        (int targetRow, int targetCol) = raid.ArrayIndexToMatrixCoords(targetIndex);
        GameUnit[,] raiders = raid.GetRaidersAsMatrix();

        switch (targetPattern)
        {
            case Pattern.single:
                targets.Add(raid.raiders[targetIndex]);
                break;

            case Pattern.plus:
                for (int offset = -size; offset <= size; offset++)
                {
                    int newRow = targetRow + offset;
                    int newCol = targetCol + offset;
                    if (newRow >= 0 && newRow < raiders.GetLength(0))
                        targets.Add(raiders[newRow, targetCol]);
                    if (newCol >= 0 && newCol < raiders.GetLength(1))
                        targets.Add(raiders[targetRow, newCol]);
                }
                break;

            case Pattern.all:
                targets = new List<GameUnit>(raid.raiders);
                break;
        }

        foreach (GameUnit target in targets)
        {
            target.ReceiveDamage(Damage);
            if (nextAbility != null)
                nextAbility.Activate(caster, raid.GetRaiderIndex(target), raid);
        }
    }
}
