using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public Enemy(int health, int damage, float attackfrequency, float cooldown)
              : base(health, damage, attackfrequency, cooldown) { }
}
