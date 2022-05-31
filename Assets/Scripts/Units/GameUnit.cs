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

    public UnityEvent<int> OnHealthChange;
    public UnityEvent<int> OnManaChange;
    public UnityEvent OnDeath;
    public UnityEvent<StatusEffectSlot> OnStatusEffectAdded;

    public ProgressBar manaBar;

    public int MaxHealth { get => (int)unit.maxHealth.Value; }
    public int MaxMana { get => (int)unit.maxMana.Value; }
    public float ManaRegenRate { get => unit.manaRegenRate.Value; }
    public int Shield { get => currentShield; private set => currentShield = value; }
    public int Damage { get => (int)unit.damage.Value; }
    public float AttackFrequency { get => unit.attackFrequency.Value; }

    public Stat MaxHealthStat { get => unit.maxHealth; }
    public Stat MaxManaStat { get => unit.maxMana; }
    public Stat ManaRegenRateStat { get => unit.manaRegenRate; }
    public Stat DamageStat { get => unit.damage; }
    public Stat AttackFrequencyStat { get => unit.attackFrequency; }

    public void InitUnit(Unit unit)
    {
        this.unit = unit;
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

    private void Awake()
    {
        OnHealthChange = new UnityEvent<int>();
        OnManaChange = new UnityEvent<int>();

        Health = MaxHealth;
        Mana = MaxMana;
        Shield = (int)unit.shield.Value;
    }

    public void AddStatusEffect(StatusEffect statusEffect)
    {
        if(!isDead())
        {
            if (statusEffect.activationMode == StatusEffect.ActivationMode.replace)
                RemoveStatusEffect(statusEffect);

            StatusEffectSlot statusEffectSlot = gameObject.AddComponent<StatusEffectSlot>();
            statusEffectSlot.InitStatusEffect(statusEffect);
            OnStatusEffectAdded?.Invoke(statusEffectSlot);
        }
    }

    public void RemoveStatusEffect(StatusEffect statusEffect)
    {
        foreach(StatusEffectSlot statusEffectSlot in GetComponents<StatusEffectSlot>())
            if (statusEffectSlot.GetStatusEffect().ID == statusEffect.ID)
                Destroy(statusEffectSlot);
    }

    public void RemoveAllStatusEffects()
    {
        foreach (StatusEffectSlot statusEffectSlot in GetComponents<StatusEffectSlot>())
            Destroy(statusEffectSlot);
    }

    public void RemoveStatusEffectByType(StatusEffect.Type type, bool all = false)
    {
        foreach(StatusEffectSlot statusEffectSlot in GetComponents<StatusEffectSlot>())
        {
            if (statusEffectSlot.GetStatusEffect().type == type)
                Destroy(statusEffectSlot);

            if (all == false)
                break;
        }
    }

    public void ReceiveHeal(int amount)
    {
        Health += amount;       
    }

    public int ReceiveDamage(int amount)
    {
        int oldHealh = Health;
        Shield -= amount;
        if(Shield < 0)
        {
            Health += Shield;
            Shield = 0;
        }
        return (oldHealh - Health);
    }

    public void ReceiveShield(int amount)
    {
        Shield += amount;
    }

    public void Attack(GameUnit target)
    {
        if (!dead && target!=null)
        {
            if (Cooldown <= 0)
            {
                Cooldown = AttackFrequency;
                target.ReceiveDamage(Damage);
            }
        }
    }

    public bool isDead() 
    {
        return dead;
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
