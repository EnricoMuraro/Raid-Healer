using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Raider : MonoBehaviour, IDamageable
{
    public Unit unit;

    public HealthBar healthBar;

    public void receiveDamage(int amount)
    {
        unit.Health -= amount;

        healthBar.SetMaxHealth(unit.MaxHealth);
        healthBar.SetHealth(unit.Health);
        Debug.Log(healthBar.healthBar.value);
    }

    public void attack(Enemy target)
    {
        if(unit.Cooldown <= 0) {
            Debug.Log("raider attacked");
            unit.Cooldown = unit.AttackFrequency;
            target.receiveDamage(unit.Damage);
        }
    }

    private void Update() {

        unit.Cooldown -= Time.deltaTime;
    }

}
