using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Active Ability/Bosses/Boss 9/Shattering Blow")]
public class ShatteringBlow : ActiveAbility
{
    public float percentageDamage;
    public StatusEffect statusEffect;
    public float statusApplicationChance;


    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);

        foreach (GameUnit raider in raid.raiders)
        {
            raider.ReceiveDamage(Damage + (int)(raider.Health * percentageDamage));
            if (Random.value < statusApplicationChance)
                raider.AddStatusEffect(statusEffect, caster);
        }
    }
}

