using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CombatStats : ScriptableObject
{

    public Dictionary<Stats,int> stats = new Dictionary<Stats,int>();


    public enum Stats
    {
        HealingDone,
        OverHealingDone,
        ManaUsed,
        ManaRegenerated,
        RaiderDeaths,
        LowestRaiderHealth,
        TotalNumberOfCasts,
        Ability1Casts,
        Ability2Casts,
        Ability3Casts,
        Ability4Casts,
        Ability5Casts,
    }
    /*
    public int HealingDone;
    public int OverHealingDone;
    public int ManaUsed;
    public int ManaRegenerated;
    public int RaiderDeaths;
    public int LowestRaiderHealth;
    public int TotalNumberOfCasts;
    public int Ability1Casts;
    public int Ability2Casts;
    public int Ability3Casts;
    public int Ability4Casts;
    public int Ability5Casts;
    */

}
