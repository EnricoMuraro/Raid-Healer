using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : ScriptableObject
{
    public int ID;
    public new string name;
    [TextArea]
    public string description;
    public Sprite icon;

    public Stat cooldown;
    public Stat castTime;
    public Stat manaCost;

    public Ability nextAbility; 

    public float Cooldown { get => cooldown.Value; }
    public float CastTime { get => castTime.Value; }
    public int ManaCost { get => (int)manaCost.Value; }

    public enum Stats
    {
        cooldown,
        castTime,
        manaCost,
        heal,
        damage,
        manaRestored,
    }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public virtual void Activate(GameUnit caster, int targetIndex, Raid raid) 
    {
        caster.Mana -= ManaCost;
    }
}

/*
public class AbilityArgs
{
    public GameUnit caster;
    public int targetIndex;
    public Raid raid1;
}
*/