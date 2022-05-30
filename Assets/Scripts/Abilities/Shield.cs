using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Shield")]
public class Shield : Ability
{
    public Stat shieldAmount;
    public int ShieldAmount => (int)shieldAmount.Value;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        raid.raiders[targetIndex].ReceiveShield(ShieldAmount);
    }
}
