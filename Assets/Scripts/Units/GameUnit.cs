using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameUnit : MonoBehaviour
{
    [SerializeField] private Unit unit;

    [SerializeField] private int health = 1;
    [SerializeField] private int currentShield;
    [SerializeField] private float mana = 0;
    [SerializeField] private float cooldown = 0;
    [SerializeField] private bool dead = false;

    private Dictionary<StatusEffect.Status, List<int>> statusCache = new ();

    public UnityEvent<int> OnHealthChange;
    public UnityEvent<int> OnManaChange;
    public UnityEvent OnDeath;
    public UnityEvent<StatusEffectSlot> OnStatusEffectAdded;
    public UnityEvent<int, int> OnHealingReceived;
    public UnityEvent<int, int> OnDamageReceived;
    public UnityEvent<GameUnit, int, int> OnHealingDone;

    public ProgressBar manaBar;

    public int MaxHealth { get => (int)unit.maxHealth.Value; }
    public int MaxMana { get => (int)unit.maxMana.Value; }
    public float ManaRegenRate { get => unit.manaRegenRate.Value; }
    public int Damage { get => (int)unit.damage.Value; }
    public float AttackFrequency { get => unit.attackFrequency.Value; }
    public int AbilityPower { get => (int)unit.abilityPower.Value; }
    public int ManaEfficiency { get => (int)unit.manaEfficiency.Value; }

    public Stat MaxHealthStat { get => unit.maxHealth; }
    public Stat MaxManaStat { get => unit.maxMana; }
    public Stat ManaRegenRateStat { get => unit.manaRegenRate; }
    public Stat DamageStat { get => unit.damage; }
    public Stat AttackFrequencyStat { get => unit.attackFrequency; }
    public Stat DamageReceived { get => new Stat(unit.damageReceived); }

    public Unit.Role Role { get => unit.role; }

    public void InitUnit(Unit unit)
    {
        this.unit = unit;
    }

    public Unit GetUnit()
    {
        return unit;
    }

    public int Health
    {
        get => health;
        private set
        {
            if (!dead)
            {
                int oldHealth = health;
                health = Mathf.Clamp(value, 0, MaxHealth);

                OnHealthChange?.Invoke(health - oldHealth);

                if (health <= 0)
                {
                    dead = true;
                    RemoveAllStatusEffects();
                    OnDeath?.Invoke();
                }
            }
        }
    }

    public int Mana
    {
        get => (int)mana;
        set
        {
            int oldmana = (int)mana;
            mana = Mathf.Clamp(value, 0, MaxMana);
            OnManaChange?.Invoke((int)mana - oldmana);
        }
    }


    public float Cooldown
    {
        get => cooldown;
        set
        {
            cooldown = value;
            if (cooldown < 0)
                cooldown = 0;
        }
    }

    public int Shield 
    { 
        get => currentShield;
        private set
        {
            currentShield = Mathf.Clamp(value, 0, int.MaxValue);
        }
    }

    private void Awake()
    {
        OnHealthChange = new UnityEvent<int>();
        OnManaChange = new UnityEvent<int>();
        OnHealingReceived = new();

        Health = MaxHealth;
        Mana = MaxMana;
        Shield = (int)unit.shield.Value;
    }

    public List<StatusEffect> GetStatusEffects()
    {
        List<StatusEffect> effects = new List<StatusEffect>();
        foreach(StatusEffectSlot statusEffectSlot in GetComponents<StatusEffectSlot>())
            effects.Add(statusEffectSlot.GetStatusEffect());
        return effects;
    }

    public void AddStatusEffect(StatusEffect statusEffect)
    {
        if(!IsDead())
        {
            if (statusEffect.activationMode == StatusEffect.ActivationMode.replace)
                RemoveStatusEffect(statusEffect);

            AddToCache(statusEffect);

            StatusEffectSlot statusEffectSlot = gameObject.AddComponent<StatusEffectSlot>();
            statusEffectSlot.InitStatusEffect(statusEffect);
            OnStatusEffectAdded?.Invoke(statusEffectSlot);
            statusEffectSlot.OnStatusEffectFinished.AddListener(statusSlot => RemoveFromCache(statusSlot.GetStatusEffect()));
        }
    }

    public void RemoveStatusEffect(StatusEffect statusEffect)
    {
        foreach(StatusEffectSlot statusEffectSlot in GetComponents<StatusEffectSlot>())
            if (statusEffectSlot.GetStatusEffect().ID == statusEffect.ID)
                RemoveStatusEffectSlot(statusEffectSlot);
    }

    public void RemoveAllStatusEffects()
    {
        foreach (StatusEffectSlot statusEffectSlot in GetComponents<StatusEffectSlot>())
            RemoveStatusEffectSlot(statusEffectSlot);
    }

    public void DispelStatusEffectByType(StatusEffect.Type type, bool all = false)
    {
        foreach(StatusEffectSlot statusEffectSlot in GetComponents<StatusEffectSlot>())
        {
            if (statusEffectSlot.GetStatusEffect().type == type && !statusEffectSlot.GetStatusEffect().DispelImmune)
            {
                statusEffectSlot.Dispelled();
                RemoveStatusEffectSlot(statusEffectSlot);

                if (all == false)
                    break;
            }
        }
    }

    private void RemoveStatusEffectSlot(StatusEffectSlot statusEffectSlot)
    {
        StatusEffect statusEffect = statusEffectSlot.GetStatusEffect();
        RemoveFromCache(statusEffect);
        Destroy(statusEffectSlot);
    }

    private void AddToCache(StatusEffect statusEffect)
    {
        foreach (StatusEffect.Status status in statusEffect.statuses)
        {
            if (!statusCache.ContainsKey(status))
                statusCache.Add(status, new List<int>());
            statusCache[status].Add(statusEffect.ID);
        }
    }

    private void RemoveFromCache(StatusEffect statusEffect)
    {
        foreach (StatusEffect.Status status in statusEffect.statuses)
            statusCache[status].Remove(statusEffect.ID);
    }

    public void Heal(GameUnit target, int amount)
    {
        int newAmount = amount + AbilityPower;
        int overheal = target.ReceiveHeal(newAmount);
        OnHealingDone.Invoke(target, newAmount, overheal);
    }

    //returns overheal done
    public int ReceiveHeal(int amount)
    {
        int oldHealth = Health;
        Health += amount;
        int overheal = oldHealth + amount - Health;
        OnHealingReceived.Invoke(amount, overheal);
        return overheal;
    }

    public int ReceiveDamage(int amount)
    {
        DamageReceived.BaseValue = amount;
        int modifiedAmount = (int)DamageReceived.Value;
        int oldHealh = Health;
        int shieldDiff = Shield - modifiedAmount;
        Shield -= modifiedAmount;
        if(shieldDiff < 0)
            Health += shieldDiff;

        int damageReceived = oldHealh - Health;
        OnDamageReceived.Invoke(amount, damageReceived);
        return (damageReceived);
    }

    public void ReceiveShield(int amount)
    {
        Shield += amount;
    }

    public void RemoveShield(int amount)
    {
        Shield -= amount;
    }

    public void Attack(GameUnit target)
    {
        if (!IsDead() && target!=null && !IsStunned())
        {
            if (Cooldown <= 0)
            {
                Cooldown = AttackFrequency;
                target.ReceiveDamage(Damage);
            }
        }
    }

    public bool IsDead() 
    {
        return dead;
    }

    public bool IsStunned()
    {
        return HasStatus(StatusEffect.Status.stun);
    }

    public bool HasStatus(StatusEffect.Status status)
    {
        bool found = statusCache.TryGetValue(status, out List<int> statusIDs);
        if (found)
            return statusIDs.Count > 0;
        else
            return false;
    }
        

    private void Start()
    {
    }

    private void Update() {

        Cooldown -= Time.deltaTime;
        float deltaMana = ManaRegenRate * Time.deltaTime;
        mana += deltaMana;
        mana = Mathf.Clamp(mana, 0, MaxMana);

        if (manaBar != null)
        {
            manaBar.SetMaxValue(MaxMana);
            manaBar.SetValue(Mana);
        }
    }

}
