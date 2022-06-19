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
    private float currentChannelDuration;
    private float currentTick;

    private AbilityState state = AbilityState.ready;

    public int TargetIndex => targetIndex;
    public Raid Raid => raid;

    private void Start()
    {
        if(StartingCooldown > 0)
        {
            currentCooldown = StartingCooldown;
            state = AbilityState.cooldown;
            onCooldownStart.Invoke(this);
        }

        if (castBar != null && state != AbilityState.casting)
            castBar.gameObject.SetActive(false);
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
        channeling,
        cooldown
    }


    public bool IsCastingOrChanneling()
    {
        return (State == AbilityState.casting || State == AbilityState.channeling);
    }

    public string Activate(GameUnit caster, int targetIndex, Raid raid)
    {
        if (ability != null)
        {
            if (ability is ActiveAbility activeAbility)
            {
                if (caster.Mana < activeAbility.ManaCost)
                    return "Not enough mana";
                if (raid.raiders[targetIndex].IsDead())
                    return "You can't cast on a dead target";

                if (State == AbilityState.ready && !caster.IsDead())
                {
                    this.caster = caster;
                    this.targetIndex = targetIndex;
                    this.raid = raid;
                    State = AbilityState.casting;
                    currentCastTime = 0;

                    if (castBar != null)
                    {
                        castBar.displayValues = false;
                        castBar.SetText(ability.name);
                    }
                }
            }
        }

        return "";
    }

    public void InterruptCast()
    {
        if(ability is ActiveAbility activeAbility)
        {
            if(State == AbilityState.casting)
                State = AbilityState.ready;

            if(State == AbilityState.channeling)
            {
                State = AbilityState.cooldown;
                currentCooldown = activeAbility.Cooldown;
                onCooldownStart.Invoke(this);
            }

            if (castBar != null)
                castBar.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        if(ability is ActiveAbility activeAbility)
            switch (State)
            {
                case AbilityState.casting:
                    if (currentCastTime <= activeAbility.CastTime)
                    {
                        currentCastTime += Time.deltaTime;
                        if(castBar != null && activeAbility.CastTime > 0) 
                        {
                            castBar.gameObject.SetActive(true);
                            castBar.SetMaxValue(activeAbility.CastTime);
                            castBar.SetValue(currentCastTime);
                        }
                    }
                    else
                    {
                        ability.Activate(caster, targetIndex, raid);
                        if (ability is Channel)
                        {
                            State = AbilityState.channeling;
                            currentChannelDuration = 0;
                            currentTick = 0;

                        }    
                        else
                        {
                            State = AbilityState.cooldown;
                            currentCooldown = activeAbility.Cooldown;
                            onCooldownStart.Invoke(this);

                            if (castBar != null)
                                castBar.gameObject.SetActive(false);
                        }

                    }
                    break;

                case AbilityState.channeling:
                    Channel channeledAbility = ability as Channel;
                    currentChannelDuration += Time.deltaTime;
                    currentTick += Time.deltaTime;

                    castBar.gameObject.SetActive(true);
                    castBar.SetMaxValue(channeledAbility.Duration);
                    castBar.SetValue(channeledAbility.Duration - currentChannelDuration);

                    if (currentChannelDuration >= channeledAbility.Duration)
                    {
                        State = AbilityState.cooldown;
                        currentCooldown = activeAbility.Cooldown;
                        onCooldownStart.Invoke(this);
                        if (castBar != null)
                            castBar.gameObject.SetActive(false);
                    }

                    if (channeledAbility.TickRate > 0)
                    {
                        if (currentTick >= channeledAbility.TickRate)
                        {
                            channeledAbility.Tick(caster, targetIndex, raid);
                            currentTick = 0;
                        }
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
