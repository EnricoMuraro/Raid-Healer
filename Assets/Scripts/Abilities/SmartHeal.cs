using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Smart Heal")]
public class SmartHeal : Ability
{
    public Stat heal;
    public Stat shield;
    public Stat numberOfTargets;
    public int Heal => (int)heal.Value + abilityPower;
    public int Shield => (int)shield.Value;
    public int NumberOfTargets => (int)numberOfTargets.Value;


    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);

        GameUnit[] sortedRaiders = raid.raiders.OrderBy(raider => (float)raider.Health/raider.MaxHealth).ToArray();

        int healCount = NumberOfTargets;
        for (int i = 0; i < sortedRaiders.Length && healCount > 0; i++)
        {   
            if(!sortedRaiders[i].IsDead())
            {
                sortedRaiders[i].ReceiveHeal(Heal);
                sortedRaiders[i].ReceiveShield(Shield);
                healCount--;
                if (nextAbility != null)
                    nextAbility.Activate(caster, raid.GetRaiderIndex(sortedRaiders[i]), raid);
            }
        }
    }
}
