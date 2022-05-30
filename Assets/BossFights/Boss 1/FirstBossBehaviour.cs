
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss Behaviour/Old goblin")]
public class FirstBossBehaviour : BossBehaviour
{
    public override void OnUpdate()
    {   
        if (raid.Boss.isDead() == false)
        {
            GameUnit target = raid.GetFirstRaider();
            raid.Boss.Attack(target);
            bossAbilityBar.Activate(0, raid.Boss, raid.GetFirstRaiderIndex(), raid);
        }
    }
}
