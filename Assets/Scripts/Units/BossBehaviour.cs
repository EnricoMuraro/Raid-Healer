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
            for(int i = 0; i < bossAbilityBar.AbilitySlotsLength(); i++)
            {
                if (i < abilitiesTargeting.Length)
                {
                    int target = abilitiesTargeting[i].GetTargetIndex(raid);
                    if (target != -1)
                        bossAbilityBar.Activate(i, raid.Boss, target, raid);
                    else
                        Debug.Log("No valid targets for boss ability " + i);
                }
                else
                    Debug.LogWarning("Ability " + i + " has no target strategy");
                    
            }
        }
    }
}

[System.Serializable]
public class TargetStrategy
{
    public Strategy strategy;
    public List<Unit.Role> RolesBlacklist;

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
                    if(possibleTargets.Count == 0)
                        possibleTargets = raid.raiders.Where(filter).ToList();

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