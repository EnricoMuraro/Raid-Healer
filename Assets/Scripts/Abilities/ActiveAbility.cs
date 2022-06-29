using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbility : Ability
{
    public Stat cooldown;
    public Stat castTime;
    public Stat manaCost;

    public Stat heal;
    public Stat damage;

    public ActiveAbility nextAbility;

    public float Cooldown { get => cooldown.Value; }
    public float CastTime { get => castTime.Value; }
    public int ManaCost { get => (int)manaCost.Value; }
    public int Heal 
    {
        get
        {
            if (abilityScaling <= 0)
                abilityScaling = 1;
            return (int)(heal.Value + abilityPower * abilityScaling);
        }
    }
    
    public int Damage
    {
        get
        {
            if (abilityScaling <= 0)
                abilityScaling = 1;
            return (int)(damage.Value + abilityPower * abilityScaling);
        }
    }
    


    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);
        caster.Mana -= Mathf.Max(0, ManaCost - caster.ManaEfficiency);
    }
}
