using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlot : MonoBehaviour
{
    public Ability ability;
    public Raider target;

    private float currentCooldown;
    private float currentCastTime;

    enum AbilityState
    {
        ready,
        casting,
        cooldown
    }

    AbilityState state = AbilityState.ready;
    public KeyCode key;

    private void Update()
    {
        switch (state)
        {
            case AbilityState.ready: 
                if (Input.GetKeyDown(key))
                {
                    ability.Activate(target.unit);
                    state = AbilityState.casting;
                    currentCastTime = 0;
                }
                break;

            case AbilityState.casting:
                if (currentCastTime < ability.castTime)
                {
                    currentCastTime += Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    currentCooldown = ability.cooldown;
                }
                break;

            case AbilityState.cooldown: 
                if (currentCooldown > 0)
                {
                    currentCooldown -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                    currentCooldown = 0;
                }
                break;
        }
    }
}
