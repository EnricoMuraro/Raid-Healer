using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : ScriptableObject
{
    public int ID;
    public new string name;
    public float cooldown;
    public float castTime;
    public int manaCost;

    public virtual void Activate(GameUnit caster, int targetIndex, GameUnit[] raiders) { }
}
