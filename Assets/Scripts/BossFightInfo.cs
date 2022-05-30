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
    public Unit BossUnit;
    public List<Ability> Abilities;
    public BossBehaviour BossBehaviour;
    public BossReward Reward;
    public RaidSize raidSize;

    public enum RaidSize
    {
        size3x3,
    }


}
