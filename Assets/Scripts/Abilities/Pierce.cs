using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Active Ability/Pierce")]
public class Pierce : ActiveAbility
{

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        (_, int col) = raid.ArrayIndexToMatrixCoords(targetIndex);
        GameUnit[,] raidMatrix = raid.GetRaidersAsMatrix();

        int damageReceived = Damage;
        for (int i = 0; i < raid.raidRows; i++)
        {
            if(!raidMatrix[i, col].IsDead())
                damageReceived = raidMatrix[i, col].ReceiveDamage(damageReceived);

            if (nextAbility != null && damageReceived > 0)
                nextAbility.Activate(caster, raid.MatrixCoordsToArrayIndex(i,col), raid);
        }
    }
}
