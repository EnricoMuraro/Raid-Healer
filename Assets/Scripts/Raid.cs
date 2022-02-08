using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Raid : MonoBehaviour
{

    public Raider[,] raiders;
    public Enemy enemy;

    private float prevTime;

    void Start() 
    {   
        prevTime = Time.time;
        Debug.Log("started");
        enemy = new Enemy(10000, 20, 3.0f, 0.0f);
        raiders = new Raider[3,3];
        for(int i=0; i<raiders.GetLength(0); i++)
            for(int j=0; j<raiders.GetLength(1); j++)
            {
                raiders[i,j] = new Raider(100, 5, 3.0f, 0.0f);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (Raider raider in raiders) {
            raider.Cooldown -= Time.time - prevTime;
            if(raider.Cooldown <= 0) {
                raider.Cooldown = raider.AttackFrequency;
                enemy = raider.Attack(enemy) as Enemy;
            }
        }
        Debug.Log(enemy.Health);
        prevTime = Time.time;
    }

    void FixedUpdate()
    {   

    }
}
