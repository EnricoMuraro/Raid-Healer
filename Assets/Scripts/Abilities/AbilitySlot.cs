using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlot : MonoBehaviour
{
    public Ability ability;
    public ProgressBar castBar;

    private GameUnit caster;
    private int targetIndex;
    private Raid raid;

    private float currentCooldown;
    private float currentCastTime;

    public float CurrentCooldown {get => currentCooldown;}

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

    public void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        if(state == AbilityState.ready && !caster.isDead() && caster.Mana >= ability.manaCost)
        {
            this.caster = caster;
            this.targetIndex = targetIndex;
            this.raid = raid;
            state = AbilityState.casting;
            currentCastTime = 0;
        }
    }

    public void InterruptCast()
    {
        if(state == AbilityState.casting)
        {
            state = AbilityState.ready;
            if (castBar != null)
                castBar.gameObject.SetActive(false);
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
                    if(castBar != null) 
                    {
                        castBar.gameObject.SetActive(true);
                        castBar.SetMaxValue(ability.castTime);
                        castBar.SetValue(currentCastTime);
                    }
                }
                else
                {
                    ability.Activate(caster, targetIndex, raid);
                    state = AbilityState.cooldown;
                    currentCooldown = ability.cooldown;

                    if (castBar != null)
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
