using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Unit : ScriptableObject 
{
    
    public Stat maxHealth;
    public Stat maxMana;
    public Stat manaRegenRate;
    public Stat damage;
    public Stat attackFrequency;

    public enum Stats
    {
        maxHealth,
        maxMana,
        manaRegenRate,
        damage,
        attackFrequency,
    }
        

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;


}
