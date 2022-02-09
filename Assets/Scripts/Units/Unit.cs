using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Unit : ScriptableObject 
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private float attackFrequency;
    [SerializeField] private float cooldown;
    
    public int MaxHealth { get => health; set => health = value; }
    public int Health 
    { 
        get => health; 
        set 
        {
            health = value;
            if (health < 0)
                health = 0;
        }
    }
    public int Damage { get => damage; set => damage = value; }
    public float AttackFrequency { get => attackFrequency; set => attackFrequency = value; }
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

  
    public Unit(int health, int damage, float attackfrequency, float cooldown)
    {
        Health = health;
        MaxHealth = health;
        Damage = damage;
        AttackFrequency = attackfrequency;
        Cooldown = cooldown;
    }

}
