using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raider : Unit
{
    public Raider(int health, int damage, float attackfrequency, float cooldown) 
            : base(health, damage, attackfrequency, cooldown) { }
}
