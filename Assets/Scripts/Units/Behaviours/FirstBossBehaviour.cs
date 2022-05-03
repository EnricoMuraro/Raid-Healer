
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossBehaviour : MonoBehaviour
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
                bossAbilityBar.Activate(0, raid.Boss, 0, raid);
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

    }
}
