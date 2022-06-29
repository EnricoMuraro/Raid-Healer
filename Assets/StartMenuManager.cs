using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StartMenuManager : MonoBehaviour
{
    public static string[] CompletedFights;
    public TalentTree talentTree;

    private void Awake()
    {
        bool resetDone = PlayerPrefs.HasKey("talentsReset0.1.6");
        if(!resetDone)
        {
            talentTree.ActiveTalents = new List<Talent>();
            Persistance.SaveTalents(new int[0]);
            PlayerPrefs.SetInt("talentsReset0.1.6", 1);
        }

        //clean up saves
        BossFightEntry[] bossFights = Persistance.LoadBossProgress();
        List<BossFightEntry> newProgress = new();
        foreach(BossFightEntry bossFight in bossFights)
        {
            //check if newProgress does not contain bossFight ID
            if(!newProgress.Any(bf => bf.ID == bossFight.ID))
            {
                //keep only the bossFight with the highest stars for each id
                BossFightEntry highestStars = bossFights.Where(bf => bf.ID == bossFight.ID).OrderByDescending(bf => bf.stars).FirstOrDefault();
                if (highestStars != null)
                    newProgress.Add(highestStars);
            }

        }
        Persistance.SaveBossProgress(newProgress.ToArray());
    }
}
