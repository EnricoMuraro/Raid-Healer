using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlot : MonoBehaviour
{
    public Ability ability;
    public ProgressBar castBar;

    GameUnit target;
    GameUnit caster;

    private float currentCooldown;
    private float currentCastTime;

    enum AbilityState
    {
        ready,
        casting,
        cooldown
    }

    AbilityState state = AbilityState.ready;

    public bool IsCasting()
    {
        return state == AbilityState.casting;
    }

    public void Activate(GameUnit caster, GameUnit target)
    {
        if(state == AbilityState.ready && caster.Mana >= ability.manaCost)
        {
            this.caster = caster;
            this.target = target;
            state = AbilityState.casting;
            currentCastTime = 0;
        }
    }

    private void Update()
    {
        switch (state)
        {
            case AbilityState.casting:
                if (currentCastTime <= ability.castTime)
                {
                    currentCastTime += Time.deltaTime;

                    castBar.gameObject.SetActive(true);
                    castBar.SetMaxValue(ability.castTime);
                    castBar.SetValue(currentCastTime);
                }
                else
                {
                    ability.Activate(caster, target);
                    state = AbilityState.cooldown;
                    currentCooldown = ability.cooldown;

                    castBar.gameObject.SetActive(false);
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
