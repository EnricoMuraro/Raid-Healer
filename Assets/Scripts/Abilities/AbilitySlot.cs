using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbilitySlot : MonoBehaviour
{
    public Ability ability;
    public ProgressBar castBar;
    public float StartingCooldown;
    public UnityEvent<AbilitySlot> onStateChange = new UnityEvent<AbilitySlot>();
    public UnityEvent<AbilitySlot> onCooldownStart = new UnityEvent<AbilitySlot>();

    private GameUnit caster;
    private int targetIndex;
    private Raid raid;

    private float currentCooldown;
    private float currentCastTime;

    private AbilityState state = AbilityState.ready;

    private void Awake()
    {
        if(StartingCooldown > 0)
        {
            currentCooldown = StartingCooldown;
            state = AbilityState.cooldown;
            onCooldownStart.Invoke(this);
        }
    }

    public float CurrentCooldown {get => currentCooldown;}
    public AbilityState State 
    { 
        get => state;
        private set
        {
            state = value;
            onStateChange?.Invoke(this);
        }
    }

    public enum AbilityState
    {
        ready,
        casting,
        cooldown
    }


    public bool IsCasting()
    {
        return State == AbilityState.casting;
    }

    public void Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        if(ability != null && State == AbilityState.ready && !caster.isDead() && caster.Mana >= ability.ManaCost)
        {
            this.caster = caster;
            this.targetIndex = targetIndex;
            this.raid = raid;
            State = AbilityState.casting;
            currentCastTime = 0;

            if(castBar != null)
            {
                castBar.displayValues = false;
                castBar.SetText(ability.name);
            }
        }
    }

    public void InterruptCast()
    {
        if(State == AbilityState.casting)
        {
            State = AbilityState.ready;
            if (castBar != null)
                castBar.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        switch (State)
        {
            case AbilityState.casting:
                if (currentCastTime <= ability.CastTime)
                {
                    currentCastTime += Time.deltaTime;
                    if(castBar != null && ability.CastTime > 0) 
                    {
                        castBar.gameObject.SetActive(true);
                        castBar.SetMaxValue(ability.CastTime);
                        castBar.SetValue(currentCastTime);
                    }
                }
                else
                {
                    ability.Activate(caster, targetIndex, raid);
                    State = AbilityState.cooldown;
                    currentCooldown = ability.Cooldown;
                    onCooldownStart.Invoke(this);

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
                    State = AbilityState.ready;
                    currentCooldown = 0;
                }
                break;
        }
    }
}
