using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : ScriptableObject
{

    public int ID;
    public string Name;
    public Sprite Icon;
    public ActivationMode activationMode;
    public Type type;
    public Ability onEndAbility;
    public Stat duration;
    public Stat tickRate;

    public float Duration { get => duration.Value; }
    public float TickRate { get => tickRate.Value; }

    public enum ActivationMode
    {
        add,
        replace,
    }

    public enum Stats
    {
        duration,
        tickRate,
        heal,
        damage,
    }

    public enum Type
    {
        elemental,
        physical,
        curse,
    }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public virtual void Activate(GameUnit gameUnit) { }
    public virtual void OnStatusEffectEnd(GameUnit gameUnit, Raid raid) 
    {
        if(onEndAbility != null)
            onEndAbility.Activate(gameUnit, raid.GetRaiderIndex(gameUnit), raid);
    }
}
