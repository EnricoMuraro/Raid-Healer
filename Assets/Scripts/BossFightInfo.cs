using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BossFightInfo : ScriptableObject
{
    public int ID;
    public string Name;
    [TextArea]
    public string Description;
    [HideInInspector]
    public int Difficulty;
    public Unit BossUnit;
    public List<Ability> Abilities;
    public BossBehaviour BossBehaviour;
    public BossReward Reward;
    public List<Aura> Auras;
    public RaidSize raidSize;

    public enum RaidSize
    {
        size3x3,
    }


}
