using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Line Attack")]
public class LineAttack : Ability
{
    public bool randomRow;
    [SerializeField]
    public List<int> rows;

    public bool randomColumn;
    [SerializeField]
    public List<int> columns;

    public Stat damage;

    public int Damage { get => (int)damage.Value + abilityPower; }


    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        List<GameUnit> targets = new();

        if(randomRow)
            targets.AddRange(raid.GetRandomRow(rows.ToArray()));
        else
            foreach (int row in rows)
                targets.AddRange(raid.GetRaidersByRow(row));

        if (randomColumn)
            targets.AddRange(raid.GetRandomColumn(columns.ToArray()));
        else
            foreach (int column in columns)
                targets.AddRange(raid.GetRaidersByColumn(column));

        foreach (GameUnit target in targets)
        {
            target.ReceiveDamage(Damage);
            if (nextAbility != null)
                nextAbility.Activate(caster, raid.GetRaiderIndex(target), raid);
        }
    }
}
