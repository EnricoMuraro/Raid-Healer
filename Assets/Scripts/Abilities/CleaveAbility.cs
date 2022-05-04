using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Cleave Ability")]
public class CleaveAbility : Ability
{
    public int baseDamage;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        caster.Mana -= ManaCost;
        List<GameUnit> targets = raid.GetFirstRaiders(3);
        foreach (GameUnit target in targets)
        {
            target.ReceiveDamage(baseDamage);
        }
    }
}
