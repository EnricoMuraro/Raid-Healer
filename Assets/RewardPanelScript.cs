using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardPanelScript : MonoBehaviour
{
    public static TextMeshProUGUI rewardsText;

    private void Awake()
    {
        rewardsText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public static void DispalyRewards(BossReward bossReward)
    {
        int totalPoints = 0;
        bossReward.talentPointRewards.ForEach(x => totalPoints += x.talentPoints);
        rewardsText.text = "+" + totalPoints + " Talent points";
        rewardsText.text += "\n";
        if (bossReward.abilityRewards != null)
            foreach (var ability in bossReward.abilityRewards)
                if (ability != null)
                    rewardsText.text += "New ability: " + ability.name;
    }

    public static void DisplayNoRewards()
    {
        rewardsText.text = "No rewards";
    }
}
