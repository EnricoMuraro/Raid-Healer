using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
