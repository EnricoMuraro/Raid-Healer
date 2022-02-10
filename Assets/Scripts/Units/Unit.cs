using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Unit : ScriptableObject 
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int damage;
    [SerializeField] private float attackFrequency;
    
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    public int Damage { get => damage; set => damage = value; }
    public float AttackFrequency { get => attackFrequency; set => attackFrequency = value; }

    public Unit(int maxHealth, int damage, float attackfrequency)
    {
        MaxHealth = maxHealth;
        Damage = damage;
        AttackFrequency = attackfrequency;
    }

}
