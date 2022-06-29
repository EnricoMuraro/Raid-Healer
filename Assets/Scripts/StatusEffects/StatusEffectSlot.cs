using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GameUnit))]
public class StatusEffectSlot : MonoBehaviour
{
    private Raid raid;
    private GameUnit caster;
    private GameUnit target;
    private StatusEffect statusEffect;

    private float currentTick = 0;
    public float currentDuration = 0;
    private int currentStacks = 0;

    public int Stacks { get => currentStacks; }

    public UnityEvent<StatusEffectSlot> OnStatusEffectFinished = new UnityEvent<StatusEffectSlot>();

    private void Awake()
    {
        raid = FindObjectOfType<Raid>();
        target = GetComponent<GameUnit>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTick = 0;
        currentDuration = 0;
    }

    public void InitStatusEffect(StatusEffect statusEffect, GameUnit caster)
    {
        this.caster = caster;
        this.statusEffect = statusEffect;
        this.statusEffect.StatusEffectStart(caster, target, raid, currentStacks);
    }    

    public StatusEffect GetStatusEffect()
    {
        return statusEffect;
    }    
    
    public void Dispelled()
    {
        statusEffect.OnDispel(caster, target, raid, currentStacks);
    }

    private void OnDisable()
    {
        statusEffect.StatusEffectRemoved(caster, target, raid, currentStacks);
    }

    // Update is called once per frame
    void Update()
    {
        currentDuration += Time.deltaTime;
        currentTick += Time.deltaTime;

        if (currentDuration >= statusEffect.Duration)
        {
            statusEffect.StatusEffectEnd(caster, target, raid, currentStacks);
            OnStatusEffectFinished.Invoke(this);
            Destroy(this);
        }

        if (statusEffect.TickRate > 0)
        {
            if (currentTick >= statusEffect.TickRate)
            {
                statusEffect.Activate(caster, target, raid, currentStacks);
                currentTick = 0;
                currentStacks++;
            }
        }

    }
}
