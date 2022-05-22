using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : ScriptableObject
{

    public int ID;
    public string Name;
    public float Duration;
    public float TickRate;
    public Sprite Icon;
    public ActivationMode activationMode;

    public enum ActivationMode
    {
        add,
        replace,
    }


    public virtual void Activate(GameUnit gameUnit) { }

}
