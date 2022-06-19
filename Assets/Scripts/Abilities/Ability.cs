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

    protected int abilityPower;

    public enum Stats
    {
        cooldown,
        castTime,
        manaCost,
        heal,
        shield,
        damage,
        manaRestored,
        numberOfTargets,
    }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public virtual void Activate(GameUnit caster, int targetIndex, Raid raid) 
    {
        abilityPower = caster.AbilityPower;
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