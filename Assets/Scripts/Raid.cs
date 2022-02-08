using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Raid : MonoBehaviour
{

    public Raider[,] raiders;
    public Enemy[] enemies;

    private float prevTime;

    void Start() 
    {   
        prevTime = Time.time;
        Debug.Log("started");
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
                Debug.Log(Time.time + "raider attacked");
            }
        }

        prevTime = Time.time;
    }

    void FixedUpdate()
    {   

    }
}
