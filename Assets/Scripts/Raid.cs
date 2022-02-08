using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Raid : MonoBehaviour
{

    public Raider[,] raiders;
    [SerializeField]
    public HealthBar[] raiderHealthBars;
    public Enemy enemy;
    public HealthBar enemyHealthBar;
    

    private float prevTime;

    void Start() 
    {   
        prevTime = Time.time;
        Debug.Log("started");
        enemy = new Enemy(1000, 5, 5.0f, 5.0f);
        enemyHealthBar.SetHealth(enemy.Health);
        enemyHealthBar.SetMaxHealth(enemy.MaxHealth);

        raiders = new Raider[3,3];
        for(int i=0; i<raiders.GetLength(0); i++)
            for(int j=0; j<raiders.GetLength(1); j++)
            {
                int arrayIndex = i + (j*raiders.GetLength(0));
                raiders[i,j] = new Raider(100, 5, 3.0f, arrayIndex*0.2f);
                raiderHealthBars[arrayIndex].SetHealth(raiders[i,j].Health);
                raiderHealthBars[arrayIndex].SetMaxHealth(raiders[i,j].MaxHealth);
            }
    }

    // Update is called once per frame
    void Update()
    {
        RaidAttack();
        BossAttack();
        prevTime = Time.time;
    }

    void RaidAttack() {

        foreach (Raider raider in raiders) {
            raider.Cooldown -= Time.time - prevTime;
            if(raider.Cooldown <= 0) {
                raider.Cooldown = raider.AttackFrequency;
                enemy.Health -= raider.Damage;
                enemyHealthBar.SetHealth(enemy.Health);
            }
        }
    }

    void BossAttack() {

        enemy.Cooldown -= Time.time - prevTime;
        if(enemy.Cooldown <= 0) {
            enemy.Cooldown = enemy.AttackFrequency;
            for (int i=0; i<raiders.GetLength(0); i++) {
                for (int j=0; j<raiders.GetLength(1); j++) {
                    raiders[i,j].Health -= enemy.Damage;
                    int arrayIndex = i + (j*raiders.GetLength(0));
                    raiderHealthBars[arrayIndex].SetHealth(raiders[i,j].Health);
                }
            }
        }
    }

    void FixedUpdate()
    {   

    }
}
