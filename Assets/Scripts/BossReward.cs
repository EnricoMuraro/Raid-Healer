using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BossReward : ScriptableObject
{
    public bool claimed;
    public List<TalentReward> talentPointRewards = new ();
    public List<Ability> abilityRewards = new ();

    [Serializable]
    public class TalentReward
    {
        public int talentPanel;
        public int talentPoints;
    }
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

}