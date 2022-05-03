using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : ScriptableObject
{
    public int ID;
    public new string name;
    public Sprite icon;

    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float castTime;
    [SerializeField]
    private int manaCost;

    public float Cooldown { get => cooldown; set => cooldown = value; }
    public float CastTime { get => castTime; set => castTime = value; }
    public int ManaCost { get => manaCost; set => manaCost = value; }

    public virtual void Activate(GameUnit caster, int targetIndex, Raid raid) {}
}

/*
public class AbilityArgs
{
    public GameUnit caster;
    public int targetIndex;
    public Raid raid1;
}
*/