using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Unit : ScriptableObject 
{
    
    public Stat maxHealth;
    public Stat shield;
    public Stat maxMana;
    public Stat manaRegenRate;
    public Stat damage;
    public Stat attackFrequency;
    public Stat abilityPower;
    public Stat manaEfficiency;

    public Role role;

    public enum Stats
    {
        maxHealth,
        shield,
        maxMana,
        manaRegenRate,
        damage,
        attackFrequency,
        abilityPower,
        manaEfficiency,
    }

    public enum Role
    {
        Tank,
        Dps,
        Healer,
        Player,
        Boss,
    }
        

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;


}
