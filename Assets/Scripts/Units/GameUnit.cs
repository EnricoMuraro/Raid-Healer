using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUnit : MonoBehaviour, IDamageable
{
    public Unit unit;

    [SerializeField] private int health;
    [SerializeField] private float mana;
    [SerializeField] private float cooldown;
    [SerializeField] private bool dead;

    public ProgressBar healthBar;
    public ProgressBar manaBar;

    public int Health
    {
        get => health;
        set
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

    public int Mana
    {
        get => (int) mana;
        set
        {
            mana = value;
            Mathf.Clamp(mana, 0, unit.MaxMana);
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

    public void receiveDamage(int amount)
    {
        if(!dead)
            Health -= amount;
    }

    public void attack(GameUnit target)
    {
        if (!dead)
        {
            if (Cooldown <= 0)
            {
                Cooldown = unit.AttackFrequency;
                target.receiveDamage(unit.Damage);
            }
        }
    }

    private void Start()
    {
        Health = unit.MaxHealth;
        Mana = unit.MaxMana;
        Cooldown = 0;
        dead = false;
    }

    private void Update() {

        Cooldown -= Time.deltaTime;
        mana += unit.ManaRegenRate*Time.deltaTime;
        Mathf.Clamp(mana, 0, unit.MaxMana);

        if(healthBar != null)
        {
            healthBar.SetMaxValue(unit.MaxHealth);
            healthBar.SetValue(Health);
        }

        if (manaBar != null)
        {
            manaBar.SetMaxValue(unit.MaxMana);
            manaBar.SetValue(Mana);
        }
    }

}
