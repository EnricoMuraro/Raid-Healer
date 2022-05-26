using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BossFightInfo : ScriptableObject
{
    public int ID;
    public string Name;
    public string Description;
    public BossReward Reward;
}
