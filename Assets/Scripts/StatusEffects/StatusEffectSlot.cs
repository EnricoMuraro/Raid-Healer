using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusEffectSlot : MonoBehaviour
{
    private GameUnit unit;
    private StatusEffect statusEffect;

    private float currentTick = 0;
    private float currentDuration = 0;

    public UnityEvent<StatusEffectSlot> OnStatusEffectFinished = new UnityEvent<StatusEffectSlot>();

    // Start is called before the first frame update
    void Start()
    {
        currentTick = 0;
        currentDuration = 0;
    }

    public void InitStatusEffect(GameUnit unit, StatusEffect statusEffect)
    {
        this.unit = unit;
        this.statusEffect = statusEffect;
    }    

    // Update is called once per frame
    void Update()
    {
        currentDuration += Time.deltaTime;
        currentTick += Time.deltaTime;

        if (currentDuration >= statusEffect.Duration)
        {
            OnStatusEffectFinished.Invoke(this);
        }

        if (statusEffect.TickRate > 0)
        {
            if (currentTick >= statusEffect.TickRate)
            {
                statusEffect.Activate(unit);
                currentTick = 0;
            }
        }

    }
}
