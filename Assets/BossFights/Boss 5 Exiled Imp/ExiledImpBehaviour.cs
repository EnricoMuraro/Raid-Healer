using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss Behaviour/Exiled Imp")]
public class ExiledImpBehaviour : BossBehaviour
{
    public override void OnUpdate()
    {
        if (raid.Boss.isDead() == false)
        {
            int target = raid.GetRandomRaiderIndex();
            raid.Boss.Attack(raid.GetFirstRaider());
            bossAbilityBar.Activate(0, raid.Boss, target, raid);
        }
    }
}
