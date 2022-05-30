using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Ability/Cleave")]
public class CleaveAbility : Ability
{
    public Stat damage;

    public int Damage { get => (int)damage.Value; }

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        List<GameUnit> targets = raid.GetFirstRaiders(3);
        foreach (GameUnit target in targets)
        {
            target.ReceiveDamage(Damage);
        }
    }
}
