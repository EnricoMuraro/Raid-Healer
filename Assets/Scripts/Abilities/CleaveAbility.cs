using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Cleave Ability")]
public class CleaveAbility : Ability
{
    public int baseDamage;

    public override void Activate(GameUnit caster, GameUnit[] targets)
    {
        foreach(GameUnit target in targets) 
        {
            target.receiveDamage(baseDamage);
        }
    }
}
