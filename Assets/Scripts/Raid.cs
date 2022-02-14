using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Raid : MonoBehaviour
{

    [SerializeField] public GameUnit[] raiders;
    public GameUnit Boss;
    public int raidRows;
    public int raidColumns;

    private void Update() 
    {
        foreach (GameUnit raider in raiders) {
            raider.attack(Boss);
        }
    }

    public (int, int) ArrayIndexToMatrixCoords(int arrayIndex)
    {
        int row = arrayIndex/raidColumns;
        int column = arrayIndex%raidColumns;
        return(row, column);
    }

    public GameUnit[,] GetRaidersAsMatrix()
    {
        GameUnit[,] raidersMatrix = new GameUnit[raidRows,raidColumns];
        for (int i = 0; i < raidRows; i++)
            for (int j = 0; j < raidColumns; j++) 
            {
                raidersMatrix[i,j] = raiders[(j + (i*raidColumns))];
            }
        return raidersMatrix;
    }

    public List<GameUnit> GetRaidersByRow(int row)
    {
        GameUnit[,] raidersMatrix = GetRaidersAsMatrix();
        List<GameUnit> targets = new List<GameUnit>();
        for (int j = 0; j < raidersMatrix.GetLength(1); j++)
            targets.Add(raidersMatrix[row, j]);
        return targets;
    }

    public List<GameUnit> GetRaidersByColumn(int column)
    {
        GameUnit[,] raidersMatrix = GetRaidersAsMatrix();
        List<GameUnit> targets = new List<GameUnit>();
        for (int i = 0; i < raidersMatrix.GetLength(0); i++)
            targets.Add(raidersMatrix[i, column]);
        return targets;
    }


    public List<GameUnit> GetFirstRaiders(int numberOfRaiders, bool aliveOnly = true)
    {
        List<GameUnit> targets = new List<GameUnit>();
        int count = 0;
        for (int i = 0; i < raiders.Length && count < numberOfRaiders; i++)
        {   
            if (aliveOnly) 
            {
                if(!raiders[i].isDead())
                {
                    targets.Add(raiders[i]);
                    count++;
                }   
            }
            else
            {
                targets.Add(raiders[i]);
                count++;
            }
        }

        return targets;
    }

    public GameUnit GetFirstRaider(bool aliveOnly = true) 
    {   
        List<GameUnit> raiders = GetFirstRaiders(1,aliveOnly);
        if (raiders.Count > 0)
            return raiders.ToArray()[0];
        else
            return null;
    }



    /*
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
        updateHealthBars();
        prevTime = Time.time;
    }

    void updateHealthBars()
    {
        for (int i = 0; i < raiders.GetLength(0); i++)
            for (int j = 0; j < raiders.GetLength(1); j++)
            {
                int arrayIndex = i + (j * raiders.GetLength(0));
                raiderHealthBars[arrayIndex].SetHealth(raiders[i, j].Health);
            }

        enemyHealthBar.SetHealth(enemy.Health);
            
    }

    void RaidAttack() {

        foreach (Raider raider in raiders) {
            raider.Cooldown -= Time.time - prevTime;
            if(raider.Cooldown <= 0) {
                raider.Cooldown = raider.AttackFrequency;
                enemy.Health -= raider.Damage;
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
                }
            }
        }
    }

    void FixedUpdate()
    {   

    }
    */
}
