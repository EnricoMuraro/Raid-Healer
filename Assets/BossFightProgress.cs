using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightProgress : MonoBehaviour
{
    private static BossFightIcon[] bossFightIcons;
    public static Dictionary<int, string> fightSceneNames = new ();

    private void Awake()
    {
        bossFightIcons = GetComponentsInChildren<BossFightIcon>();
        fightSceneNames.TryAdd(1, "bossfight1");
        fightSceneNames.TryAdd(2, "bossfight2");
    }

    public static void SetFightCompleted(int fightID)
    {
        foreach (BossFightIcon bossFightIcon in bossFightIcons)
            if (bossFightIcon.bossFightInfo.ID == fightID)
                bossFightIcon.SetCompletedFlag(true);
        SaveProgress();
    }

    public void SetProgress(int[] completedFightIDs)
    {
        foreach (BossFightIcon bossFight in bossFightIcons)
            foreach (int completedFightID in completedFightIDs)
                if (bossFight.bossFightInfo.ID == completedFightID)
                    bossFight.SetCompletedFlag(true);
    }

    public static void SaveProgress()
    {
        List<int> progress = new ();
        foreach (BossFightIcon bossFight in bossFightIcons)
            if(bossFight.GetCompletedFlag())
                progress.Add(bossFight.bossFightInfo.ID);

        Persistance.SaveBossProgress(progress.ToArray());
    }

    private void OnDisable()
    {
        SaveProgress();
    }
}
