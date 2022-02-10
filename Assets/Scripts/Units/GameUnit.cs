using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUnit : MonoBehaviour, IDamageable
{
    public Unit unit;

    [SerializeField] private int health;
    [SerializeField] private float cooldown;
    [SerializeField] private bool dead;

    public HealthBar healthBar;

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
        Cooldown = 0;
        dead = false;
    }

    private void Update() {

        healthBar.SetMaxHealth(unit.MaxHealth);
        healthBar.SetHealth(Health);
        Cooldown -= Time.deltaTime;
    }

}
