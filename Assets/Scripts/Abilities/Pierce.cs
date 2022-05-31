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
        (_, int col) = raid.ArrayIndexToMatrixCoords(targetIndex);
        GameUnit[,] raidMatrix = raid.GetRaidersAsMatrix();

        int damageReceived = Damage;
        for (int i = 0; i < raid.raidRows; i++)
        {
            damageReceived = raidMatrix[i, col].ReceiveDamage(damageReceived);
        }
    }
}
