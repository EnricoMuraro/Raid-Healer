using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : ScriptableObject
{
    public Raid raid;
    public AbilityBar bossAbilityBar;

    public virtual void OnUpdate() { }
}
