using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbility : Ability
{
    public Stat cooldown;
    public Stat castTime;
    public Stat manaCost;

    public ActiveAbility nextAbility;

    public float Cooldown { get => cooldown.Value; }
    public float CastTime { get => castTime.Value; }
    public int ManaCost { get => (int)manaCost.Value; }

    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        caster.Mana -= Mathf.Max(0, ManaCost - caster.ManaEfficiency);
    }
}
