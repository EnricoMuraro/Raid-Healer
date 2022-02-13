using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Cleave Ability")]
public class CleaveAbility : Ability
{
    public int baseDamage;

    public override void Activate(GameUnit caster, int targetIndex, GameUnit[] targets)
    {
        caster.Mana -= manaCost;
        target.ReceiveDamage(baseDamage);
    }
}
