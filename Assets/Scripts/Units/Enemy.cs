using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public Unit unit;
    public HealthBar healthBar;

    public void receiveDamage(int amount)
    {
        unit.Health -= amount;
    }

    public void attack(Raider target)
    {
        if(unit.Cooldown <= 0) {

            Debug.Log("enemy attacked");
            unit.Cooldown = unit.AttackFrequency;
            target.receiveDamage(unit.Damage);
        }
    }


    private void Update() {
        healthBar.SetMaxHealth(unit.MaxHealth);
        healthBar.SetHealth(unit.Health);

        unit.Cooldown -= Time.deltaTime;
    }

}
