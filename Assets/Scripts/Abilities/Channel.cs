using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel : ActiveAbility
{
    public Stat tickRate;
    public Stat duration;

    public float TickRate => tickRate.Value;
    public float Duration => duration.Value;

    public virtual void Tick(GameUnit caster, int targetIndex, Raid raid) { }
     
}
