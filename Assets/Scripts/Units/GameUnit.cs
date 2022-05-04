using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameUnit : MonoBehaviour, IDamageable
{
    [SerializeField] private Unit unit;

    [SerializeField] private int health = 1;
    [SerializeField] private float mana = 0;
    [SerializeField] private float cooldown = 0;
    [SerializeField] private bool dead = false;

    [SerializeField] private List<StatusEffectSlot> statusEffectSlots;

    public UnityEvent<int> OnHealthChange;
    public UnityEvent<int> OnManaChange;
    public UnityEvent OnDeath;
    public UnityEvent<StatusEffectSlot> OnStatusEffectAdded;

    public ProgressBar manaBar;

    public int Health
    {
        get => health;
        private set
        {
            if (!dead)
            {
                int oldHealth = health;
                health = Mathf.Clamp(value, 0, unit.MaxHealth);

                OnHealthChange?.Invoke(health - oldHealth);

                if (health <= 0)
                {
                    dead = true;
                }
            }
        }
    }
    public int MaxHealth { get => unit.MaxHealth; }

    public int Mana
    {
        get => (int)mana;
        set
        {
            int oldmana = (int)mana;
            mana = Mathf.Clamp(value, 0, unit.MaxMana);
            OnManaChange?.Invoke((int)mana - oldmana);
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
        OnHealthChange = new UnityEvent<int>();
        OnManaChange = new UnityEvent<int>();
        OnStatusEffectAdded = new UnityEvent<StatusEffectSlot>();

        Health = MaxHealth;
        Mana = MaxMana;
    }

    public void AddStatusEffect(StatusEffect statusEffect)
    {
        StatusEffectSlot statusEffectSlot = gameObject.AddComponent<StatusEffectSlot>();
        statusEffectSlot.InitStatusEffect(this, statusEffect);
        statusEffectSlot.OnStatusEffectFinished.AddListener(RemoveStatusEffectSlot);
        statusEffectSlots.Add(statusEffectSlot);
        OnStatusEffectAdded?.Invoke(statusEffectSlot);
    }

    private void RemoveStatusEffectSlot(StatusEffectSlot statusEffectSlot)
    {
        statusEffectSlots.Remove(statusEffectSlot);
        Destroy(statusEffectSlot);
    }

    public void ReceiveHeal(int amount)
    {
        Health += amount;       
    }

    public void ReceiveDamage(int amount)
    {
        Health -= amount;
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
    }

    private void Update() {

        Cooldown -= Time.deltaTime;
        float deltaMana = ManaRegenRate * Time.deltaTime;
        mana += deltaMana;
        mana = Mathf.Clamp(mana, 0, unit.MaxMana);

        if (manaBar != null)
        {
            manaBar.SetMaxValue(MaxMana);
            manaBar.SetValue(Mana);
        }
    }

}
