using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Pierce")]
public class Pierce : Ability
{
    public Stat damage;
    public int Damage => (int)damage.Value;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        (int row, int col) = raid.ArrayIndexToMatrixCoords(targetIndex);

        int damageReceived = raid.raiders[targetIndex].ReceiveDamage(Damage);
        GameUnit[,] raidMatrix = raid.GetRaidersAsMatrix();
        for (int i = 1; i+row < raid.raidRows; i++)
        {
            damageReceived = raidMatrix[row+i, col].ReceiveDamage(damageReceived);
        }
    }
}
