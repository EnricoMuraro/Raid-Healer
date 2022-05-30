using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss Behaviour/Old Goblin Torch")]
public class SecondBossBehaviour : BossBehaviour
{

    // Update is called once per frame
    public override void OnUpdate()
    {
        if (raid.Boss.isDead() == false)
        {
            GameUnit target = raid.GetFirstRaider();
            raid.Boss.Attack(target);
            bossAbilityBar.Activate(0, raid.Boss, raid.GetFirstRaiderIndex(), raid);
            bossAbilityBar.Activate(1, raid.Boss, raid.GetFirstRaiderIndex(), raid);
        }
    }
}
