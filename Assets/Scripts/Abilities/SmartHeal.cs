using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Smart Heal")]
public class SmartHeal : Ability
{
    public Stat heal;
    public Stat numberOfTargets;
    public StatusEffect statusEffect;

    public int NumberOfTargets => (int)numberOfTargets.Value;
    public int Heal => (int)heal.Value;


    public override void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        base.Activate(caster, targetIndex, raid);

        GameUnit[] sortedRaiders = raid.raiders.OrderBy(raider => (float)raider.Health/(float)raider.MaxHealth).ToArray();

        int healCount = NumberOfTargets;
        for (int i = 0; i < sortedRaiders.Length && healCount > 0; i++)
        {   
            if(!sortedRaiders[i].isDead())
            {
                sortedRaiders[i].ReceiveHeal(Heal);
                healCount--;
                if (statusEffect != null)
                    sortedRaiders[i].AddStatusEffect(statusEffect);
            }
        }
    }
}
