using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatsLogger
{

    public static CombatStats combatStats;

    public static void SumValue(CombatStats.Stats stat, int value)
    {
        combatStats.stats[stat] += value;
    }


}
