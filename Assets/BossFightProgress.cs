using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightProgress : MonoBehaviour
{
    private static BossFightIcon[] bossFightIcons;
    public static Dictionary<int, string> fightSceneNames = new();
    public static int TotalStars;

    private void Awake()
    {
        bossFightIcons = GetComponentsInChildren<BossFightIcon>();
        fightSceneNames.TryAdd(1, "bossfight1");
        fightSceneNames.TryAdd(2, "bossfight2");
        fightSceneNames.TryAdd(3, "BearBossFight");
        fightSceneNames.TryAdd(4, "BigBearBossFight");
    }

    public static BossFightIcon GetBossFightByID(int fightID)
    {
        foreach (BossFightIcon bossFight in bossFightIcons)
            if (bossFight.bossFightInfo.ID == fightID)
                return bossFight;
        return null;
    }

    public static void SetFightCompleted(int fightID, int stars)
    {
        foreach (BossFightIcon bossFightIcon in bossFightIcons)
            if (bossFightIcon.bossFightInfo.ID == fightID)
                bossFightIcon.SetCompletedFlag(true, stars);
    }

    public static BossFightInfo GetBossFightInfo(int fightID)
    {
        return GetBossFightByID(fightID).bossFightInfo;
    }

    public void SetProgress(BossFightEntry[] completedFights)
    {
        TotalStars = 0;
        foreach (BossFightEntry completedFight in completedFights)
        {
            GetBossFightByID(completedFight.ID).SetCompletedFlag(true, completedFight.stars);
            TotalStars += completedFight.stars;
        }
    }

    public static List<BossReward> GetCompletedFightsRewards()
    {
        List<BossReward> result = new List<BossReward>();
        foreach (BossFightIcon bossFight in bossFightIcons)
            if (bossFight.GetCompletedFlag())
                result.Add(bossFight.bossFightInfo.Reward);
        return result;
    }

    /*
    public static void SaveProgress()
    {
        List<int> progress = new ();
        foreach (BossFightIcon bossFight in bossFightIcons)
            if(bossFight.GetCompletedFlag())
                progress.Add(bossFight.bossFightInfo.ID);

        Persistance.SaveBossProgress(progress.ToArray());
    }
    */

}
