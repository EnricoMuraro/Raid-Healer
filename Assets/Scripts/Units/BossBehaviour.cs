using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[CreateAssetMenu(menuName = "Boss Behaviour")]
public class BossBehaviour : ScriptableObject
{
    private Raid raid;
    private AbilityBar bossAbilityBar;

    public TargetStrategy attackTargeting;
    public TargetStrategy[] abilitiesTargeting = new TargetStrategy[0];

    public void Init(Raid raid, AbilityBar abilityBar)
    {
        this.raid = raid;
        this.bossAbilityBar = abilityBar;
        foreach(TargetStrategy targeting in abilitiesTargeting)
            targeting.lastTargets = new();
    }
    
    public virtual void OnUpdate() 
    {
        if(raid.Boss.IsDead() == false)
        {
            //attack
            GameUnit targetUnit = attackTargeting.GetTarget(raid);
            if (targetUnit != null)
                raid.Boss.Attack(targetUnit);
            else
                Debug.LogWarning("No valid target for boss attack");

            //use abilities
            for(int i = 0, j = 0; i < bossAbilityBar.AbilitySlotsLength(); i++, j++)
            {
                if(bossAbilityBar.isActiveAbility(i))
                {
                    if (j < abilitiesTargeting.Length)
                    {
                        int target = abilitiesTargeting[j].GetTargetIndex(raid);
                        if (target != -1)
                        {
                            string result = bossAbilityBar.Activate(i, raid.Boss, target, raid);
                            if (result == "")
                                abilitiesTargeting[j].lastTargets.Add(target);
                        }
                        else
                            Debug.Log("No valid targets for boss ability " + i);
                    }
                    else
                        Debug.LogWarning("Ability " + i + " has no target strategy");
                }
                else
                {
                    j--;
                }
            }
        }
    }
}

[System.Serializable]
public class TargetStrategy
{
    public Strategy strategy;
    public List<Unit.Role> RolesBlacklist;
    [HideInInspector]
    public List<int> lastTargets = new();
    private List<GameUnit> possibleTargets = new();

    public enum Strategy
    {
        first,
        lowestHealthPercent,
        highestHealthPercent,
        lowestHealth,
        highestHealth,
        random,
        randomAvoidRepeat,
    }

    public GameUnit GetTarget(Raid raid)
    {
        //todo filter by role using blacklist
        bool filter(GameUnit x) => !x.IsDead();
        
        switch (strategy)
        {
            case Strategy.first:
                return raid.raiders.FirstOrDefault(filter);
            case Strategy.lowestHealthPercent:
                return raid.raiders.OrderBy(x => (float)x.Health / x.MaxHealth).FirstOrDefault(filter);
            case Strategy.highestHealthPercent:
                return raid.raiders.OrderByDescending(x => (float)x.Health / x.MaxHealth).FirstOrDefault(filter);
            case Strategy.lowestHealth:
                return raid.raiders.OrderBy(x => x.Health).FirstOrDefault(filter);
            case Strategy.highestHealth:
                return raid.raiders.OrderByDescending(x => x.Health).FirstOrDefault(filter);
            case Strategy.random:
                {
                    GameUnit[] filteredList = raid.raiders.Where(filter).ToArray();
                    if (filteredList.Length > 0)
                        return filteredList.ElementAt(UnityEngine.Random.Range(0, filteredList.Length));
                    else
                        return null;
                }
            case Strategy.randomAvoidRepeat:
                {
                    GameUnit target = null;
                    //make sure the target is not one of the last (raiders.length-1) targets
                    possibleTargets = raid.raiders.Where(x => filter(x) && !lastTargets.TakeLast(raid.raiders.Length - 1).Contains(raid.GetRaiderIndex(x))).ToList();

                    if(possibleTargets.Count > 0)
                    {
                        target = possibleTargets.ElementAt(UnityEngine.Random.Range(0, possibleTargets.Count));
                        possibleTargets.Remove(target);
                    }

                    return target;
                }
        }
        return null;
    }


    public int GetTargetIndex(Raid raid)
    {
        GameUnit target = GetTarget(raid);
        if(target != null)
            return raid.GetRaiderIndex(target);
        else
            return -1;
    }
}