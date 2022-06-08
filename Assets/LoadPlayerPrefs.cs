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

        //Load boss fights progress
        bossFightProgress.SetProgress(Persistance.LoadBossProgress());
        //Load boss rewards
        List<BossReward> bossRewards = BossFightProgress.GetCompletedFightsRewards();
        spellBook.RewardAbilities = new();
        talentTree.MaximumPointsPerPanel = new int[0];
        foreach (BossReward reward in bossRewards)
        {
            if (reward != null)
            {
                foreach (Ability ability in reward.abilityRewards)
                    if (ability != null)
                        spellBook.RewardAbilities.Add(ability);
                foreach (BossReward.TalentReward talentReward in reward.talentPointRewards)
                    talentTree.AddMaximumPoints(talentReward.talentPanel, talentReward.talentPoints);

            }
        }

        talentTree.SetActiveTalents(Persistance.LoadTalents());

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

        spellBook.SetSelectedAbilities(Persistance.LoadSelectedAbilities());
        //Remove any selected ability that is no longer in the spellbook 
        for (int i = 0; i < spellBook.SelectedAbilities.Length; i++)
            if (!spellBook.AllAbilities.Contains(spellBook.SelectedAbilities[i]))
                spellBook.SelectedAbilities[i] = null;
    }
}
