using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Status Effect/Status Effect")]
public class StatusEffect : ScriptableObject
{

    public int ID;
    public string Name;
    public Sprite Icon;
    public ActivationMode activationMode;
    public Type type;
    public List<Status> statuses;
    public Ability onEndAbility;
    public Ability OnDispelAbility;
    public Stat duration;
    public Stat tickRate;
    [HideInInspector]
    public GameUnit caster;
    public UnityEvent OnStatusEffectStart = new();
    public UnityEvent OnStatusEffectEnd = new();

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
        shield,
    }

    public enum Type
    {
        elemental,
        physical,
        curse,
    }

    public enum Status
    {
        stun
    }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public virtual void Activate(GameUnit gameUnit) { }

    public virtual void OnDispel(GameUnit gameUnit, Raid raid) 
    {
        if (OnDispelAbility != null)
            OnDispelAbility.Activate(gameUnit, raid.GetRaiderIndex(gameUnit), raid);
    }

    public virtual void StatusEffectStart(GameUnit gameUnit, Raid raid) 
    {
        OnStatusEffectStart.Invoke();
    }
    public virtual void StatusEffectEnd(GameUnit gameUnit, Raid raid) 
    {
        OnStatusEffectEnd.Invoke();
        if(onEndAbility != null)
            onEndAbility.Activate(gameUnit, raid.GetRaiderIndex(gameUnit), raid);
    }
}
