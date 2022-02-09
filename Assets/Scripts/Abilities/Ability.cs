using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public float cooldown;
    public float castTime;
   

    public virtual void Activate(Unit target) { }
}
