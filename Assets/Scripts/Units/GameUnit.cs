using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUnit : MonoBehaviour, IDamageable
{
    [SerializeField] private Unit unit;

    [SerializeField] private int health;
    [SerializeField] private float mana;
    [SerializeField] private float cooldown;
    [SerializeField] private bool dead;

    [SerializeField] private List<StatusEffectSlot> statusEffectSlots;

    public delegate void ValueChange(int oldValue, int newValue);
    public event ValueChange OnDamageReceived;
    public event ValueChange OnHealingReceived;

    public ProgressBar healthBar;
    public ProgressBar manaBar;

    public int Health
    {
        get => health;
        private set
        {
            health = value;

            if (health > unit.MaxHealth)
                health = unit.MaxHealth;

            if (health <= 0)
            {
                health = 0;
                dead = true;
            }
        }
    }
    public int MaxHealth { get => unit.MaxHealth; }

    public int Mana
    {
        get => (int)mana;
        set
        {
            mana = value;
            Mathf.Clamp(mana, 0, unit.MaxMana);
        }
    }

    public int MaxMana { get => unit.MaxMana; }

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

    public float ManaRegenRate { get => unit.ManaRegenRate; }


    private void Awake()
    {
        statusEffectSlots = new List<StatusEffectSlot>();
    }

    public void AddStatusEffect(StatusEffect statusEffect)
    {
        StatusEffectSlot statusEffectSlot = gameObject.AddComponent<StatusEffectSlot>();
        statusEffectSlot.InitStatusEffect(this, statusEffect);
        statusEffectSlot.OnStatusEffectFinished.AddListener(RemoveStatusEffectSlot);
        statusEffectSlots.Add(statusEffectSlot);
    }

    private void RemoveStatusEffectSlot(StatusEffectSlot statusEffectSlot)
    {
        statusEffectSlots.Remove(statusEffectSlot);
        Destroy(statusEffectSlot);
    }

    public void ReceiveHeal(int amount)
    {
        if(!dead)
        {
            int oldHealth = Health;
            Health += amount;
            OnHealingReceived?.Invoke(oldHealth, Health);
        }
    }

    public void ReceiveDamage(int amount)
    {
        if(!dead)
        {
            int oldHealth = Health;
            Health -= amount;
            OnDamageReceived?.Invoke(oldHealth, Health);
        }
    }

    public void attack(GameUnit target)
    {
        if (!dead && target!=null)
        {
            if (Cooldown <= 0)
            {
                Cooldown = unit.AttackFrequency;
                target.ReceiveDamage(unit.Damage);
            }
        }
    }

    public bool isDead() 
    {
        return dead;
    }

    private void Start()
    {
        Health = MaxHealth;
        Mana = MaxMana;
        Cooldown = 0;
        dead = false;
    }

    private void Update() {

        Cooldown -= Time.deltaTime;
        mana += ManaRegenRate*Time.deltaTime;
        Mathf.Clamp(mana, 0, MaxMana);

        if(healthBar != null)
        {
            healthBar.SetMaxValue(MaxHealth);
            healthBar.SetValue(Health);
        }

        if (manaBar != null)
        {
            manaBar.SetMaxValue(MaxMana);
            manaBar.SetValue(Mana);
        }
    }

}
