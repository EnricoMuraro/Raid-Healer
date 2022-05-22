using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossBehaviour : MonoBehaviour
{

    public Raid raid;
    public AbilityBar bossAbilityBar;
    public float waitTime;

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            if (raid.Boss.isDead() == false)
            {
                GameUnit target = raid.GetFirstRaider();
                raid.Boss.attack(target);
                bossAbilityBar.Activate(0, raid.Boss, raid.GetFirstRaiderIndex(), raid);
                bossAbilityBar.Activate(1, raid.Boss, raid.GetFirstRaiderIndex(), raid);
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

    }
}
