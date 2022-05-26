using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerPrefs : MonoBehaviour
{
    public TalentTree talentTree;
    public SpellBook spellBook;
    public BossFightProgress bossFightProgress;

    private void Awake()
    {
        TalentStorage savedTalents = Persistance.LoadTalents();
        talentTree.SetActiveTalents(savedTalents.IDs);
        talentTree.MaximumPointsPerPanel = savedTalents.pointsPerPanel;
        spellBook.SetSelectedAbilities(Persistance.LoadSelectedAbilities());

    }

    private void OnEnable()
    {
        //Load active ability talents into the spellbook
        List<Ability> talentAbilities = new();
        foreach (var talent in talentTree.GetActiveAbilityTalents())
            talentAbilities.Add(talent.ability);
        spellBook.TalentAbilities = talentAbilities;

        //Reset modifiers
        talentTree.DeactivateAllPassiveTalents();

        //Activate passive talents
        talentTree.ActivatePassiveTalents();

        //Load boss fights progress
        int[] bossProgress = Persistance.LoadBossProgress();
        bossFightProgress.SetProgress(bossProgress);
        
        List<BossReward> bossRewards = BossFightProgress.GetCompletedFightsRewards();
        foreach(BossReward reward in bossRewards)
        {
            if (reward != null)
            {
                if (!reward.claimed)
                {
                    spellBook.DefaultAbilities.AddRange(reward.abilityRewards);
                    foreach (BossReward.TalentReward talentReward in reward.talentPointRewards)
                        talentTree.AddMaximumPoints(talentReward.talentPanel, talentReward.talentPoints);
                }
                reward.claimed = true;
            }
        }

        //Remove any selected ability that is no longer in the spellbook 
        for (int i = 0; i < spellBook.SelectedAbilities.Length; i++)
            if (!spellBook.AllAbilities.Contains(spellBook.SelectedAbilities[i]))
                spellBook.SelectedAbilities[i] = null;
    }
}
