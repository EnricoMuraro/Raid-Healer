using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Unit : ScriptableObject 
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxMana;  
    [SerializeField] private float manaRegenRate;
    [SerializeField] private int damage;
    [SerializeField] private float attackFrequency;
    
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    public int MaxMana { get => maxMana; set => maxMana = value; }

    public int Damage { get => damage; set => damage = value; }
    public float AttackFrequency { get => attackFrequency; set => attackFrequency = value; }

    public float ManaRegenRate { get => manaRegenRate; set => manaRegenRate = value;}


}
