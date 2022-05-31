using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourScript : MonoBehaviour
{

    public Raid raid;
    public AbilityBar bossAbilityBar;
    public BossBehaviour bossBehaviour;
    public float waitTime = 1;

    private void Start()
    {
        bossBehaviour.Init(raid, bossAbilityBar);
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0)
            bossBehaviour.OnUpdate();
        else
            waitTime -= Time.deltaTime;


    }
}
