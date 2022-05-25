using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Potion")]
public class Potion : Ability
{
    public Stat manaRestored;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        caster.Mana += (int)manaRestored.Value;
    }
}
