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
    public bool DispelImmune;
    public bool showStacks;
    public Stat duration;
    public Stat tickRate;

    public Stat heal;
    public Stat damage;

    public float abilityScaling;

    public Ability onEndAbility;
    public Ability OnDispelAbility;
    
    [HideInInspector]
    public GameUnit caster;
    public UnityEvent OnStatusEffectStart = new();
    public UnityEvent OnStatusEffectEnd = new();
    public UnityEvent OnStatusEffectRemoved = new();

    public float Duration { get => duration.Value; }
    public float TickRate { get => tickRate.Value; }
    public int Heal
    {
        get
        {
            if (abilityScaling <= 0)
                abilityScaling = 1;
            return (int)(heal.Value + caster.AbilityPower * abilityScaling);
        }
    }

    public int Damage
    {
        get
        {
            if (abilityScaling <= 0)
                abilityScaling = 1;
            return (int)(damage.Value + caster.AbilityPower * abilityScaling);
        }
    }

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
    public virtual void Activate(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks) { }

    public virtual void OnDispel(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks) 
    {
        if (OnDispelAbility != null)
            OnDispelAbility.Activate(gameUnit, raid.GetRaiderIndex(gameUnit), raid);

        StatusEffectRemoved(caster, gameUnit, raid, stacks);
    }

    public virtual void StatusEffectStart(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks) 
    {
        OnStatusEffectStart.Invoke();
    }
    public virtual void StatusEffectEnd(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks) 
    {
        OnStatusEffectEnd.Invoke();
        if(onEndAbility != null)
            onEndAbility.Activate(gameUnit, raid.GetRaiderIndex(gameUnit), raid);

        StatusEffectRemoved(caster, gameUnit, raid, stacks);
    }
    public virtual void StatusEffectRemoved(GameUnit caster, GameUnit gameUnit, Raid raid, int stacks)
    {
        OnStatusEffectRemoved.Invoke();
    }
}
