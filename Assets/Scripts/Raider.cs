using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raider
{
    public int Health;
    public int Damage;
    public float AttackFrequency;
    private float _cooldown;

    public float Cooldown {
        get => _cooldown;
        set {
            _cooldown = value;
            if (_cooldown < 0) 
                _cooldown = 0;
            }
    }

    public Raider(int health, int damage, float attackfrequency, float cooldown)
    {
        Health = health;
        Damage = damage;
        AttackFrequency = attackfrequency;
        Cooldown = cooldown;
    }
}
