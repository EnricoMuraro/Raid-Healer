using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Ability/Aoe Attack")]
public class AoeAttack : Ability
{
    public Stat damage;
    public int Damage { get => (int)damage.Value + abilityPower; }


    public Pattern attackPattern;
    public int size;

    public enum Pattern
    {
        plus,
    }

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        List<GameUnit> targets = new List<GameUnit>();
        (int targetRow , int targetCol) = raid.ArrayIndexToMatrixCoords(targetIndex);
        GameUnit[,] raiders = raid.GetRaidersAsMatrix();

        switch (attackPattern)
        {
            case Pattern.plus:
                for(int offset = -size; offset <= size; offset++)
                {
                    int newRow = targetRow + offset;
                    int newCol = targetCol + offset;
                    if(newRow >= 0 && newRow < raiders.GetLength(0))
                        targets.Add(raiders[newRow, targetCol]);
                    if(newCol >= 0 && newCol < raiders.GetLength(1))
                        targets.Add(raiders[targetRow, newCol]);
                }
                break;
        }

        foreach(GameUnit target in targets)
        {
            target.ReceiveDamage(Damage);
            if (nextAbility != null)
                nextAbility.Activate(caster, raid.GetRaiderIndex(target), raid);
        }
    }
}
