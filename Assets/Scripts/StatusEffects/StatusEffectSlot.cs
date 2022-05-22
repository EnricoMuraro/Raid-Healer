using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GameUnit))]
public class StatusEffectSlot : MonoBehaviour
{
    private StatusEffect statusEffect;

    private float currentTick = 0;
    public float currentDuration = 0;

    public UnityEvent<StatusEffectSlot> OnStatusEffectFinished = new UnityEvent<StatusEffectSlot>();

    // Start is called before the first frame update
    void Start()
    {
        currentTick = 0;
        currentDuration = 0;
    }

    public void InitStatusEffect(StatusEffect statusEffect)
    {
        this.statusEffect = statusEffect;
    }    

    public StatusEffect GetStatusEffect()
    {
        return statusEffect;
    }    

    // Update is called once per frame
    void Update()
    {
        currentDuration += Time.deltaTime;
        currentTick += Time.deltaTime;

        if (currentDuration >= statusEffect.Duration)
        {
            OnStatusEffectFinished.Invoke(this);
            Destroy(this);
        }

        if (statusEffect.TickRate > 0)
        {
            if (currentTick >= statusEffect.TickRate)
            {
                statusEffect.Activate(GetComponent<GameUnit>());
                currentTick = 0;
            }
        }

    }
}
