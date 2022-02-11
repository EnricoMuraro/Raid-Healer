using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Casted Heal")]
public class CastedHeal : Ability
{
    public int baseHeal;


    public override void Activate(GameUnit caster, GameUnit[] targets)
    {
        if(targets.Length > 0)
        {
            caster.Mana -= manaCost;
            targets[0].Health += baseHeal;
        }
    }
}
