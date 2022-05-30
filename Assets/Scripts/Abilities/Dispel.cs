using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Dispel")]
public class Dispel : Ability
{
    public List<StatusEffect.Type> dispelTypes;

    public bool dispelAll;

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        foreach(var type in dispelTypes)
            raid.raiders[targetIndex].RemoveStatusEffectByType(type, dispelAll);

        caster.Mana -= ManaCost;
    }
}
