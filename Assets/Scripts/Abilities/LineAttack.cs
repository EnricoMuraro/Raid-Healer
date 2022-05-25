using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Line Attack")]
public class LineAttack : Ability
{
    [SerializeField]
    public int[] rows;
    [SerializeField]
    public int[] columns;

    public Stat damage;

    public int Damage { get => (int)damage.Value; }

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        GameUnit[,] raiders = raid.GetRaidersAsMatrix();

        foreach (int row in rows)
            if (row < raiders.GetLength(0))
                for (int i = 0; i < raiders.GetLength(1); i++)
                    raiders[row, i].ReceiveDamage(Damage);

        foreach (int col in columns)
            if (col < raiders.GetLength(1))
                for (int i = 0; i < raiders.GetLength(0); i++)
                    raiders[i, col].ReceiveDamage(Damage);

    }
}
